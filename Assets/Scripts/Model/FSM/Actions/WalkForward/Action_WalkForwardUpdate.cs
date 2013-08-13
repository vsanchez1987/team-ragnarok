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
			// Commented out, changing input
			/*
			if(fighter.controllerDirection == "forward" )
			{
				gobj.transform.Translate(Vector3.forward*Time.deltaTime);
			}
			else if(fighter.controllerDirection == "back")
			{
				//GameManager.P1.GetGOB().animation.CrossFade("WalkBack");

				gobj.transform.Translate(Vector3.forward*-1*Time.deltaTime);
			}
			
			
			if( fighter.controllerDirection == "none")
			{
				fighter.Dispatch("idle");
			}
			if( fighter.controllerDirection == "forward" || fighter.controllerDirection == "back")
			{
				fighter.Dispatch("walkForward");
			}
			*/
		}
	}
}

