using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_BlockExit:FSMAction
	{
		public override void execute(FSMContext c, object o){
			//A_Fighter fighter = (A_Fighter)o;
			
			//fighter.gobj.animation[fighter.animationNameMap[FighterAnimation.BLOCK]].wrapMode = UnityEngine.WrapMode.Default;
		}
	}
}

