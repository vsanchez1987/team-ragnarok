using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_IdleUpdate:FSMAction
	{
		public override void execute(FSMContext c, object o){
			
			//UnityEngine.Debug.Log (GameManager.P1.controllerDirection);
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			//UnityEngine.Debug.Log("idling "+fighter.playerNumber);
			
			if(fighter.gothit)
			{
				//UnityEngine.Debug.Log("hithithithithithithit");
				fighter.Dispatch("gothit");			
			}
			
			else if(fighter.attackPressed || fighter.uniquePressed )
			{
				
				fighter.Dispatch("attack");
			}
			
			else if(fighter.controllerDirection == "forward" || fighter.controllerDirection == "back")
			{
				fighter.Dispatch("walk");
			}
			else
			{
				fighter.Dispatch("idle");
			}
		}
	}
}

