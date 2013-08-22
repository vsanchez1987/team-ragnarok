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
		
		public static void ProcessInput(){
			foreach (Player p in instance.gModel.players){
				//Debug.Log("Player " + p.PlayerNumber);
				if (p.Fighter != null){
					MoveCommand moveCommand = p.controls.GetMoveCommand();
					//List<ActionCommand> actionCommands = p.controls.GetActionCommands();
					ActionCommand actionCommand = p.controls.GetActionCommand();
					
					p.DoMoveCommand(moveCommand);
					p.DoActionCommand(actionCommand);
					/*foreach (ActionCommand cmd in actionCommands){
						p.DoActionCommand(cmd);
					}*/
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
		}

		public static void CreateFighter(string fighter, int playerNum)
		{
			Player player = instance.gModel.players[playerNum - 1];
			GameObject locator = GameObject.FindGameObjectWithTag("LocatorP" + playerNum.ToString());
			
			player.InstantiateFighter(fighter, locator.transform.position, locator.transform.rotation);
		}
	}
}