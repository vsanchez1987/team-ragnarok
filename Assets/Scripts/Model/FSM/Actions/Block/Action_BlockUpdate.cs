using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_BlockUpdate:FSMAction
	{
		float time = 0f;
		public override void execute(FSMContext c, object o){
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			
			if(!fighter.blockPressed)
			{
				fighter.Dispatch("idle");
			}
		}
	}
}

