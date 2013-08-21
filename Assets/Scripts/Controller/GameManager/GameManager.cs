using UnityEngine;
using System.Collections.Generic;
using System;
using FightGame;
using FSM;

namespace FightGame{
	public class GameManager {
		private static GameManager instance = new GameManager();
		private GameModel gModel;
		
	    // make sure the constructor is private, so it can only be instantiated here
	    private GameManager() {
			this.gModel = new GameModel();
	    }
		
	    public static GameManager Instance {
	        get { return instance; }
	    }
		
		public static A_Fighter P1{
			get { return instance.gModel.P1; }
			set { instance.gModel.P1 = value; }
		}
		
		public static A_Fighter P2{
			get { return instance.gModel.P2; }
			set { instance.gModel.P2 = value; }
		}
		
		public static void Print(){
			string p1Name = instance.gModel.P1 != null ? instance.gModel.P1.Name : "No Player 1";
			string p2Name = instance.gModel.P2 != null ? instance.gModel.P2.Name : "No Player 2";
			//Debug.Log("Player 1: " + p1Name);
			//Debug.Log("Player 2: " + p2Name);
		}
		
		public static void Update(){
			
			Print();
			
			GameManager.processCollisions();
			
			if (instance.gModel.P1 != null && instance.gModel.P2 != null)
			{
				if (GameManager.P1.cur_hp <= 0)
				{
					//play p2 victory animation
					
					
					//p1 defeat animation
					GameManager.Defeat(GameManager.P1);
				}
				
				if (GameManager.P2.cur_hp <= 0)
				{
					//play p1 victory animation
					
					
					//p2 defeat animation
					GameManager.Defeat(GameManager.P2);
				}
				
			}
			
			if (instance.gModel.P1 != null){
				instance.gModel.P1.Update();
				
			}
			if (instance.gModel.P2 != null){
				instance.gModel.P2.Update();
			}
		}
		
		public static void processCollisions()
		// an example of how to get info with current hitbox system
		{
			if (instance.gModel.P1 != null)
			{
				foreach(HitBoxCollisionInfo hbi in GameManager.P1.HitBoxCollisions)
				{
					hbi.hitPlayer.gotHit = true;
					
					if(hbi.hitPlayer.gotHit && hbi.hitPlayer.blockPressed)
					{
						hbi.hitPlayer.cur_meter+=10;
					}
					
					if(!hbi.hitPlayer.blockPressed)	//if block button is unpressed;
					{	
						hbi.hitPlayer.takeDamage = true;
						hbi.hitPlayer.cur_hp -= hbi.damage;
					}
					//////////
					//Debug.Log("hit player: " +hbi.hitPlayer.playerNumber + " for " +hbi.damage + " damage at " + hbi.location);
				}
				GameManager.P1.HitBoxCollisions.Clear();
			}
			
			if (instance.gModel.P2 != null)
			{
				foreach(HitBoxCollisionInfo hbi in GameManager.P2.HitBoxCollisions)
				{
					hbi.hitPlayer.gotHit = true;
					
					if(hbi.hitPlayer.gotHit && hbi.hitPlayer.blockPressed)
					{
						hbi.hitPlayer.cur_meter+=10;
					}
					
					if(!hbi.hitPlayer.blockPressed)
					{	
						hbi.hitPlayer.takeDamage = true;
						hbi.hitPlayer.cur_hp -= hbi.damage;
					}
					//////////
					//Debug.Log("hit player: " +hbi.hitPlayer.playerNumber + " for " +hbi.damage + " damage at " + hbi.location);
				}
				GameManager.P2.HitBoxCollisions.Clear();
			}
			
			
		}
		
		public static A_Effect GetEffect(string effect){
			return instance.gModel.GetEffect(effect);
		}
		
		public static A_Attack GetAttack(string attack){
			return instance.gModel.GetAttack(attack);
		}
		
		public static void CreateFighter(string fighter){
			instance.gModel.CreateFighter(fighter);
		}
		
		//Hieu added. Test 2 players. Must have a better way to do this
		public static void CreateFighter(string fighter,int playernum){
			instance.gModel.CreateFighter(fighter,playernum);
		}
		
		//Hieu add. Dispatch to defeat function
		public static void Defeat(A_Fighter p)
		{
			p.cur_hp =0;
			p.Dispatch("defeat");
			string animationName =p.GetAnimationName(p,"crumple");
			p.gob.animation[animationName].wrapMode=UnityEngine.WrapMode.ClampForever;
			p.gob.animation.CrossFade(animationName);
		}
		
		
		//Hieu add. 8/20/13
		public static bool CheckCollideAnotherPlayer()
		//this function return true when 2 player collide.
		// Calculate base on fighter.radius
		{
			float distance = Mathf.Abs(GameManager.P1.gob.transform.position.x - 
								GameManager.P2.gob.transform.position.x);
			return distance < (GameManager.P1.radius + GameManager.P2.radius);
		}
		
		public static bool CheckCollideEdge(A_Fighter p, int num)
		//this function return true when player collide with the edge of camera
		//function take 2 argu, fighter and playerNumber.
		// LocEdge is an empty GameObject in game. We can adjust it later
		{
			string edge = null;
			if(num == 1) edge = "EdgeL";
			else if(num == 2) edge = "EdgeR";
			GameObject locEdge = GameObject.FindGameObjectWithTag(edge);
			//need create an empty gameobject in the scene, with the tage EdgeL and EdgeR.
			//open the scene: "animationtest" for more reference
			return Mathf.Abs(p.gob.transform.position.x - locEdge.transform.position.x) < 3;	
		}
		//end add
	}
}