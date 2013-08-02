using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_IdleEnter:FSMAction
	{
		public override void execute(FSMContext c, object o){
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			fighter.GetGOB().animation.CrossFade(fighter.Name+"_Idle");
		}
	}
}

