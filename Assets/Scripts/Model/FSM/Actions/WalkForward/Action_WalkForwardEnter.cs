using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_WalkForwardEnter:FSMAction
	{
		public override void execute(FSMContext c, Object o){
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			
			if(fighter.controllerDirection == "forward" )
			{
				fighter.GetGOB().animation.CrossFade("WalkForward");
			}
			else if(fighter.controllerDirection == "back")
			{
				fighter.GetGOB().animation.CrossFade("WalkBack");
			}

		}
	}
}

