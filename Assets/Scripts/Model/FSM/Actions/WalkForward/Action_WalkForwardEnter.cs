using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_WalkForwardEnter:FSMAction
	{
		public override void execute(FSMContext c, Object o){
			if(GameManager.P1.controllerDirection == "forward" )
			{
				GameManager.P1.GetGOB().animation.CrossFade("WalkForward");
			}
			else if(GameManager.P1.controllerDirection == "back")
			{
				GameManager.P1.GetGOB().animation.CrossFade("WalkBack");
			}

		}
	}
}

