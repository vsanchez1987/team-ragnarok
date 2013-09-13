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
			A_Fighter fighter = (A_Fighter)o;			

			if (fighter.currentAction != ActionCommand.NONE){
				fighter.currentAttack = fighter.actionsCommandMap[fighter.currentAction];
			}
			
			fighter.currentAttack.Init();
			fighter.gobj.animation[fighter.currentAttack.AnimationName].speed = fighter.currentAttack.speed;
			//fighter.gobj.animation.Stop();
		}
	}
}

