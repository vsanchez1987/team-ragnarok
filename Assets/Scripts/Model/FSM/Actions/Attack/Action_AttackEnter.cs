using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_AttackEnter:FSMAction
	{
		public override void execute(FSMContext c, Object o){
			//string currentAttack = GameManager.P1.attack_name;
			//GameManager.P1.GetGOB().animation.Play(currentAttack);
		}
	}
}

