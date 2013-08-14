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
			/*
			A_Fighter fighter = (A_Fighter)o;
			
			//Get a gameobject
			GameObject gobj = fighter.gobj;
			A_Attack currentAttack = fighter.currentAttack;
			//Set an attack from dictionary to a public variable currentAttack
			//fighter.SetCurrentAttack();
			//assign attack name
			//string attackName = currentAttack.attack_name;
			
			if(currentAttack == AttackCommand.NONE)
			{
				//if there's no attack go back to idle state
				c.dispatch("idle");
			}
			
			else
			{
				//if yes,run the animation
				gobj.animation.CrossFade(currentAttack.animationName);
				//store animation length, it will be used it in Action_AttackUpdate 
				currentAttack.attackLength = gobj.animation[currentAttack.animationName].length;		
				currentAttack.Execute();
			}
			*/
		}
	}
}

