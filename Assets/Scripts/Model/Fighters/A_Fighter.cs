using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FightGame
{
	public abstract class A_Fighter
	{
		protected A_Status 						status;
		protected FSMContext 					moveGraph;
		protected Vector3 						globalFowardVector;
		
		public	string							name;
		public 	GameObject 						gobj;
		public 	Dictionary<string, Transform> 	joints;
		public 	Dictionary<string, HurtBox> 	hurtBoxes;
		public 	Dictionary<string, HitBox> 		hitBoxes;
		public	int								playerNumber;
		public	float							cur_hp, max_hp;
		public	float							cur_meter, max_meter;
		public	float							moveSpeed;
		public	Location						hurtLocation;
		public	float							globalActionTimer;
		public	Vector3							movement;
		public	float							radius;
		public	Vector3							localForwardVector;
		
		public ActionCommand 					currentAction;
		public MoveCommand						currentMovement;
		public A_Attack							currentAttack;
		public List<string>						commandLog;
		public Dictionary<ActionCommand, A_Attack> 	actionsCommandMap;
		public Dictionary<FighterAnimation, string> animationNameMap;
		
		public A_Fighter(GameObject gobj, int playerNumber)
		{
			FighterInput input		= gobj.GetComponent<FighterInput>();
			this.animationNameMap	= input.animationNameMap;
			this.radius				= input.radius;
			this.moveSpeed			= input.moveSpeed;
			this.name				= input.name;
			
			this.gobj 				= gobj;
			this.playerNumber		= playerNumber;
			this.currentAction 		= ActionCommand.NONE;
			this.currentMovement	= MoveCommand.NONE;
			this.currentAttack		= null;
			this.cur_hp				= 100.0f;
			this.max_hp				= 100.0f;
			this.cur_meter			= 0.0f;
			this.max_meter			= 100.0f;
			this.status				= new Status_None();
			this.hurtLocation		= Location.NONE;
			this.globalActionTimer	= 0.0f;
			this.movement			= Vector3.zero;
			this.commandLog			= new List<string>();
			
			List<GameObject> hurtboxObjects = input.hurtboxObjects;
			List<GameObject> hitboxObjects	= input.hitboxObjects;
			List<Transform> jointTransforms = input.jointTransforms;
			this.joints = new Dictionary<string, Transform>();
			this.hurtBoxes = new Dictionary<string, HurtBox>();
			this.hitBoxes = new Dictionary<string, HitBox>();
			
			this.InitForwardVector(playerNumber);
			this.InitHitBoxes(hitboxObjects);
			this.InitHurtBoxes(hurtboxObjects);
			this.InitJoints(jointTransforms);
			this.InitStateMachine();
		}
		
		public void DoActionCommand( ActionCommand ac ){
			//Debug.Log(this.name + " Action: " + ac.ToString());
			
			this.currentAction = ac;
			
			if ( ac != ActionCommand.NONE ){
				if ( ac == ActionCommand.BLOCK ){
					this.currentAction = ac;
					this.moveGraph.dispatch("block", this);
				}
				else{
					switch ( ac ){
					case ActionCommand.REGULAR:
						switch ( this.currentMovement ){
						case MoveCommand.FORWARD:
							this.currentAction = ActionCommand.REGULAR_FORWARD;
							break;
						case MoveCommand.BACK:
							this.currentAction = ActionCommand.REGULAR_BACK;
							break;
						case MoveCommand.UP:
							this.currentAction = ActionCommand.REGULAR_UP;
							break;
						case MoveCommand.DOWN:
							this.currentAction = ActionCommand.REGULAR_DOWN;
							break;
						default:
							break;
						}
						break;
					case ActionCommand.SPECIAL:
						if(this.cur_meter >= 100){
							switch ( this.currentMovement ){
							case MoveCommand.FORWARD:
								this.currentAction = ActionCommand.SPECIAL_FORWARD;
								break;
							case MoveCommand.BACK:
								this.currentAction = ActionCommand.SPECIAL_BACK;
								break;
							case MoveCommand.UP:
								this.currentAction = ActionCommand.SPECIAL_UP;
								break;
							case MoveCommand.DOWN:
								this.currentAction = ActionCommand.SPECIAL_DOWN;
								break;
							default:
								break;
							}
						}
						else
							this.currentAction = ActionCommand.NONE;
						break;
					case ActionCommand.UNIQUE:
						switch ( this.currentMovement ){
						case MoveCommand.FORWARD:
							this.currentAction = ActionCommand.UNIQUE_FORWARD;
							break;
						case MoveCommand.BACK:
							this.currentAction = ActionCommand.UNIQUE_BACK;
							break;
						case MoveCommand.UP:
							this.currentAction = ActionCommand.UNIQUE_UP;
							break;
						case MoveCommand.DOWN:
							this.currentAction = ActionCommand.UNIQUE_DOWN;
							break;
						default:
							break;
						}
						break;
					default:
						break;
					}
					//Debug.Log(this.currentAction.ToString());
					//Debug.Break();
					if (this.currentAction != ActionCommand.NONE)
						this.moveGraph.dispatch("attack", this);
				}
			}
		}
		
		public void DoMoveCommand( MoveCommand mc ){
			//Debug.Log(this.name + " Move: " + mc.ToString());
			this.currentMovement = mc;
			if (mc != MoveCommand.NONE){
				if (mc == MoveCommand.FORWARD || mc == MoveCommand.BACK){
					this.moveGraph.dispatch("walk", this);
				}
			}
		}
		
		private void InitJoints( List<Transform> joints ){
			foreach (Transform t in joints){
				this.joints[t.name] = t;
			}
		}
		
		private void InitHitBoxes( List<GameObject> hitboxObjects ){
			foreach (GameObject gobj in hitboxObjects){
				HitBox hitbox = new HitBox(this, gobj, false);
				hitbox.TurnOffVisibility();
				hitbox.TurnOffCollider();
				gobj.GetComponent<HitBoxInput>().hitbox = hitbox;
				this.hitBoxes[gobj.name] = hitbox;
			}
		}
		
		private void InitHurtBoxes( List<GameObject> hurtboxObjects ){
			foreach (GameObject gobj in hurtboxObjects){
				HurtBox hurtbox = new HurtBox(this, gobj);
				//hurtbox.TurnOffVisibility();
				gobj.GetComponent<HurtBoxInput>().hurtbox = hurtbox;
				this.hurtBoxes[gobj.name] = hurtbox;
			}
		}
		
		//describes player forward direction
		public Vector2 GlobalForwardVector {
			get {return globalFowardVector;}
			set {this.globalFowardVector=value;}
		}
		
		private void InitForwardVector(int player)
		{
			globalFowardVector = (player==1 ? new Vector3(1,0,0) : new Vector3(-1,0,0));
			this.localForwardVector = new Vector3 (0, 0, 1);
		}
		
		public HitBox FindFreeHitBox(){
			int count = 1;
			foreach ( HitBox h in this.hitBoxes.Values ){
				if ( !h.inUse ){
					h.inUse = true;
					return h;
				}
				count++;
			}
			
			GameObject gobj = (GameObject)GameObject.Instantiate( Resources.Load( "Prefabs/Hitbox", typeof(GameObject) ), this.gobj.transform.position, Quaternion.identity );
			gobj.transform.parent = this.gobj.transform;
			
			HitBox hitbox = new HitBox( this, gobj, false );
			this.hitBoxes["Hitbox" + count.ToString()] = hitbox;
			gobj.GetComponent<HitBoxInput>().hitbox = hitbox;
			
			return hitbox;
		}
		
		public void AddMovement( Vector3 movement ){
			this.movement += movement;
		}
		
		private void ApplyMovement(){
			if (this.movement.magnitude > 0.001f){
				if ( this.movement.x < 0 ){
					if ( GameManager.CheckCanMoveBackward(this) ){
						this.gobj.transform.position += new Vector3(this.movement.x * this.globalFowardVector.x,
							this.movement.y, this.movement.z);
						this.movement = Vector3.Lerp( this.movement, Vector3.zero, Time.deltaTime * 5 );
						
						if ( this.movement.magnitude < 0.001f ){
							this.movement = Vector3.zero;
						}
					}
				}
				else if (this.movement.x > 0){
					if ( GameManager.CheckCanMoveForward(this) ){
						this.gobj.transform.position += new Vector3(this.movement.x * this.globalFowardVector.x,
							this.movement.y, this.movement.z);
						this.movement = Vector3.Lerp( this.movement, Vector3.zero, Time.deltaTime * 5 );
						
						if ( this.movement.magnitude < 0.001f ){
							this.movement = Vector3.zero;
						}
					}
				}
			}
		}
		
		public void Update()
		{
			this.ApplyMovement();
			this.moveGraph.CurrentState.update(moveGraph, this);
			if (this.cur_meter >= 100f) this.cur_meter = 100f;
			//Debug.Log(this.moveGraph.CurrentState.Name);
		}
		
		public void LogLastCommand(){
			
		}
		
		public void SwitchForwardVector()
		{
			globalFowardVector.x *= -1;
		}
		
		public void TakeDamage(float damage, HurtBox hurtbox, Vector3 direction){
			if (this.moveGraph.CurrentState.Name != "block"){
				this.cur_hp -= damage;
				if (this.cur_hp <= 0){
					this.cur_hp = 0.0f;
					this.moveGraph.dispatch("death", this);
				}
				else{
					this.movement = direction * 0.1f;
					this.hurtLocation = hurtbox.location;
					this.moveGraph.dispatch( "takeDamage", this );
				}
			}
			else{
				this.cur_hp -= damage * 0.1f;
				//The meter will increase when player's attack is block;
				if (this.playerNumber == 1) 
				{
					if(GameManager.P2.Fighter.cur_meter < 100)
						GameManager.P2.Fighter.cur_meter += 5.0f;
				}
				else 
				{	if(GameManager.P1.Fighter.cur_meter < 100)
						GameManager.P1.Fighter.cur_meter += 5.0f;
				}
				this.movement = direction * 0.05f;
				if (this.cur_hp <= 0){
					this.cur_hp = 0.0f;
					this.moveGraph.dispatch("death", this);
				}
				/*
				else{
					this.cur_meter += 5.0f;
					Debug.Log("Player "+this.playerNumber+"current meter "+this.cur_meter);
					this.movement = direction * 0.05f;
				}
				*/
			}
			//Debug.Log(this.name + "\n" + "Damage Taken: " + damage + " Current HP: " + this.cur_hp);
		}
		
		private void InitStateMachine()
		{
			State S_idle 		= new State("idle", new Action_IdleEnter(), new Action_IdleUpdate(), new Action_IdleExit());
			State S_walk 		= new State("walk", new Action_WalkEnter(), new Action_WalkUpdate(), new Action_WalkExit());
			State S_attack 		= new State("attack",new Action_AttackEnter(), new Action_AttackUpdate(), new Action_AttackExit());
			State S_takeDamage 	= new State("takeDamage",new Action_TakeDamageEnter(), new Action_TakeDamageUpdate(),new Action_TakeDamageExit());
			State S_block		= new State("block",new Action_BlockEnter(), new Action_BlockUpdate(),new Action_BlockExit());
			State S_death		= new State("death" , new Action_DeathEnter(), new Action_DeathUpdate(),new Action_DeathExit());
			
			Transition T_idle 		= new Transition(S_idle, new Action_None());
			Transition T_walk 		= new Transition(S_walk, new Action_None());
			Transition T_attack 	= new Transition(S_attack, new Action_None());
			Transition T_takeDamage = new Transition(S_takeDamage, new Action_None());
			Transition T_block 		= new Transition(S_block, new Action_None());
			Transition T_death		= new Transition(S_death, new Action_None());
			
			S_idle.addTransition(T_walk, "walk");
			S_idle.addTransition(T_attack,"attack");
			S_idle.addTransition(T_takeDamage,"takeDamage");
			S_idle.addTransition(T_idle,"idle");
			S_idle.addTransition(T_block, "block");
			S_idle.addTransition(T_death, "death");
			
			S_walk.addTransition(T_idle, "idle");
			S_walk.addTransition(T_walk,"walk");
			S_walk.addTransition(T_takeDamage,"takeDamage");
			S_walk.addTransition(T_attack,"attack");
			S_walk.addTransition(T_block, "block");
			S_walk.addTransition(T_death, "death");
			
			S_attack.addTransition(T_idle,"idle");
			S_attack.addTransition(T_takeDamage,"takeDamage");
			S_attack.addTransition(T_death, "death");
			
			S_takeDamage.addTransition(T_idle,"idle");
			S_takeDamage.addTransition(T_takeDamage,"takeDamage");
			S_takeDamage.addTransition(T_death, "death");
			
			S_block.addTransition(T_idle, "idle");
			S_block.addTransition(T_walk, "walk");
			S_block.addTransition(T_death, "death");
			S_block.addTransition(T_block,"block");
			//S_block.addTransition(T_takeDamage,"takeDamage");
			
			this.moveGraph = FSM.FSM.createFSMInstance(S_idle, new Action_None(), this);
		}
	}
}