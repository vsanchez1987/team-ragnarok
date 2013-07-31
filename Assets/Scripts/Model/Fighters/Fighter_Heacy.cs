using UnityEngine;
using System.Collections;
using FightGame;
using FSM;

namespace FightGame
{
	public class Fighter_Heacy : A_Fighter
	{
		public Fighter_Heacy (GameObject gobj, int playerNumber)
			:base (playerNumber,gobj)
		{
			this.gobj = gobj;
			this.status = new Status_None();
			this.name = "Heacy";
		}
		
		

	}
}

