using UnityEngine;
using System.Collections;
using FightGame;
using FSM;

namespace FightGame
{
	public class Fighter_Odin : A_Fighter
	{
		//public static float odinMoveSpeed = 5;
		
		public Fighter_Odin (GameObject gobj, int playerNumber)
			:base (playerNumber,gobj)
		{
			this.gobj = gobj;
			this.status = new Status_None();
			this.name = "odin";
			this.movespeed = 1;
			
			//Formula to add more attack to attack list:
			//this.attacklist.Add( "1" if regular attack + direction "back,forward,up,down",create new cs file) 
			//					   "2" if unique attack  + direction "back,forward,up,down",
			this.attacklist.Add("RegAttack_back",new Attack_SweepingSpear(this,0,0,0)); 
			this.attacklist.Add("RegAttack_none",new Attack_ShieldSwipe(this,0,0,0));
			
			
			
			
		}
		
		

	}
}

