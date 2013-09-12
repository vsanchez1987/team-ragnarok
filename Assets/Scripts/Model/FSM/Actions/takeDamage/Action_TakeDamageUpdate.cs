using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_TakeDamageUpdate:FSMAction
	{
		public override void execute(FSMContext c, object o){
			//UnityEngine.Debug.Log("in hit state");
			A_Fighter fighter;
			fighter = (A_Fighter)o;				
			GameObject gobj = fighter.gobj;
			
			FighterAnimation animation = FighterAnimation.FLINCH_UP;
			
			if (fighter.hurtLocation == Location.HIGH){
				animation = FighterAnimation.FLINCH_UP;
			}
			else if (fighter.hurtLocation == Location.LOW){
				animation = FighterAnimation.FLINCH_DOWN;
			}

			if(fighter.globalActionTimer > 
				(gobj.animation[fighter.animationNameMap[animation]].length / gobj.animation[fighter.animationNameMap[animation]].speed))
			{
				c.dispatch("idle", o);
			}
			
			fighter.globalActionTimer += UnityEngine.Time.deltaTime;
			
			gobj.animation.Play(fighter.animationNameMap[animation]);
				
		}
	}
}

