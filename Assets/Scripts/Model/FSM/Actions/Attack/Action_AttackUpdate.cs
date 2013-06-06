using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_AttackUpdate:FSMAction
	{
		float time =0f;
		public override void execute(FSMContext c, object o)
		{
			//when this execute() run, time will increase
			//if time is greater than attackLength, which is animation length from Action_AttackEnter
			//then it will send to idle state.
			time+=Time.deltaTime;
			//Debug.Log(time);
			if(time > GameManager.P1.currentAttack.attackLength)
			{
				Debug.Log ("aaaaaaaaaaaaaaa");
				GameManager.P1.Dispatch("idle");
				time=0f;
			}	
			
		}
	}
}

