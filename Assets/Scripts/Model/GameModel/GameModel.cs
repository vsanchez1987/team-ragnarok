using UnityEngine;
using System.Collections.Generic;
using System;
using FightGame;
using FSM;

namespace FightGame{
	public class GameModel {
		private A_Fighter p1;
		private A_Fighter p2;
		private Dictionary<string, A_Effect> Effects;
		private Dictionary<string, A_Attack> Attacks;
		//private Dictionary<string, A_Fighter> fighterlist;
		
	    // make sure the constructor is private, so it can only be instantiated here
	    public GameModel() {
			p1 = null;
			p2 = null;
			Effects = new Dictionary<string, A_Effect>();
			Attacks = new Dictionary<string, A_Attack>();
			//fighterlist.Add("Odin",Fighter_Odin);
			//fighterlist.Add("Basic",Fighter_Basic);
	    }
		
		public A_Fighter P1{
			get { return this.p1; }
			set { this.p1 = value; }
		}
		
		public A_Fighter P2{
			get { return this.p2; }
			set { this.p2 = value; }
		}
		
		public A_Effect GetEffect(string effect){
			return this.Effects[effect];
		}
		
		public A_Attack GetAttack(string attack){
			return this.Attacks[attack];
		}
		
		
		
		
		public void CreateFighter(string fighter){ // let's use delegates 
			GameObject locatorP1 = GameObject.FindGameObjectWithTag("LocatorP1");
			GameObject locatorP2 = GameObject.FindGameObjectWithTag("LocatorP2");
			GameObject player1 = GameObject.Instantiate( Resources.LoadAssetAtPath("Assets/Prefabs/" + fighter + ".prefab", typeof(GameObject))
															,locatorP1.transform.position,locatorP1.transform.rotation ) as GameObject;
			//instance.p1 = instance.fighterlist[fighter];
			
			switch (fighter)
			{
				case("Fighter_Basic"):
					this.p1 = new Fighter_Basic(player1,1);
					break;
				case("Fighter_Odin"):
					this.p1 = new Fighter_Odin(player1,1);
					break;
				case("Fighter_Heavy"):
					this.p1 = new Fighter_Heavy(player1,1);
					break;
			}
		}
		
		//Hieu added. Test 2 players. Must have a better way to do this
		public void CreateFighter(string fighter,int playernum)
		{
			GameObject locatorP1 = GameObject.FindGameObjectWithTag("LocatorP1");
			GameObject locatorP2 = GameObject.FindGameObjectWithTag("LocatorP2");
			
			if (playernum == 1)
			{
				GameObject player = GameObject.Instantiate( Resources.Load("Prefabs/" + fighter, typeof(GameObject))
															,locatorP1.transform.position,locatorP1.transform.rotation ) as GameObject;
			
			//instance.p1 = instance.fighterlist[fighter];
			
				switch (fighter)
				{
					case("Fighter_Basic"):
						this.p1 = new Fighter_Basic(player,playernum);
						break;
					case("Fighter_Odin"):
						this.p1 = new Fighter_Odin(player,playernum);
						break;
					case("Fighter_Heavy"):
						this.p1 = new Fighter_Heavy(player,playernum);
						break;
				}
			}
			
			if (playernum == 2)
			{
				GameObject player = GameObject.Instantiate( Resources.Load("Prefabs/" + fighter, typeof(GameObject))
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
					case("Fighter_Heavy"):
						this.p2 = new Fighter_Heavy(player,playernum);
						break;
				}
			}
		}
		
	}
}