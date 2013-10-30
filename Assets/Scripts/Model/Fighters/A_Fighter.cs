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
		protected Vector3 						globalForwardVector;
		
		public	string							name;
		public 	GameObject 						gobj;
		//public  GameObject 						particleHolder1,particleHolder2;
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
		public	float							extraDamage;
		//public	bool							specialEffect;
		
		private	int								onHitTimer;
		private bool 							onHitStarted;
		
		
		public int			 					currentAction;
		public int								currentMovement;
		public A_Attack							currentAttack;
		public List<string>						commandLog;
		public List<A_Buff>						buffs;
		public Dictionary<int, A_Attack> 		actionsCommandMap;
		public Dictionary<FighterAnimation, string> animationNameMap;
		//Hieu add for camera movement when fighter playing special
		public GameObject						cameraTarget;
		public Vector3							disTargettoCamera;
		public float							zoomTime;
		//
		public A_Fighter(GameObject gobj, int playerNumber)
		{
			FighterInput input		= gobj.GetComponent<FighterInput>();
			this.animationNameMap	= input.animationNameMap;
			this.radius				= input.radius;
			this.moveSpeed			= input.moveSpeed;
			this.name				= input.name;
			//Hieu add for camera special movement
			this.cameraTarget		= input.cameraTarget;
			this.disTargettoCamera	= input.disTargettoCamera;
			this.zoomTime			= input.zoomTime;
			//
			this.gobj 				= gobj;
			this.playerNumber		= playerNumber;
			this.currentAction 		= ActionCommand.NONE;
			this.currentMovement	= MoveCommand.NONE;
			this.currentAttack		= null;
			this.cur_hp				= 100.0f;
			this.max_hp				= 100.0f;
			this.cur_meter			= 100.0f;
			this.max_meter			= 100.0f;
			this.status				= null;
			this.hurtLocation		= Location.NONE;
			this.globalActionTimer	= 0.0f;
			this.movement			= Vector3.zero;
			this.commandLog			= new List<string>();
			this.buffs				= new List<A_Buff>();
			this.extraDamage		= 1.0f;
			//this.specialEffect		= false;
			
			this.onHitTimer			= 0;
			this.onHitStarted		= false;
			
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
		
		public void DoActionCommand( int ac ){
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
		
		public void DoMoveCommand( int mc ){
			//Debug.Log(this.name + " Move: " + mc.ToString());
			this.currentMovement = mc;
			if (mc != MoveCommand.NONE){
				if (mc == MoveCommand.FORWARD || mc == MoveCommand.BACK){
					this.moveGraph.dispatch("walk", this);
				}
			}
		}
		
		//describes player forward direction
		public Vector2 GlobalForwardVector {
			get {return globalForwardVector;}
			set {this.globalForwardVector=value;}
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
		
		private void InitForwardVector(int player)
		{
			this.globalForwardVector = (player==1 ? new Vector3(1,0,0) : new Vector3(-1,0,0));
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
			
			GameObject gobj = (GameObject)GameObject.Instantiate( Resources.Load( "Boxes/Hitbox", typeof(GameObject) ), this.gobj.transform.position, Quaternion.identity );
			gobj.transform.parent = this.gobj.transform;
			
			HitBox hitbox = new HitBox( this, gobj, false );
			this.hitBoxes["Hitbox" + count.ToString()] = hitbox;
			gobj.GetComponent<HitBoxInput>().hitbox = hitbox;
			
			return hitbox;
		}
		
		public void AddMovement( Vector3 movement ){
			this.movement += movement;
		}
		
		private void AddGravity(){
			if (this.gobj.transform.position.y > 0){
				this.movement.y += Physics.gravity.y * Time.deltaTime * 0.1f;
				Debug.Log(this.movement.y);
			}
			else{
				this.gobj.transform.position = new Vector3(this.gobj.transform.position.x, 0.0f, this.gobj.transform.position.z);
				this.movement.y = 0.0f;
			}
		}
		
		private void ApplyMovement(){
			if (this.movement.magnitude > 0.001f){
				if ( this.movement.x < 0 ){
					if ( GameManager.CheckCanMoveBackward(this) ){
						this.gobj.transform.position += new Vector3(this.movement.x * this.globalForwardVector.x * Time.deltaTime * 100.0f,
							0.0f, 0.0f);
						this.movement = Vector3.Lerp( this.movement, Vector3.zero, Time.deltaTime * 3 );
						
						if ( this.movement.magnitude < 0.001f ){
							this.movement = Vector3.zero;
						}
					}
				}
				else if (this.movement.x > 0){
					if ( GameManager.CheckCanMoveForward(this) ){
						this.gobj.transform.position += new Vector3(this.movement.x * this.globalForwardVector.x * Time.deltaTime * 100.0f,
							0.0f, 0.0f);
						this.movement = Vector3.Lerp( this.movement, Vector3.zero, Time.deltaTime * 3 );
						
						if ( this.movement.magnitude < 0.001f ){
							this.movement = Vector3.zero;
						}
					}
				}
				this.gobj.transform.position += new Vector3(0.0f, this.movement.y * Time.deltaTime * 100.0f, 0.0f);
			}
		}
		
		private void ReCenter(){
			if (this.gobj.transform.position.z != 0.0f) {
				this.gobj.transform.position = new Vector3(this.gobj.transform.position.x, this.gobj.transform.position.y, 0.0f);
			}
		}
		
		private void UpdateBuffs(){
			foreach (A_Buff buff in this.buffs){
				if (buff.CheckFinished()){
					buff.DeActivate();
					this.buffs.Remove(buff);
					break;
				}
				else{
					buff.Update();
				}
			}
		}
		
		private void ApplyOnHitDelay(){
			if ( this.onHitStarted ){
				this.onHitTimer++;
				if ( this.onHitTimer <= 6 ){
					Time.timeScale = 0.1f;
				}
				else{
					Time.timeScale = 1.0f;
					this.onHitTimer = 0;
					this.onHitStarted = false;
				}
			}
		}
		
		public void Update()
		{
			this.ApplyOnHitDelay();
			this.AddGravity();
			this.ApplyMovement();
			this.moveGraph.CurrentState.update(moveGraph, this);
			this.UpdateBuffs();
			if (this.cur_meter >= 100f) this.cur_meter = 100f;
			if (this.cur_meter <= 0f) this.cur_meter = 0f;
			this.ReCenter();
		}
		
		public void LogLastCommand(){
			
		}
		
		public string CurrentState{
			get { return this.moveGraph.CurrentState.Name; }
		}
		
		public void AddBuff( A_Buff buff ){
			if (!this.buffs.Contains(buff)){
				this.buffs.Add(buff);
			}
		}
		
		public void SwitchForwardVector()
		{
			globalForwardVector.x *= -1;
		}
		
		public void ForceDeath()
		{
			this.moveGraph.dispatch("death", this);
		}
		
		public void Recoil(float recoil){
			this.movement.x = -recoil * Time.deltaTime;	
		}
		
		public void TakeDamage(float damage, HurtBox hurtbox, Vector3 direction, bool knockdown){
			A_Fighter otherFighter = GameManager.GetOpponentPlayer(this.playerNumber).Fighter;
			
			//recoil when target is blocking at wall
			if (otherFighter.currentAttack != null){
				Debug.Log(otherFighter.currentAttack.attackType);
				if((otherFighter.currentAttack.attackType == "melee") && (GameManager.CheckCanMoveBackward(this) == false)){
					otherFighter.Recoil(otherFighter.currentAttack.recoilStrength);
				}
			}

			if(!this.PlayingSpecialAttack()){ //if not playing special attack, it can be hit
				if (this.moveGraph.CurrentState.Name != "block" ||
					GameManager.GetOpponentPlayer(this.playerNumber).Fighter.PlayingSpecialAttack()){
					//these below codes  will execute when current fighter is not in a block state
					// OR the opponent is playing special attack
					//Meaning: if "current fighter  not block" then deal damage 
					//OR "opponent using special" deal damage as well. 
					//There're some side effect. When both fighters use special, no one take damage.
					//and in the future may cause some bugs since the second condition depends on
					//when the special animation ends. I think it's better to encode it in HitBoxInput script
					// OnTriggerEnter(), we already have superhitbox tag, so maybe we can play around with that
					this.cur_hp -= damage;
					if (this.cur_hp <= 0){
						this.cur_hp = 0.0f;
						this.moveGraph.dispatch("death", this);
						
					}
					else{
						GameObject explosion = GameObject.Instantiate(Resources.Load("Particles/Heavy_Explosion", typeof(GameObject)), hurtbox.gobj.transform.position, Quaternion.identity) as GameObject;
						GameObject.Destroy(explosion, 2.0f);
						
						this.onHitTimer = 0;
						this.onHitStarted = true;
						this.movement = direction * 0.05f;
						this.hurtLocation = hurtbox.location;
						
						if(knockdown)
							this.moveGraph.dispatch( "knockDown", this );
						else
							this.moveGraph.dispatch( "takeDamage", this );
					}
				}
				else{
				//execute when this fighter not block, and opponent not use special
					GameObject explosion = GameObject.Instantiate(Resources.Load("Particles/Heavy_Block", typeof(GameObject)), hurtbox.gobj.transform.position, Quaternion.identity) as GameObject;
					GameObject.Destroy(explosion, 2.0f);
					
					this.cur_hp -= damage * 0.25f;
					//The meter will increase when player's attack is block;
					if (this.cur_meter < 100)
						this.cur_meter = Mathf.Clamp( this.cur_meter + 5, 0, 100 );
					
					else{				
						this.movement = direction * 0.025f;
					}

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
				
				if (!GameManager.CheckCanMoveBackward( this ) && 
					(GameManager.GetPlayersDistance() < (GameManager.P1.Fighter.radius + GameManager.P2.Fighter.radius) * 1.2f)){
					
					GameManager.GetOpponentPlayer(this.playerNumber).Fighter.AddMovement( new Vector3(-0.02f, 0.0f, 0.0f) );
					
				}
				
				A_Fighter enemy = GameManager.GetOpponentPlayer(this.playerNumber).Fighter;
				enemy.cur_meter = Mathf.Clamp(enemy.cur_meter + 10.0f, 0, 100);
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
			State S_knockDown	= new State("knockDown", new Action_KnockDownEnter(),new Action_KnockDownUpdate(), new Action_KnockDownExit());
			//State S_invincible	= new State("invincible",new Action_None(),
			
			
			Transition T_idle 		= new Transition(S_idle, new Action_None());
			Transition T_walk 		= new Transition(S_walk, new Action_None());
			Transition T_attack 	= new Transition(S_attack, new Action_None());
			Transition T_takeDamage = new Transition(S_takeDamage, new Action_None());
			Transition T_block 		= new Transition(S_block, new Action_None());
			Transition T_death		= new Transition(S_death, new Action_None());
			Transition T_knockDown	= new Transition(S_knockDown, new Action_None());
			
			S_idle.addTransition(T_walk, "walk");
			S_idle.addTransition(T_attack,"attack");
			S_idle.addTransition(T_takeDamage,"takeDamage");
			S_idle.addTransition(T_idle,"idle");
			S_idle.addTransition(T_block, "block");
			S_idle.addTransition(T_death, "death");
			S_idle.addTransition(T_knockDown,"knockDown");
			
			S_walk.addTransition(T_idle, "idle");
			S_walk.addTransition(T_walk,"walk");
			S_walk.addTransition(T_takeDamage,"takeDamage");
			S_walk.addTransition(T_attack,"attack");
			S_walk.addTransition(T_block, "block");
			S_walk.addTransition(T_death, "death");
			S_walk.addTransition(T_knockDown,"knockDown");
			
			S_attack.addTransition(T_idle,"idle");
			S_attack.addTransition(T_takeDamage,"takeDamage");
			S_attack.addTransition(T_death, "death");
			S_attack.addTransition(T_knockDown,"knockDown");
			
			S_takeDamage.addTransition(T_idle,"idle");
			S_takeDamage.addTransition(T_takeDamage,"takeDamage");
			S_takeDamage.addTransition(T_death, "death");
			S_takeDamage.addTransition(T_knockDown,"knockDown");
			
			S_block.addTransition(T_idle, "idle");
			S_block.addTransition(T_walk, "walk");
			S_block.addTransition(T_death, "death");
			S_block.addTransition(T_block,"block");
			//S_block.addTransition(T_takeDamage,"takeDamage");
			
			S_knockDown.addTransition(T_idle,"idle");
			//S_knockDown.addTransition(T_knockDown,"knockDown");
			
			this.moveGraph = FSM.FSM.createFSMInstance(S_idle, new Action_None(), this);
		}
		/*
		public void CreateParticle(string jointName, string particleName,out GameObject particleHolder,Vector3 offset,Quaternion rotateOffset){
			particleHolder = (GameObject)	GameObject.Instantiate(Resources.Load("Effect/" + particleName, typeof(GameObject)),
											this.joints[jointName].position+offset,rotateOffset);
			particleHolder.transform.parent = this.gobj.transform;
		}
		*/
		public bool PlayingSpecialAttack(){
			//the function return true if the special attack animation is play
			//teh function is called in TakeDamage() above.
			return( this.gobj.animation.IsPlaying(this.animationNameMap[FighterAnimation.SPECIAL_ATTACK]) ||
				this.gobj.animation.IsPlaying(this.animationNameMap[FighterAnimation.SPECIAL_BACK_ATTACK]) ||
				this.gobj.animation.IsPlaying(this.animationNameMap[FighterAnimation.SPECIAL_DOWN_ATTACK]) ||
				this.gobj.animation.IsPlaying(this.animationNameMap[FighterAnimation.SPECIAL_FORWARD_ATTACK]) ||
				this.gobj.animation.IsPlaying(this.animationNameMap[FighterAnimation.SPECIAL_UP_ATTACK]) );
		}
	}
	
}