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
			
			if(GameManager.P1.attackPressed || GameManager.P1.uniquePressed)
			{
				GameManager.P1.Dispatch("attack");
			}
			
			else if(GameManager.P1.controllerDirection == "forward" || GameManager.P1.controllerDirection == "back")
			{
				GameManager.P1.Dispatch("walkForward");
			}
			else
			{
				GameManager.P1.Dispatch("idle");
			}
		}
	}
}

