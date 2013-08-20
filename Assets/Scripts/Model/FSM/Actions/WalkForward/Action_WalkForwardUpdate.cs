using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_WalkForwardUpdate:FSMAction
	{
		public override void execute(FSMContext c, object o){
			A_Fighter fighter = (A_Fighter) o;
			GameObject gobj = fighter.gobj;

			if(fighter.currentMovement == MoveCommand.FORWARD || fighter.currentMovement == MoveCommand.FORWARD_UP)
			{
				gobj.transform.Translate(Vector3.forward*Time.deltaTime);
				gobj.animation.CrossFade(fighter.animationNameMap[FighterAnimation.WALK_FORWARD]);
			}
			else if(fighter.currentMovement == MoveCommand.BACK || fighter.currentMovement == MoveCommand.BACK_UP)
			{
				gobj.transform.Translate(Vector3.forward*-1*Time.deltaTime);
				gobj.animation.CrossFade(fighter.animationNameMap[FighterAnimation.WALK_BACKWARD]);
			}
			
			if( fighter.currentMovement == MoveCommand.NONE)
			{
				c.dispatch("idle", this);
			}
		}
	}
}

