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
			//UnityEngine.Debug.Log(fighter.playerNumber+" direction "+fighter.controllerDirection);
			
			
			if(fighter.takeDamage)
			{
				fighter.Dispatch("takeDamage");			
			}
			
			else if(fighter.attackPressed || fighter.uniquePressed )
			{
				
				fighter.Dispatch("attack");
			}
			
			else if(fighter.controllerDirection == "forward" || fighter.controllerDirection == "back")
			{
				//UnityEngine.Debug.Log("dispatch to walk");
				fighter.Dispatch("walk");
			}
			else if(fighter.blockPressed)
			{
				fighter.Dispatch("block");
			}
			else
			{
				fighter.Dispatch("idle");
			}
		}
	}
}

