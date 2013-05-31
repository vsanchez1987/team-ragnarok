using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_IdleEnter:FSMAction
	{
		public override void execute(FSMContext c, Object o){
			GameManager.P1.GetGOB().animation.CrossFade("idle");
		}
	}
}

