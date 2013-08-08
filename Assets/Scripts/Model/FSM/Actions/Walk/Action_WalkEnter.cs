using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_WalkEnter:FSMAction
	{
		public override void execute(FSMContext c, Object o){
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			
			
			
			if(fighter.controllerDirection == "forward" )
			{
				string animationName = fighter.GetAnimationName(fighter,"walk_forward");
				fighter.GetGOB().animation.CrossFade(animationName);
			}
			else if(fighter.controllerDirection == "back")
			{
				string animationName = fighter.GetAnimationName(fighter,"walk_backward");
				fighter.GetGOB().animation.CrossFade(animationName);
			}

		}
	}
}

