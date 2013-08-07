using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;
namespace FSM
{
	public class Action_WalkUpdate:FSMAction
	{
		public override void execute(FSMContext c, object o){
			
			A_Fighter fighter;
			fighter = (A_Fighter)o;				
			GameObject gobj = fighter.GetGOB();
						
			if(fighter.controllerDirection == "forward" )
			{
				gobj.transform.Translate(fighter.ForwardVector*fighter.movespeed*Time.deltaTime);
				
			}
			else if(fighter.controllerDirection == "back")
			{
				//GameManager.P1.GetGOB().animation.CrossFade("WalkBack");
				gobj.transform.Translate(fighter.ForwardVector*-1*fighter.movespeed*Time.deltaTime);
			}
			
			
			
			
			if( fighter.controllerDirection == "none")
			{
				fighter.Dispatch("idle");
			}
			
			if(fighter.attackPressed || fighter.uniquePressed )
			{				
				fighter.Dispatch("attack");
			}
			
			else if( fighter.controllerDirection == "forward" || fighter.controllerDirection == "back")
			{
				fighter.Dispatch("walk");
			}
		}
	}
}

