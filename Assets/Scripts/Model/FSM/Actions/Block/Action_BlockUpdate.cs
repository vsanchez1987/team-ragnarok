using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_BlockUpdate:FSMAction
	{
		
		public override void execute(FSMContext c, object o){
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			fighter.gobj.animation[ fighter.animationNameMap[FighterAnimation.BLOCK] ].wrapMode = UnityEngine.WrapMode.ClampForever;
			fighter.gobj.animation[ fighter.animationNameMap[FighterAnimation.BLOCK]].speed = 2f;
			fighter.gobj.animation.CrossFade(fighter.animationNameMap[FighterAnimation.BLOCK],0);
		
			
			// Get knocked back when you are hit
			/*
			if(fighter.gotHit)
			{
				Debug.Log("slide back");
				fighter.gob.transform.Translate(fighter.localForwardVector*-1*fighter.slide* Time.deltaTime);
			}
			*/
			
			if (fighter.currentAction == ActionCommand.NONE){
				c.dispatch("idle", o);
			}
			
			/*
			if(fighter.controllerDirection == "forward" || fighter.controllerDirection == "back")
			{
				fighter.Dispatch("walk");
			}*/
		}
	}
}

