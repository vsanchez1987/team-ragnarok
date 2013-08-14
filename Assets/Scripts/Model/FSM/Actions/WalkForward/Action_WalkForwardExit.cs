using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_WalkForwardExit:FSMAction
	{
		public override void execute(FSMContext c, Object o){
			A_Fighter fighter = (A_Fighter) o;
		}
	}
}

