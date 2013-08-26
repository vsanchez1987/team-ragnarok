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
			
			//check animation's duration, exit to idle state when animation done
			//"mega_punch" animation just for testing
			
			if(fighter.globalActionTimer > gobj.animation[fighter.animationNameMap[animation]].length)
			{
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
			fighter.globalActionTimer += UnityEngine.Time.deltaTime;
			gobj.animation.Play(fighter.animationNameMap[animation]);
				
		}
	}
}

