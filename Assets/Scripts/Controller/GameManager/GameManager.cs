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
			if (instance.gModel.P1 != null){
				instance.gModel.P1.Update();
			}
			if (instance.gModel.P2 != null){
				instance.gModel.P2.Update();
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
	}
}