using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_AttackUpdate:FSMAction
	{
		//float time =0f;
		public override void execute(FSMContext c, object o)
		{
			A_Fighter 	fighter = (A_Fighter)o;
			A_Attack 	attack 	= fighter.attacksCommandMap[fighter.currentAttack];
			
			foreach (A_HitBoxInstruction hbi in attack.instructions){
				if (attack.timer < hbi.startTime){
					hbi.hitbox.Disable();
				}
				else if (attack.timer >= hbi.startTime && attack.timer <= hbi.endTime){
					hbi.Execute();
				}
				else if (attack.timer >= hbi.endTime){
					hbi.Reset();
				}
			}
			//Debug.Log(attack.timer.ToString() + " > " + attack.attackLength.ToString());
			if(attack.timer >= attack.attackLength)
			{
				attack.timer = 0.0f;
				attack.Reset();
				c.dispatch("idle", this);
			}
			
			fighter.gobj.animation.CrossFade(attack.animationName);
			attack.Execute();
		}
	}
}

