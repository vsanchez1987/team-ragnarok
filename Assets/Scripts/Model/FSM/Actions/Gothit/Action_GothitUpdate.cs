using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_GothitUpdate:FSMAction
	{
		public override void execute(FSMContext c, Object o){
			UnityEngine.Debug.Log("in hit state");
			A_Fighter fighter;
			fighter = (A_Fighter)o;
		
				fighter.Dispatch("gothit");

				
		}
	}
}

