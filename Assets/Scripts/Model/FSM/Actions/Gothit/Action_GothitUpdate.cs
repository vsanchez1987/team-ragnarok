using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_GothitUpdate:FSMAction
	{
		float time = 0f;
		public override void execute(FSMContext c, Object o){
			UnityEngine.Debug.Log("in hit state");
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			time+= UnityEngine.Time.deltaTime;
			
			//check animation's duration, exit to idle state when animation done
			//"mega_punch" animation just for testing
			if(time > fighter.GetGOB().animation["MegaPunch"].length)
			{
				time = 0f;
				fighter.Dispatch("idle");
			}
			//if during animation, got hit again, go back to got hit state
			if(fighter.gothit)
			{
				time = 0f;
				fighter.Dispatch("gothit");
			}
				
		}
	}
}

