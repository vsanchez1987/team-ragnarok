using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_DeathUpdate:FSMAction
	{
		
		public override void execute(FSMContext c, object o){
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			
			fighter.gobj.animation[ fighter.animationNameMap[FighterAnimation.DEATH] ].wrapMode = UnityEngine.WrapMode.ClampForever;
			fighter.gobj.animation.CrossFade(fighter.animationNameMap[FighterAnimation.DEATH]);
		}
	}
}

