using UnityEngine;
using System.Collections.Generic;
using System;
using FightGame;
using FSM;

namespace FightGame{
	public class GameManager {
		private static GameManager instance = new GameManager();
		private GameModel gModel;
		
	    private GameManager() {
			this.gModel = new GameModel();
	    }
		
	    public static GameManager Instance {
	        get { return instance; }
	    }
		
		public static Player P1{
			get { return instance.gModel.p1; }
		}
		
		public static Player P2{
			get { return instance.gModel.p2; }
		}
		
		public static FightCamera Camera{
			get { return instance.gModel.camera; }
		}
		
<<<<<<< HEAD
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
=======
		public static UI_Script UI{
			get { return instance.gModel.ui; }
		}
		
		public static float LeftBoundary {
			get { return instance.gModel.leftBoundary; }
		}
		
		public static float RightBoundary {
			get { return instance.gModel.rightBoundary; }
		}
		
		public static void Restart(){
			instance.gModel.p1.RestartFighter();
			instance.gModel.p2.RestartFighter();
		}
		
		public static void ProcessInput(){
			foreach (Player p in instance.gModel.players){
				//Debug.Log("Player " + p.PlayerNumber);
				if (p.Fighter != null){
					int moveCommand = p.controls.GetMoveCommand();
					int actionCommand = p.controls.GetActionCommand();
					
					p.DoMoveCommand(moveCommand);
					p.DoActionCommand(actionCommand);
>>>>>>> fd2511965e41334cb3fce993bcedcd531205f267
				}
			}
		}
		
		public static void Update(){
			if (instance.gModel.p1 != null){
				instance.gModel.p1.Update();
			}
			if (instance.gModel.p2 != null){
				instance.gModel.p2.Update();
			}
			if (instance.gModel.camera != null){
				instance.gModel.camera.Update();
			}
			
			if (instance.gModel.ui.hurtboxOn){
				GameObject[] hurtboxes = GameObject.FindGameObjectsWithTag("HurtBox");
				foreach (GameObject hurtbox in hurtboxes){
					if (!hurtbox.renderer.enabled){
						hurtbox.renderer.enabled = true;
					}
				}
			}
			else{
				GameObject[] hurtboxes = GameObject.FindGameObjectsWithTag("HurtBox");
				foreach (GameObject hurtbox in hurtboxes){
					if (hurtbox.renderer.enabled){
						hurtbox.renderer.enabled = false;
					}
				}
			}
		}
		
		public static void CreateFighter(string fighter, int playerNum)
		{
<<<<<<< HEAD
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
=======
			Player player = instance.gModel.players[playerNum - 1];
			GameObject locator = GameObject.FindGameObjectWithTag("LocatorP" + playerNum.ToString());
			
			player.InstantiateFighter(fighter, locator.transform.position, locator.transform.rotation);
		}
		
		public static float GetPlayersDistance(){
			return Mathf.Abs(instance.gModel.p1.Fighter.gobj.transform.position.x - instance.gModel.p2.Fighter.gobj.transform.position.x);
		}
		
		public static bool CheckCanMoveForward(A_Fighter fighter){
			if ( GameManager.P1.Fighter != null && GameManager.P2.Fighter != null ){
				if (GameManager.GetPlayersDistance() > GameManager.P1.Fighter.radius + GameManager.P2.Fighter.radius){
					if (fighter.GlobalForwardVector.x == 1){
						if (GameManager.CheckWithinRightBoundary(fighter)){
							return true;
						}
					}
					else if (fighter.GlobalForwardVector.x == -1){
						if (GameManager.CheckWithinLeftBoundary(fighter)){
							return true;
						}
>>>>>>> fd2511965e41334cb3fce993bcedcd531205f267
					}
				}
			}
			return false;
		}
		
		public static bool CheckCanMoveBackward(A_Fighter fighter){
			if ( GameManager.P1.Fighter != null && GameManager.P2.Fighter != null ){
				if (GameManager.GetPlayersDistance() < GameManager.Camera.maxDistance){
					if (fighter.GlobalForwardVector.x == 1){
						if (GameManager.CheckWithinLeftBoundary(fighter)){
							return true;
						}
					}
					else if (fighter.GlobalForwardVector.x == -1){
						if (GameManager.CheckWithinRightBoundary(fighter)){
							return true;
						}
					}
				}
			}
			return false;
		}
		
		public static Player GetOpponentPlayer(int playerNumber){
			return playerNumber == 1 ? instance.gModel.p2 : instance.gModel.p1;
		}
		
		private static bool CheckWithinLeftBoundary(A_Fighter fighter){
			return fighter.gobj.transform.position.x > GameManager.LeftBoundary;
		}
		
		private static bool CheckWithinRightBoundary(A_Fighter fighter){
			return fighter.gobj.transform.position.x < GameManager.RightBoundary;
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