using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FightGame
{
	public class Fighter_Odin : A_Fighter
	{
		public Fighter_Odin (GameObject gobj, int playerNumber)
			:base (gobj, playerNumber)
		{
			this.name = "Odin";
			this.gobj = gobj;
			this.status = new Status_None();
			this.actionsCommandMap = new Dictionary<ActionCommand, A_Attack>();
			
			this.actionsCommandMap[ActionCommand.REGULAR] = new Sweeping_Spear("Sweeping_Spear", this);
			this.actionsCommandMap[ActionCommand.SPECIAL] = new Sweeping_Spear("Sweeping_Spear", this);
			this.actionsCommandMap[ActionCommand.UNIQUE] = new Sweeping_Spear("Sweeping_Spear", this);
			this.actionsCommandMap[ActionCommand.BLOCK] = new Sweeping_Spear("Sweeping_Spear", this);
			//this.name = "Odin";
			
			
			//Formula to add more attack to attack list:
			//this.attacklist.Add( "1" if regular attack + direction "back,forward,up,down",create new cs file) 
			//					   "2" if unique attack  + direction "back,forward,up,down",
			//this.attacklist.Add("1back",new Sweeping_Spear(this,0,0,0)); 
			//this.attacklist.Add("1none",new Shield_Swipe(this,0,0,0));
			
			
			
			
		}
	}
}

