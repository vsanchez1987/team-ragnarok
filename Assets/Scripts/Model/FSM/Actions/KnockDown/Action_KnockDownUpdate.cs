using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_KnockDownUpdate:FSMAction
	{
		public override void execute(FSMContext c, object o){
			//UnityEngine.Debug.Log("in hit state");
			A_Fighter fighter;
			fighter = (A_Fighter)o;				
			GameObject gobj = fighter.gobj;
			
			FighterAnimation animation = FighterAnimation.KNOCKDOWN;

			if(fighter.globalActionTimer > 
				(gobj.animation[fighter.animationNameMap[animation]].length / gobj.animation[fighter.animationNameMap[animation]].speed))
			{
				//fighter.isKnockDown = false;
				c.dispatch("idle", o);
			}
			
			fighter.globalActionTimer += UnityEngine.Time.deltaTime;
			gobj.animation.Play(fighter.animationNameMap[animation]);
				
		}
	}
}

