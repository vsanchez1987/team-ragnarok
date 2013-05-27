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
		public const int P1_HIT_BOX_LAYER_NUMBER = 8;
		public const int P2_HIT_BOX_LAYER_NUMBER = 9;
		public const int P1_HURT_BOX_LAYER_NUMBER = 10;
		public const int P2_HURT_BOX_LAYER_NUMBER = 11;
		
		//hitbox names
		public const string HB_FIST_L="HB_L_Fist";
		public const string HB_FIST_R="HB_R_Fist";
		public const string HB_GLOBAL01="HB_Global01";
		
		public List<HitBox> hitBoxes;
		public List<HitBoxInfo> hitBoxCollisionsToBeProcessed;
		
		public Dictionary<string,A_Attack> attacklist;	//hieu add, tom modify to add <string,A_attack>
		public Dictionary<string,string> uniquelist;	//hieu add
		
		protected const float moveCoolDown = 2;
		
		protected string name;
		protected GameObject gobj;
		protected A_Status status;
		protected FSMContext moveGraph;
		
		public float lastAttackTimer = 0;
		
		#region input related Data
		// bool attackPressed, uniquePressed;
		// 		returns if player is pressing button
		public bool attackPressed, uniquePressed, specialPressed, blockPressed;
		
		// Vector2 forwardVector;
		// 		describes player forward direction
		// 		will change if players swap sides
		protected Vector2 forwardVector;
		public Vector2 ForwardVector {
			get {return forwardVector;}
			set {this.forwardVector=value;}
		}
		
		// Vector2 p1InputDirection;
		//		Direction pressed on analog stick in vector format
		public Vector2 inputDirection;
		
		//	string controllerDirection
		//		Direction prseed on analog stick in 
		//		8-directional string format "up" "backUp" ..
		public string controllerDirection;
		
		//	string hAxis, vAxis;
		//		Vertical and Horizontal controller axes
		//		declared in Unity's input preferences
		public string _hAxis, _vAxis;
		
		//	string _atkBtn, _unqBtn
		//		attack button & unique attack button
		// 		declared in Unity's input preferences
		public string _atkBtn, _unqBtn,_spcBtn,_blckBtn;
		
		// int _playerNumber;
		//		Player number used to establish forward vector initialization
		protected int _playerNumber;
		
		#endregion
		
		protected A_Fighter(int playerNumber, string hAxis, string vAxis, string atkBtn, string unqBtn, string specialBtn, string blockBtn, GameObject gobj)
		{
			_playerNumber = playerNumber;
			_hAxis = hAxis;
			_vAxis = vAxis;
			_unqBtn = unqBtn;
			_atkBtn = atkBtn;
			_blckBtn = blockBtn;
			_spcBtn = specialBtn;
			initForwardVector(_playerNumber);
			hitBoxes = new List<HitBox>();
			hitBoxCollisionsToBeProcessed = new List<HitBoxInfo>();
			InitHitBoxes(gobj);
			attacklist = new Dictionary<string, A_Attack>();
			uniquelist = new Dictionary<string, string>();
		}
		
		
		public void Update(){
			moveGraph.CurrentState.update(moveGraph, null);
			lastAttackTimer+=Time.deltaTime;
			UpdateHitBoxes();
			AssignHitBoxCollisions();
		}
		
		public void AssignHitBoxCollisions()
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
		
		private void InitHitBoxes(GameObject gobj)
		{
			//add hitboxes with HB_ prefix children of prefab
			foreach (Transform t in gobj.transform)
			{
				InitHitBoxes(t.gameObject); //recursively go through child tree
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
			if(_playerNumber==1)
			{
				t.gameObject.layer=P1_HIT_BOX_LAYER_NUMBER;
			}
			else if(_playerNumber==2)
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
		
		public HitBox getHitBox(string hitBoxName)
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
				hb.update();
			}
		}
		
		public void SendHitBoxMessage(HBM msg)
		{
			HitBox hb = getHitBox(msg.HB_recipient);
			if (hb!=null)
			{
				hb.sendMessage(msg);
			}
		}
		
		public bool canAttack()
		{
			return lastAttackTimer>moveCoolDown;
		}
		
		public string Name{
			get{ return this.name; }
			set{ this.name = value; }
		}
		
		public void Dispatch(string eventName){
			moveGraph.dispatch(eventName, null);
		}
		
		private void initForwardVector(int player)
		{
			if (player == 1)
			{
				forwardVector = new Vector2(1,0);
			}
			else if (player == 2)
			{
				forwardVector = new Vector2(-1,0);
			}
		}
		
		public void switchForwardVector()
		{
			forwardVector.x *= -1;
		}
		
		public GameObject GetGOB()	//hieu add
		{
			return this.gobj;
		}
		public string GetCurrentAttack()
		{
			if(this.attacklist.ContainsKey(controllerDirection))
			{
				return this.attacklist[controllerDirection].name;
		
			}
			return null;
		}
		public string GetUniqueAttack()
		{
			if(this.uniquelist.ContainsKey(controllerDirection))
			{
				return this.uniquelist[controllerDirection];
			}
			return null;
		}
	}
}