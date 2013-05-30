using UnityEngine;
using System.Collections.Generic;
using System;
using FightGame;
using FSM;

namespace FightGame{
	public class GameModel {
		private static GameModel instance = new GameModel();
		
		private A_Fighter p1;
		private A_Fighter p2;
		private Dictionary<string, A_Effect> Effects;
		private Dictionary<string, A_Attack> Attacks;
		//private Dictionary<string, A_Fighter> fighterlist;
		
	    // make sure the constructor is private, so it can only be instantiated here
	    private GameModel() {
			p1 = null;
			p2 = null;
			Effects = new Dictionary<string, A_Effect>();
			Attacks = new Dictionary<string, A_Attack>();
			//fighterlist.Add("Odin",Fighter_Odin);
			//fighterlist.Add("Basic",Fighter_Basic);
	    }
		
		public static A_Fighter P1{
			get { return instance.p1; }
			set { instance.p1 = value; }
		}
		
		public static A_Fighter P2{
			get { return instance.p2; }
			set { instance.p2 = value; }
		}
		
		public static A_Effect GetEffect(string effect){
			return instance.Effects[effect];
		}
		
		public static A_Attack GetAttack(string attack){
			return instance.Attacks[attack];
		}
		
		public static void CreateFighter(string fighter){ // let's use delegates 
			GameObject player1 = GameObject.Instantiate( Resources.LoadAssetAtPath("Assets/Prefabs/" + fighter + ".prefab", typeof(GameObject)) ) as GameObject;
			//instance.p1 = instance.fighterlist[fighter];
			
			switch (fighter)
			{
				case("Fighter_Basic"):
					instance.p1 = new Fighter_Basic(player1,1);
					break;
				case("Fighter_Odin"):
					instance.p1 = new Fighter_Odin(player1,1);
					break;
				case("Fighter_Heacy"):
					instance.p1 = new Fighter_Heacy(player1,1);
					break;
			}
			
		}
	}
}