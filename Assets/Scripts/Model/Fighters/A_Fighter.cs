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
		protected Vector2 						globalFowardVector;
		
		public	string							name;
		public 	GameObject 						gobj;
		public 	Dictionary<string, Transform> 	joints;
		public 	Dictionary<string, HurtBox> 	hurtBoxes;
		public 	Dictionary<string, HitBox> 		hitBoxes;
		public	bool							gothit;
		public	int								playerNumber;
		
		public AttackCommand 					currentAttack;
		public MoveCommand						currentMovement;
		public Dictionary<AttackCommand, A_Attack> 	attacksCommandMap;
		public Dictionary<FighterAnimation, string> animationNameMap;
		
		public A_Fighter(GameObject gobj, int playerNumber)
		{
			FighterInput input		= gobj.GetComponent<FighterInput>();
			this.gobj 				= gobj;
			this.playerNumber		= playerNumber;
			this.currentAttack 		= AttackCommand.NONE;
			this.currentMovement	= MoveCommand.NONE;
			this.status				= new Status_None();
			this.animationNameMap	= input.animationNameMap;
			
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
		
		public void DoAttackCommand( AttackCommand ac ){
			Debug.Log(this.name + " Attack: " + ac.ToString());
			this.currentAttack = ac;
			if (ac != AttackCommand.NONE)
				this.moveGraph.dispatch("attack", this);
		}
		
		public void DoMoveCommand( MoveCommand mc ){
			Debug.Log(this.name + " Move: " + mc.ToString());
			this.currentMovement = mc;
			if (mc != MoveCommand.NONE){
				this.moveGraph.dispatch("walkForward", this);
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
		public Vector2 ForwardVector {
			get {return globalFowardVector;}
			set {this.globalFowardVector=value;}
		}
		
		private void InitForwardVector(int player)
		{
			globalFowardVector = (player==1 ? new Vector2(1,0) : new Vector2(-1,0));
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
		
		public void Update()
		{
			this.moveGraph.CurrentState.update(moveGraph, this);
		}
		
		public void SwitchForwardVector()
		{
			globalFowardVector.x *= -1;
		}
		
		public void TakeDamage(float damage){
			Debug.Log(this.name + " - Damage Taken: " + damage);
		}
		
		private void InitStateMachine()
		{
			State S_idle = new State("idle", new Action_IdleEnter(), new Action_IdleUpdate(), new Action_IdleExit());
			State S_walkForward = new State("walkForward", new Action_WalkForwardEnter(), new Action_WalkForwardUpdate(), new Action_WalkForwardExit());
			State S_attack = new State("attack",new Action_AttackEnter(), new Action_AttackUpdate(), new Action_AttackExit());
			State S_gothit = new State("gothit",new Action_GothitEnter(), new Action_GothitUpdate(),new Action_GothitExit());
			
			Transition T_idle = new Transition(S_idle, new Action_None());
			Transition T_walkForward = new Transition(S_walkForward, new Action_None());
			Transition T_attack = new Transition(S_attack, new Action_None());
			Transition T_gothit = new Transition(S_gothit, new Action_None());
			
			S_idle.addTransition(T_walkForward, "walkForward");
			S_idle.addTransition(T_attack,"attack");
			S_idle.addTransition(T_gothit,"gothit");
			S_idle.addTransition(T_idle,"idle");
			
			S_walkForward.addTransition(T_idle, "idle");
			S_walkForward.addTransition(T_walkForward,"walkForward");
			S_walkForward.addTransition(T_gothit,"gothit");
			S_walkForward.addTransition(T_attack,"attack");
			
			S_attack.addTransition(T_idle,"idle");
			S_attack.addTransition(T_gothit,"gothit");
			
			S_gothit.addTransition(T_idle,"idle");
			S_gothit.addTransition(T_gothit,"gothit");
			
			this.moveGraph = FSM.FSM.createFSMInstance(S_idle, new Action_None(), this);
		}
	}
}