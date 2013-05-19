using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Odin_IdleUpdate:FSMAction
	{
		public override void execute(FSMContext c, Object o){
			UnityEngine.Debug.Log("idling");
			//UnityEngine.Debug.Log (GameManager.P1.controllerDirection);
			
			if(GameManager.P1.attackPressed)
			{
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
				
				//if switch statement doesn't work use if else
				/*
				if( GameManager.P1.controllerDirection == "back")
				{
					//attack name must be the same as animation name
					GameManager.P1.GetAttackName("sweeping_spear");
				}			
				else if (GameManager.P1.controllerDirection =="up")
				{
					GameManager.P1.GetAttackName("scorpion_uppercut");
				}
				else if (GameManager.P1.controllerDirection =="down")
				{
					GameManager.P1.GetAttackName("speed_jab");
				}	
				else if( GameManager.P1.controllerDirection =="forward")
				{
					GameManager.P1.GetAttackName("thrust");
				}		
				else if( GameManager.P1.controllerDirection == "none")
				{
					UnityEngine.Debug.Log("aaaaaaaaaaaaaaaaaaaa");
					GameManager.P1.GetAttackName("shield_swipe");
				}		
				*/
				GameManager.P1.Dispatch("attack");
			}
			
			else if(GameManager.P1.uniquePressed)
			{
			}
			
			else if(GameManager.P1.controllerDirection == "forward")
			{
				GameManager.P1.Dispatch("walkForward");
			}
		}
	}
}

