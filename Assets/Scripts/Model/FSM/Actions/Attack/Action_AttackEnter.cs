using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_AttackEnter:FSMAction
	{
		public override void execute(FSMContext c, object o)
		{
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			
			//Get a gameobject
			GameObject obj = fighter.GetGOB();
			A_Attack currentAttack = fighter.currentAttack;
			//Set an attack from dictionary to a public variable currentAttack
			fighter.SetCurrentAttack();
			//assign attack name
			string attackName = currentAttack.attack_name;
			
			if(attackName=="Attack_None")
			{
				//if there's no attack go back to idle state
				fighter.Dispatch("idle");
				
			}
			else
			{
				Debug.Log(fighter.Name+"_"+attackName);
				//if yes,run the animation
				obj.animation.CrossFade(fighter.Name+"_"+attackName);
				//store animation length, it will be used it in Action_AttackUpdate 
				currentAttack.attackLength = obj.animation[fighter.Name+"_"+attackName].length;		
				currentAttack.Execute();				
			}
		}
	}
}

