using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_IdleUpdate:FSMAction
	{
		public override void execute(FSMContext c, object o){
			
			//UnityEngine.Debug.Log (GameManager.P1.controllerDirection);
			A_Fighter fighter = (A_Fighter)o;
			fighter.gobj.animation.CrossFade(fighter.animationNameMap[FighterAnimation.IDLE]);
			
			// Commented out, changing input
			/*
			UnityEngine.Debug.Log("idling "+fighter.playerNumber);
			if(fighter.gothit)
			{
				UnityEngine.Debug.Log("hithithithithithithit");
				fighter.Dispatch("gothit");
			
			}
			
			else if(fighter.attackPressed || fighter.uniquePressed )
			{
				
				fighter.Dispatch("attack");
			}
			
			else if(fighter.controllerDirection == "forward" || fighter.controllerDirection == "back")
			{
				fighter.Dispatch("walkForward");
			}
			else
			{
				fighter.Dispatch("idle");
			}
			*/
		}
	}
}

