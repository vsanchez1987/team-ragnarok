using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_AttackExit:FSMAction
	{
		public override void execute(FSMContext c, object o){
			A_Fighter fighter = (A_Fighter)o;
			GameObject gobj = fighter.gobj;
			
			gobj.animation.Stop();
			fighter.movement = Vector3.zero;
			
			fighter.currentAttack.timer = 0.0f;
			fighter.currentAttack.Reset();
			fighter.currentAttack = null;
		}
	}
}

