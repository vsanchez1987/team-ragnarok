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
			
			fighter.gobj.animation[fighter.currentAttack.animationName].speed = fighter.currentAttack.animationSpeed;
			
			foreach (A_HitBoxInstruction hbi in fighter.currentAttack.instructions){
				hbi.Init();
			}
			Debug.Log("attack " + fighter.currentAttack.animationName);
			fighter.gobj.animation.Stop();
		}
	}
}

