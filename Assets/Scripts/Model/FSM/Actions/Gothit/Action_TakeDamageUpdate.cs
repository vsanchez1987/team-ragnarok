using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_TakeDamageUpdate:FSMAction
	{
		float time = 0f;
		public override void execute(FSMContext c, Object o){
			//UnityEngine.Debug.Log("in hit state");
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			//time+= UnityEngine.Time.deltaTime;
			
			string animationName = fighter.GetAnimationName(fighter,"flinch_down");
			
			//check animation's duration, exit to idle state when animation done
			//"mega_punch" animation just for testing
			if(time > fighter.GetGOB().animation[animationName].length - 0.75)
			{
				time = 0f;
				fighter.Dispatch("idle");
			}					
			time+= UnityEngine.Time.deltaTime;
		}
	}
}

