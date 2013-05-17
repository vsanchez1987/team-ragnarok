using UnityEngine;
using System.Collections.Generic;
using System;
using FightGame;
using FSM;

//tybtugbfvgvdfhchyd

namespace FightGame{
	public class GameManager {
		private static GameManager instance = new GameManager();
		
	    // make sure the constructor is private, so it can only be instantiated here
	    private GameManager() {
	    }
		
	    public static GameManager Instance {
	        get { return instance; }
	    }
		
		public static A_Fighter P1{
			get { return GameModel.P1; }
			set { GameModel.P1 = value; }
		}
		
		public static A_Fighter P2{
			get { return GameModel.P2; }
			set { GameModel.P2 = value; }
		}
		
		public static void Print(){
			string p1Name = GameModel.P1 != null ? GameModel.P1.Name : "No Player 1";
			string p2Name = GameModel.P2 != null ? GameModel.P2.Name : "No Player 2";
			//Debug.Log("Player 1: " + p1Name);
			//Debug.Log("Player 2: " + p2Name);
		}
		
		public static void Update(){
			Print();
			if (GameModel.P1 != null){
				GameModel.P1.Update();
			}
		}
		
		public static A_Effect GetEffect(string effect){
			return GameModel.GetEffect(effect);
		}
		
		public static A_Attack GetAttack(string attack){
			return GameModel.GetAttack(attack);
		}
		
		public static void CreateFighter(string fighter){
			GameModel.CreateFighter(fighter);
		}
		
		/* struct hitboxMessage
		 * {
		 * 		Vec3 startlocation
		 * 		Vec3 velocity
		 * 		float startTime  
		 * 		float endTime
		 * 		float damageintensity
		 * }
		 * 
		 * class HitBox()
		 * {
		 * 
		 * 		GOB game object
		 * 		list<HBM> inbox;
		 * 
		 * 		GetActiveMessages()
		 * 		{
		 * 			list<HBM> activemsgs
		 * 			foreach HBM msg in inbox
		 * 			{
		 * 				if msg.starttime < current time < msg.endtime
		 * 					activemsgs.add(msg)
		 * 				return activemsgs;
		 * 			}
		 * 		}
		 * }
		 * 
		 * class HitboxSystem()
		 * {
		 * 		list<hitboxes> p1boxes;
		 * 		list<hitboxes> p2boxes;
		 * 
		 * 		set/getHitboxes(player p){}
		 * 
		 * 		bool  checkIFHit(player p)
		 * 		{
	 * 				foreach HB p1 or p2 hiboxes
		 * 			return if hit.	
		 * 		}
		 * 
		 *		
		 * 		UpdateHitBoxes()
		 * 		{
		 * 			foreach HitBox in p1/p2boxes
		 * 			{
		 * 				foreach HitBoxMessage in HitBox()
		 * 				{
		 * 					move hitboxes with velocity()
		 * 					disable hitboxes with collisions()
		 * 					disable hitboxes with all expired messages()
		 * 					removeExpired hitboxMessages()
		 * 				}
		 * 			}
		 * 		}
		 * 
		 * 		//used by game manager to perform attacks
		 * 		SendMessage(string hitBoxName, list<hitboxMesage> HBMList, float attackTime)
		 * 		{
		 * 			
		 * 		}
		 * 
		 * 
		 * }
		 * 
		 * DragonPunch:A_Attack
		 * {
		 * 		string name "DragonPunch";
		 * 		attacktime = getLengthOfAnimation();
		 * 		
		 * 
		 * 		//Fist HitBox
		 * 		HBM fist_h1;
		 * 		fist_h1.damageOnTime = 0 * attacktime;
		 * 		fist_h1.damageOffTime = .1 * attacktime;
		 * 		fist_h1.damage = 30;
		 * 
		 * 		HBM fist_h2;
		 * 		fist_h2.damageOnTime = .3 * attacktime;
		 * 		fist_h2.dmageOffTime = .4 * attacktime;
		 * 		fist_h2.damage = 40;
		 * 
		 * 		list<HitboxMessage> FistHitBoxMessages;
		 * 
		 * 
		 * 		//Global HitBox --these are floating hitboxes for projectiles etc.
		 * 		HBM global_h1;
		 * 		global_h1.damageOnTime = .6 * attacktime;
		 * 		global_h1.dmageOffTime= .7 * attacktime;
		 * 		global_h1.damage = 10;
	     * 		global_h1.velocity = (p1.forward * 3, 0);	

		 * 		list<HitboxMessage> Gloabl1HitBoxMessages;
		 * 
		 * 
		 * 		DragonPunch()
		 * 		{
		 * 			FistHitBoxMessages = new list<hitboxmessages>;
		 * 			FistHitBoxMessages.add(fist_h1,first_h2);
		 * 
		 * 			Gloabl1HitBoxMessages = new list<hitboxmessages>;
		 * 			Gloabl1HitBoxMessages.add(gloab_h1);
		 * 		}
		 * 		
		 * 		Execute()
		 * 		{
		 * 			gameManger.HitboxSystem.SendMessage("Fist", FistHitBoxMessages, attacktime);
		 * 			gameManger.HitboxSystem.SendMessage("Global", Gloabl1HitBoxMessages, attacktime);
		 * 		}
		 * }
		 * 
		 * Fighter_1
		 * {
		 * 		A_attack Dragonpunch;
		 * 
		 *  	void attack()
		 * 		{
		 * 			Dragonpunch.execute();
		 * 		}
		 * }
		 * 
		 * so to execute the attack we call
		 * gameManager.P1.Attack("DragonPunch");
		 * 
		 * /
		 * */
	}
}