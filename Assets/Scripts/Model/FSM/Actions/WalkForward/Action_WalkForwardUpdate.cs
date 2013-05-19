using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_WalkForwardUpdate:FSMAction
	{
		public override void execute(FSMContext c, Object o){
			UnityEngine.Debug.Log("walking forward");
			if( GameManager.P1.controllerDirection != "forward")
			{
				GameManager.P1.Dispatch("idle");
			}
			
		}
	}
}

