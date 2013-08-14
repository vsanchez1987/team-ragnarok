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
			//when this execute() run, time will increase
			//if time is greater than attackLength, which is animation length from Action_AttackEnter
			//then it will send to idle state.
			//time+=Time.deltaTime;
			//Debug.Log(time);
			
			foreach (A_HitBoxInstruction hbi in attack.instructions){
				if (attack.timer < hbi.startTime){
					hbi.hitbox.TurnOffCollider();
				}
				else if (attack.timer >= hbi.startTime && attack.timer <= hbi.endTime){
					hbi.Execute();
				}
				else if (attack.timer >= hbi.endTime){
					hbi.hitbox.TurnOffCollider();
				}
			}
			
			if(attack.timer >= attack.attackLength)
			{
				Debug.Log ("attackinginginginging");
				c.dispatch("idle", this);
			}
		}
	}
}

