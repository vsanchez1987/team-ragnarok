using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_UniqueEnter:FSMAction
	{
		public override void execute(FSMContext c, Object o){
			//string uniqueAttack = GameManager.P1.GetUniqueAttack();
			//GameManager.P1.GetGOB().animation.Play(uniqueAttack);
		}
	}
}

