using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_BlockEnter:FSMAction
	{
		public override void execute(FSMContext c, object o){
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			
			//fighter.gobj.animation[ fighter.animationNameMap[FighterAnimation.BLOCK] ].wrapMode = UnityEngine.WrapMode.ClampForever;
			//fighter.gobj.animation.CrossFade(fighter.animationNameMap[FighterAnimation.BLOCK]);
			
			//string animationName = fighter.GetAnimationName(fighter,"block");
			//fighter.GetGOB().animation[animationName].wrapMode=UnityEngine.WrapMode.ClampForever;
			//fighter.GetGOB().animation.CrossFade(animationName);
		}
	}
}

