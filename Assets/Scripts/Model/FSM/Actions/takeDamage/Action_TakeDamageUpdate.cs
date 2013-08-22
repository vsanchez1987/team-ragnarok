using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_TakeDamageUpdate:FSMAction
	{
		float time = 0f;
		public override void execute(FSMContext c, object o){
			//UnityEngine.Debug.Log("in hit state");
			A_Fighter fighter;
			fighter = (A_Fighter)o;				
			GameObject gobj = fighter.gobj;
			
			FighterAnimation animation = FighterAnimation.FLINCH;
			
			if (fighter.hurtLocation == Location.HIGH){
				animation = FighterAnimation.FLINCH;
			}
			else if (fighter.hurtLocation == Location.LOW){
				animation = FighterAnimation.FLINCH;
			}
			
			//check animation's duration, exit to idle state when animation done
			//"mega_punch" animation just for testing
			
			if(time > gobj.animation[fighter.animationNameMap[animation]].length)
			{
				time = 0f;
				c.dispatch("idle", o);
			}
			
			//if during animation, got hit again, go back to got hit state
			/*
			if(fighter.gothit)
			{
				time = 0f;
				c.dispatch("takeDamage", this);
			}
			*/
			time+= UnityEngine.Time.deltaTime;
			gobj.animation.CrossFade(fighter.animationNameMap[animation]);
				
		}
	}
}

