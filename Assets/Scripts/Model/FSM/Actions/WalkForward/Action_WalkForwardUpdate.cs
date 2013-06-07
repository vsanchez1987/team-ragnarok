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
			GameObject gobj = GameManager.P1.GetGOB();
			
			if(GameManager.P1.controllerDirection == "forward" )
			{
				gobj.transform.Translate(Vector3.forward*Time.deltaTime);
			}
			else if(GameManager.P1.controllerDirection == "back")
			{
				//GameManager.P1.GetGOB().animation.CrossFade("WalkBack");

				gobj.transform.Translate(Vector3.forward*-1*Time.deltaTime);
			}
			
			
			if( GameManager.P1.controllerDirection == "none")
			{
				GameManager.P1.Dispatch("idle");
			}
			if( GameManager.P1.controllerDirection == "forward" || GameManager.P1.controllerDirection == "back")
			{
				GameManager.P1.Dispatch("walkForward");
			}
		}
	}
}

