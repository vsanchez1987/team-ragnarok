using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_GothitEnter:FSMAction
	{
		public override void execute(FSMContext c, Object o){
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			fighter.gothit = false;
			//"mega_punch" animation just for testing
			fighter.GetGOB().animation.CrossFade("mega_punch");
		}
	}
}

