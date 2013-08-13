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
		
		public static Player P1{
			get { return instance.gModel.p1; }
		}
		
		public static Player P2{
			get { return instance.gModel.p2; }
		}
		
		public static void Print(){
			string p1Name = instance.gModel.p1.Fighter != null ? instance.gModel.p1.Fighter.Name : "No Player 1 Fighter";
			string p2Name = instance.gModel.p2.Fighter != null ? instance.gModel.p2.Fighter.Name : "No Player 2 Fighter";
		}
		
		public static void ProcessInput(){
			foreach (Player p in instance.gModel.players){
				Debug.Log("Player " + p.PlayerNumber);
				if (p.Fighter != null){
					MoveCommand moveCommand = p.controls.GetMoveCommand();
					List<AttackCommand> attackCommands = p.controls.GetAttackCommands();
					
					if (moveCommand != MoveCommand.NONE){
						p.DoMoveCommand(moveCommand);
					}
					
					foreach (AttackCommand cmd in attackCommands){
						if (cmd != AttackCommand.NONE){
							p.DoAttackCommand(cmd);
						}
					}
				}
			}
		}
		
		public static void Update(){
			
			Print();
			
			GameManager.processCollisions();
			
			if (instance.gModel.p1 != null){
				instance.gModel.p1.Update();
				
			}
			if (instance.gModel.p2 != null){
				instance.gModel.p2.Update();
			}
		}
		
		public static void processCollisions()
		// an example of how to get info with current hitbox system
		{
			if (instance.gModel.p1 != null)
			{
				foreach(HitBoxCollisionInfo hbi in instance.gModel.p1.HitBoxCollisions)
				{
					Debug.Log("hit player: " +hbi.hitPlayer.playerNumber + " for " +hbi.damage + " damage at " + hbi.location);
				}
				GameManager.P1.HitBoxCollisions.Clear();
			}
		}
		/*
		public static A_Effect GetEffect(string effect){
			return instance.gModel.effects[effect];
		}
		
		public static A_Attack GetAttack(string attack){
			return instance.gModel.attacks[attack];
		}

		public static void CreateFighter(string fighter){
			instance.gModel.CreateFighter(fighter);
		}
		
		//Hieu added. Test 2 players. Must have a better way to do this
		public static void CreateFighter(string fighter,int playernum){
			instance.gModel.CreateFighter(fighter,playernum);
		}
		*/
		
		public static void CreateFighter(string fighter, int playerNum)
		{
			Player player = instance.gModel.players[playerNum - 1];
			GameObject locator = GameObject.FindGameObjectWithTag("LocatorP" + playerNum.ToString());
			
			player.InstantiateFighter(fighter, locator.transform.position, locator.transform.rotation);
			
			//instance.p1 = instance.fighterlist[fighter];
			/*
				switch (fighter)
				{
					case("Fighter_Basic"):
						this.p1 = new Fighter_Basic(player,playernum);
						break;
					case("Fighter_Odin"):
						this.p1 = new Fighter_Odin(player,playernum);
						break;
					case("Fighter_Heacy"):
						this.p1 = new Fighter_Heacy(player,playernum);
						break;
				}
			}
			
			if (playernum == 2)
			{
				GameObject character = GameObject.Instantiate( Resources.Load("Prefabs/" + fighter, typeof(GameObject))
															,locatorP2.transform.position,locatorP2.transform.rotation ) as GameObject;
			
				player.transform.localScale = new Vector3(-player.transform.localScale.x,player.transform.localScale.y,player.transform.localScale.z);
			//instance.p1 = instance.fighterlist[fighter];
			
				switch (fighter)
				{
					case("Fighter_Basic"):
						this.p2 = new Fighter_Basic(player,playernum);
						break;
					case("Fighter_Odin"):
						this.p2 = new Fighter_Odin(player,playernum);
						break;
					case("Fighter_Heacy"):
						this.p2 = new Fighter_Heacy(player,playernum);
						break;
				}
			}
			*/
		}
	}
}