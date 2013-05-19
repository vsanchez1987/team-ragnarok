using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_IdleUpdate:FSMAction
	{
		public override void execute(FSMContext c, Object o){
			UnityEngine.Debug.Log("idling");
			//UnityEngine.Debug.Log (GameManager.P1.controllerDirection);
			
			if(GameManager.P1.attackPressed)
			{
				/*
				switch(GameManager.P1.controllerDirection)
				{
				case("back"):
					//attack name must be the same as animation name
					GameManager.P1.GetAttackName("sweeping_spear");
					break;
				case("up"):
					GameManager.P1.GetAttackName("scorpion_uppercut");
					break;
				case("down"):
					GameManager.P1.GetAttackName("speed_jab");
					break;
				case("forward"):
					GameManager.P1.GetAttackName("thrust");
					break;
				case("none"):
					GameManager.P1.GetAttackName("shield_swipe");
					break;
				}
				*/
				GameManager.P1.Dispatch("attack");
			}
			
			else if(GameManager.P1.uniquePressed)
			{
				GameManager.P1.Dispatch("uniqueAttack");
			}
			
			else if(GameManager.P1.controllerDirection == "forward")
			{
				GameManager.P1.Dispatch("walkForward");
			}
		}
	}
}

