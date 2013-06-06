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
			GameObject obj = GameManager.P1.GetGOB();
			GameManager.P1.SetCurrentAttack();
			string attackName = (GameManager.P1.currentAttack !=null
								? GameManager.P1.currentAttack.attack_name : null);
			
			if(attackName==null)
			{
				GameManager.P1.Dispatch("idle");
			}
			else
			{
				obj.animation.CrossFade(attackName);
				GameManager.P1.currentAttack.attackLength = obj.animation[attackName].length;
			}
		}
	}
}

