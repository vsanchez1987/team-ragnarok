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
			UnityEngine.Debug.Log("walking forward");
			
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			
			
			GameObject gobj = fighter.GetGOB();
			
			UnityEngine.Debug.Log("test     "+fighter.playerNumber+" "+fighter.controllerDirection);
			
			if(fighter.controllerDirection == "forward" )
			{
				gobj.transform.Translate(fighter.ForwardVector*Time.deltaTime);
			}
			else if(fighter.controllerDirection == "back")
			{
				//GameManager.P1.GetGOB().animation.CrossFade("WalkBack");

				gobj.transform.Translate(fighter.ForwardVector*-1*Time.deltaTime);
			}
			
			
			if( fighter.controllerDirection == "none")
			{
				fighter.Dispatch("idle");
			}
			if( fighter.controllerDirection == "forward" || fighter.controllerDirection == "back")
			{
				fighter.Dispatch("walkForward");
			}
		}
	}
}

