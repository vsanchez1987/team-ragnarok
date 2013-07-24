using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_IdleUpdate:FSMAction
	{
		public override void execute(FSMContext c, object o){
			//UnityEngine.Debug.Log("idling");
			//UnityEngine.Debug.Log (GameManager.P1.controllerDirection);
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			
			
			if(fighter.attackPressed || fighter.uniquePressed )
			{
				
				fighter.Dispatch("attack");
			}
			
			else if(fighter.controllerDirection == "forward" || fighter.controllerDirection == "back")
			{
				fighter.Dispatch("walkForward");
			}
			else
			{
				fighter.Dispatch("idle");
			}
		}
	}
}

