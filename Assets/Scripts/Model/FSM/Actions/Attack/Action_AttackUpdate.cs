using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_AttackUpdate:FSMAction
	{
		public override void execute(FSMContext c, object o)
		{
			A_Fighter 	fighter = (A_Fighter)o;
			A_Attack 	attack 	= fighter.currentAttack;
			
			attack.Execute();
			attack.SpecialExecute();
			
			if( attack.CheckComplete() ) { c.dispatch("idle", o); }
			fighter.gobj.animation.Play(attack.AnimationName);
			//fighter.gobj.animation.CrossFade(attack.AnimationName);
		}
	}
}