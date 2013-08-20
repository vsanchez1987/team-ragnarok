using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_TakeDamageEnter:FSMAction
	{
		public override void execute(FSMContext c, Object o){
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			fighter.takeDamage = false;
			//"mega_punch" animation just for testing
			string animationName = fighter.GetAnimationName(fighter,"flinch_down");
			
			fighter.GetGOB().animation.CrossFade(animationName);
		}
	}
}

