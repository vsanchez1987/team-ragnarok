using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_AttackEnter:FSMAction
	{
		public override void execute(FSMContext c, object o)
		{
			GameManager.P1.SetCurrentAttack();
			string attackName = (GameManager.P1.currentAttack !=null
									? GameManager.P1.currentAttack.attack_name : null);
			GameManager.P1.GetGOB().animation.CrossFade(attackName);
			GameManager.P1.currentAttack.attackLength = GameManager.P1.GetGOB().animation[attackName].length;
		}
	}
}

