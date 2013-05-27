using UnityEngine;
using System.Collections.Generic;
using System;
using FightGame;
using FSM;

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
		

	}
}