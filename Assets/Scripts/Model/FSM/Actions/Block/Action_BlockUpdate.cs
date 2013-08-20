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
			
			if(fighter.gotHit)
			{
				Debug.Log("slide back");
				fighter.gob.transform.Translate(fighter.localForwardVector*-1*fighter.slide* Time.deltaTime);
			}			
			
			if(!fighter.blockPressed)
			{
				fighter.Dispatch("idle");
			}
			/*
			if(fighter.controllerDirection == "forward" || fighter.controllerDirection == "back")
			{
				fighter.Dispatch("walk");
			}*/
		}
	}
}

