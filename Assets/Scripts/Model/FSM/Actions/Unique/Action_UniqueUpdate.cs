using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_UniqueUpdate:FSMAction
	{
		//float animationTime =0f;	
		public override void execute(FSMContext c, Object o){
			/*
			UnityEngine.Debug.Log("unique attack");
			
			animationTime+= UnityEngine.Time.deltaTime;
			if( animationTime > 2.0f)
			{
				//GameManager.P1.Fighter.Dispatch("idle");
				//animationTime =0f;
			}
			*/
		}
	}
}