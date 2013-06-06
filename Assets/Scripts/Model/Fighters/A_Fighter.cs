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
		protected int playerNumber;
		protected Vector2 forwardVector;
		
		public List<HitBox> hitBoxes;
		public List<HitBoxInfo> hitBoxCollisionsToBeProcessed;
		
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
			hitBoxes = new List<HitBox>();
			hitBoxCollisionsToBeProcessed = new List<HitBoxInfo>();
			AddHitBoxesGroupedInPrefab(gobj);
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
			else this.currentAttack = null;
		}
		
		
		//describes player forward direction
		public Vector2 ForwardVector {
			get {return forwardVector;}
			set {this.forwardVector=value;}
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
			forwardVector = (player==1 ? new Vector2(1,0) : new Vector2(-1,0));
		}
		
		public void Update()
		{
			moveGraph.CurrentState.update(moveGraph, null);
			lastAttackTimer+=Time.deltaTime;
			UpdateHitBoxes();
			AssignHitBoxCollisions();
		}
		
		public void Dispatch(string eventName){
			moveGraph.dispatch(eventName, null);
		}
		
		public void SwitchForwardVector()
		{
			forwardVector.x *= -1;
		}
		
		public bool CanAttack()
		{
			return lastAttackTimer>moveCoolDown;
		}
		
		#region HitBox Functions
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
		
		public void ShowHitBoxes(bool b)
		{
			foreach (HitBox hb in hitBoxes)
			{
				if(!hb.VisiblityLocked())
					hb.SetVisiblity(b);
			}
		}
		
		public void ShowHitBoxesAlwaysOn(bool b)
		{
			foreach (HitBox hb in hitBoxes)
			{
				hb.LockVisiblity(b);
			}
		}
		
		public HitBox GetHitBox(string hitBoxName)
		{
			foreach (HitBox hb in hitBoxes)
			{
				if (hb.GOB.name==hitBoxName)
				{
					return hb;
				}
			}
			return null;
		}
		
		public void UpdateHitBoxes()
		{
			foreach (HitBox hb in hitBoxes)
			{
				hb.Update();
			}
		}
		
		public void SendHitBoxMessage(HitBoxInstruction msg)
		{
			HitBox hb = GetHitBox(msg.HB_recip_name);
			if (hb!=null)
			{
				hb.sendInstruction(msg);
			}
		}
		#endregion
			
	}
}