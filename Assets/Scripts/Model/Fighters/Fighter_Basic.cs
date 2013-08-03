using UnityEngine;
using System.Collections;
using FightGame;
using FSM;

namespace FightGame
{
	public class Fighter_Basic : A_Fighter
	{
		public Fighter_Basic (GameObject gobj, int playerNumber)
			:base (playerNumber,gobj)
		{
			this.gobj = gobj;
			this.status = new Status_None();
			this.name = "Fighter_Basic";
			
			attacklist.Add("test",new Attack_Melee(this,0,0,0)); //tom add for hitbox test, remove later

			
		}
		

	}
}

