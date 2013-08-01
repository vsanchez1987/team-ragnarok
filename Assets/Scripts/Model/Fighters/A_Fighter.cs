using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FightGame
{
	public abstract class A_Fighter
	{
		//layer names
		public const int P1_HIT_BOX_LAYER_NUMBER	= 8;
		public const int P2_HIT_BOX_LAYER_NUMBER 	= 9;
		public const int P1_HURT_BOX_LAYER_NUMBER 	= 10;
		public const int P2_HURT_BOX_LAYER_NUMBER 	= 11;
		
		//hitbox names
		public const string HB_FIST_L	= "HB_L_Fist";
		public const string HB_FIST_R	= "HB_R_Fist";
		public const string HB_GLOBAL01	= "HB_Global01";
		
		//input buttons-axes
		public const string P1_AXIS_HORIZONTAL 	= "HorizontalP1";
		public const string P1_AXIS_VERTICAL	= "VerticalP1";
		public const string P1_BTN_REG_ATTACK 	= "RegularAttackP1";
		public const string P1_BTN_UNQ_ATTACK 	= "UniqueAttackP1";
		public const string P1_BTN_SPC_ATTACK 	= "SpecialAttackP1";
		public const string P1_BTN_BLOCK 		= "BlockP1";
		
		public const string P2_AXIS_HORIZONTAL 	= "HorizontalP2";
		public const string P2_AXIS_VERTICAL	= "VerticalP2";
		public const string P2_BTN_REG_ATTACK 	= "RegularAttackP2";
		public const string P2_BTN_UNQ_ATTACK 	= "UniqueAttackP2";
		public const string P2_BTN_SPC_ATTACK 	= "SpecialAttackP2";
		public const string P2_BTN_BLOCK 		= "BlockP2";
/*
			<<<<<<< HEAD

=======
		
>>>>>>> wolfe
				 */
		protected const float moveCoolDown = 2;
		public float lastAttackTimer = 0;
		protected string name;
		protected GameObject gobj;
		protected A_Status status;
		protected FSMContext moveGraph;
		public int playerNumber;
		Vector3 globalFowardVector;
		public bool gothit = false;
		
		//public List<HitBox> hitBoxes;
		//public List<HitBoxInfo> hitBoxCollisionsToBeProcessed;
		
		// NEW HITBOX CODE 7/23
		GameObject gob;
		Dictionary<string,HitBox> hitBoxes; //<gobName,hitBox>
		List<GameObject> hurtBoxes;
		public List<HitBoxCollisionInfo> HitBoxCollisions;
		
		List<Projectile> projectiles; //activeProjectiles
		List<string> joints;
		int numProjectilesMax;
		// ***
		
		public Dictionary<string,A_Attack> attacklist;	//hieu add, tom modify to add <string,A_attack>
		public A_Attack currentAttack;
		
		protected A_Fighter(int playerNumber, GameObject gobj)
		{
			this.playerNumber = playerNumber;
			this.hAxis = (playerNumber == 1 ? P1_AXIS_HORIZONTAL : P2_AXIS_HORIZONTAL);
			this.vAxis = (playerNumber == 1 ? P1_AXIS_VERTICAL : P2_AXIS_VERTICAL);
			this.unqBtn = (playerNumber == 1 ? P1_BTN_UNQ_ATTACK : P2_BTN_UNQ_ATTACK);
			this.atkBtn = (playerNumber == 1 ? P1_BTN_REG_ATTACK : P2_BTN_REG_ATTACK);
			this.blckBtn = (playerNumber == 1 ? P1_BTN_BLOCK : P2_BTN_BLOCK);
			this.spcBtn = (playerNumber == 1 ? P1_BTN_SPC_ATTACK : P2_BTN_SPC_ATTACK);
			InitForwardVector(playerNumber);
			//hitBoxes = new List<HitBox>();
			//hitBoxCollisionsToBeProcessed = new List<HitBoxInfo>();
			//AddHitBoxesGroupedInPrefab(gobj);
			
			// NEW HITBOX CODE 7/23
			hitBoxes = new Dictionary<string, HitBox>();
			hurtBoxes = new List<GameObject>();
			HitBoxCollisions = new List<HitBoxCollisionInfo>();
			projectiles = new List<Projectile>();
			joints = new List<string>();
			this.gob = this.gobj = gobj;
			//hieu add
			this.currentAttack = new Attack_None(this,0,0,0);
			//
			
			AssignHurtBoxes(this.gob);
			AssignJoints();
			InitHitBoxes();
			InitStateMachine();
			
			
			
			ShowInActiveHitBoxes(true); //should be taken out, used to see hitboxes
			ShowActiveHitBoxes(true);
			// ***
			
			attacklist = new Dictionary<string, A_Attack>();
		}
		
		#region accessors
		public string Name
		{
			get{ return this.name; }
			set{ this.name = value; }
		}
		
		public GameObject GetGOB()	//hieu add
		{
			return this.gobj;
		}
		
		// NEW HITBOX CODE 7/23
		void AssignJoints()
		{
			// *** NAMING CONVENTION FOR HITBOXES
			//  ================================================
			//  HERE WE ESTABLISH NAMING CONVENTIONS FOR JOINTS/HITBOXES
			//  THESE MUST MATCH PREFAB HITBOXES ON CHARACTERS
			//  PROJECTILE HITBOXES MUST BE NAMED "HB_Projectile_"X  where X is the number 0 through max
			//  ==============================================
			joints.Add("HB_Fist_L");
			joints.Add("HB_Fist_R");
			joints.Add("HB_Foot_L");
			joints.Add("HB_Foot_R");
			numProjectilesMax = 2;
		}
		// ***
		
		void AssignHurtBoxes(GameObject gob)
		{
		
			foreach (Transform t in gob.transform)
			{
			
				if (t.name == "HurtBox")
				{
					hurtBoxes.Add(t.gameObject);
					t.gameObject.layer = (this.playerNumber == 1 ? A_Fighter.P1_HURT_BOX_LAYER_NUMBER: A_Fighter.P2_HURT_BOX_LAYER_NUMBER);
					return;
				}
				AssignHurtBoxes(t.gameObject);// <--recursively go through child tree
				
			}
		}
		
		public void SetCurrentAttack()
		//This function will set the current Attack, base on the input from controller
		//It will look up in the dictionary, attacklist, which is created in each Fighter class(ex: Fighter_Odin.cs)
		//Note: _this function shouldn't be called under Update()
		//		because the controllerDirection variable will change during Update time.
		//		_During Update(), you can access the variable currentAttack.
		{
			string attackType=controllerDirection;
			if(attackPressed) attackType ="1"+controllerDirection;	//define the key base on attack type
			if(uniquePressed) attackType ="2"+controllerDirection;
			if(this.attacklist.ContainsKey(attackType))
			{
				this.currentAttack = this.attacklist[attackType];
			}
			else this.currentAttack = new Attack_None(this,0,0,0);
		}
		
		
		//describes player forward direction
		public Vector3 ForwardVector
		{
			get {return globalFowardVector;}
			set {this.globalFowardVector=value;}
		}
		#endregion
		
		#region input related Data
		public bool attackPressed, uniquePressed, specialPressed, blockPressed;
		// true if player is pressing button
		
		public Vector2 inputDirection;
		// Direction pressed on analog stick in vector format
		
		public string controllerDirection;
		// Direction pressed on analog stick in 8-directional string format
		// returns  "forward","forwardUp", "up",backUp","back","backDown","down",forwardDown" or "invalid"
		
		public string hAxis, vAxis;
		// Vertical and Horizontal controller axes declared in Unity's input preferences
		
		public string atkBtn, unqBtn,spcBtn,blckBtn;
		// attack button & unique attack button declared in Unity's input preferences
		#endregion
		
		private void InitForwardVector(int player)
		{
			//DEFINE PLAYER FORWARD VECTORS HERE (1,0,0) FOR X AND (0,0,1) FOR Z
			globalFowardVector = (player==1 ? new Vector3(1,0,0) : new Vector3(-1,0,0));
		}
		
		public void Update()
		{
			moveGraph.CurrentState.update(moveGraph, this);
			lastAttackTimer+=Time.deltaTime;
			//hieu add
			this.gothit=false;
			//hieu add
			// NEW HITBOX CODE 7/23
			UpdateHitBoxes();
			// ***

		}
		
		// NEW HITBOX CODE 7/23
		public void ShowActiveHitBoxes(bool setting)
		{
			foreach (KeyValuePair<string,HitBox> kvp in hitBoxes)
			{
				kvp.Value.displayWhenActive = setting;
			}
		}
		
		public void ShowInActiveHitBoxes(bool setting)
		{
			foreach (KeyValuePair<string,HitBox> kvp in hitBoxes)
			{
				kvp.Value.displayWhenNotActive = setting;
			}
		}
		
		public void SendHitBoxInstructions(A_Attack attack)
		{
			foreach(HB_Instruction hbi in attack.hb_instructions)
			{
				if(hbi.jointName != "projectile")
				{
					GetHitBox(hbi.jointName).SendInstruction(hbi);
				}
				else if (hbi.jointName == "projectile")
				{
					GetFreeProjectileHitBox().SendInstruction(hbi);
				}
			}
		}
		
		public HitBox GetHitBox(string name)
		{
			foreach (KeyValuePair<string,HitBox> kvp in hitBoxes)
			{
				if(kvp.Value.GetName() == name)
					return kvp.Value;
			}
			return null;
		}
		
		void InitHitBoxes()
		{
			//Joints
			foreach(string joint in joints)
			{
				//hitBoxes.Add(joint,new HitBox(this,gob.transform.Find("HitBoxes").transform.Find(joint).gameObject,false));
				AddHitBoxesGroupedInPrefab(gob, joint,false);
			}
			
			//Projectiles
			for (int i=0 ; i < numProjectilesMax ; i++)
			{
				string name = "HB_Projectile_"+i;
				
				hitBoxes.Add(name , new HitBox(this,gob.transform.Find("ProjectileHitBoxes").transform.Find(name).gameObject, true));
				gob.transform.Find("ProjectileHitBoxes").transform.Find(name).parent=null;
			}
		}
		
		
		private void AddHitBoxesGroupedInPrefab(GameObject gob, string joint, bool isProjectile)
		{
			foreach (Transform t in gob.transform)
			{
				if (t.name == joint)
				{
					//AssignHitBoxLayer(t);
					hitBoxes.Add(joint,new HitBox(this,t.gameObject,isProjectile));
					return;
				}
				AddHitBoxesGroupedInPrefab(t.gameObject,joint,isProjectile);// <--recursively go through child tree
			}
		}
		
		
		void UpdateHitBoxes()
		{
			foreach (KeyValuePair<string,HitBox> kvp in hitBoxes)
			{
				kvp.Value.Update();
			}
		}
		
		void StopActiveHitBoxes()
		{
			foreach (KeyValuePair<string,HitBox> kvp in hitBoxes)
			{
				if(kvp.Value.active)
				{
					kvp.Value.DeActivate();
				}
			}
		}
		
		HitBox GetFreeProjectileHitBox()
		{
			foreach (KeyValuePair<string,HitBox> kvp in hitBoxes)
			{
				if(kvp.Value.isProjectile && !kvp.Value.active)
				{
					return kvp.Value;
				}
			}
			Debug.Log("Need More Projectiles!");
			return null;
		}
		
		// ***
		
		public void Dispatch(string eventName){
			moveGraph.dispatch(eventName, this);
		}
		
		public void SwitchForwardVector()
		{
			globalFowardVector *= -1;
		}
		
		public bool CanAttack()
		{
			return lastAttackTimer>moveCoolDown;
		}
		
		
		void InitStateMachine()
		{
			State S_idle = new State("idle", new Action_IdleEnter(), new Action_IdleUpdate(), new Action_IdleExit());
			State S_walkForward = new State("walkForward", new Action_WalkForwardEnter(), new Action_WalkForwardUpdate(), new Action_WalkForwardExit());
			State S_attack = new State("attack",new Action_AttackEnter(), new Action_AttackUpdate(), new Action_AttackExit());
			State S_gothit = new State("gothit",new Action_GothitEnter(), new Action_GothitUpdate(),new Action_GothitExit());
			//State S_unique = new State("unique",new Action_UniqueEnter(), new Action_UniqueUpdate(), new Action_UniqueExit());
			
			Transition T_idle = new Transition(S_idle, new Action_None());
			Transition T_walkForward = new Transition(S_walkForward, new Action_None());
			Transition T_attack = new Transition(S_attack, new Action_None());
			Transition T_gothit = new Transition(S_gothit, new Action_None());
			//Transition T_unique = new Transition(S_unique,new Action_None());
			
			S_idle.addTransition(T_walkForward, "walkForward");
			S_idle.addTransition(T_attack,"attack");
			S_idle.addTransition(T_gothit,"gothit");
			//S_idle.addTransition(T_unique,"unique");
			S_idle.addTransition(T_idle,"idle");
			
			S_walkForward.addTransition(T_idle, "idle");
			S_walkForward.addTransition(T_walkForward,"walkForward");
			S_walkForward.addTransition(T_gothit,"gothit");
			
			S_attack.addTransition(T_idle,"idle");
			S_attack.addTransition(T_gothit,"gothit");
			
			S_gothit.addTransition(T_idle,"idle");
			S_gothit.addTransition(T_gothit,"gothit");
			
			//S_attack.addTransition(T_walkForward,"walkForward");
			
			//S_unique.addTransition(T_idle,"idle");
			this.moveGraph = new FSMContext(S_idle, new Action_None(),this);
		}
		
		
		#region HitBox Functions
		/*
		public void AssignHitBoxCollisions()
		// adds collision info to hitBoxCollisionsToBeProcessed
		{
			foreach (HitBox hb in hitBoxes)
			{
				if(hb.getHitBoxInfo()!=null)
				{
					hitBoxCollisionsToBeProcessed.Add(hb.getHitBoxInfo());
					Debug.Log(hb.getHitBoxInfo().location);
					hb.removeHitBoxInfo();
					
				}
			}
		}
		*/
		
		/*
		private void AddHitBoxesGroupedInPrefab(GameObject gobj)
		{
			// add hitboxes with "HB_" prefix that are children of A_figher prefab
			foreach (Transform t in gobj.transform)
			{
				AddHitBoxesGroupedInPrefab(t.gameObject); // <--recursively go through child tree
				int length = t.name.Length;
				int num = 0;
				int match = 0;
				foreach (char c in t.name)
				{
					if ( c == 'H' && num==0)
					{
						match+=1;
					}
					if (c=='B' && num==1)
					{
						match+=1;
					}
					if (c=='_' && num==2 && match==2)
					{
						AssignHitBoxLayer(t);
						hitBoxes.Add(new HitBox(t.name));
					}
					num++;
				}
			}
		}
		*/
		
		/*
		private void AssignHitBoxLayer(Transform t)
		{
			if(playerNumber==1)
			{
				t.gameObject.layer=P1_HIT_BOX_LAYER_NUMBER;
			}
			else if(playerNumber==2)
			{
				t.gameObject.layer=P2_HIT_BOX_LAYER_NUMBER;
			}
		}
		*/
		
		
		#endregion
			
	}
}