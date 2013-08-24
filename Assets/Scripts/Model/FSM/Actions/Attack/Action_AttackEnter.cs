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
			A_Fighter fighter = (A_Fighter)o;			

			if (fighter.currentAction != ActionCommand.NONE){
				fighter.currentAttack = fighter.actionsCommandMap[fighter.currentAction];
				
			}
			
			fighter.gobj.animation[fighter.currentAttack.animationName].speed = fighter.currentAttack.animationSpeed;
			
			foreach (A_HitBoxInstruction hbi in fighter.currentAttack.instructions){
				hbi.Init();
			}
			
			//fighter.gobj.animation.CrossFade(attack.animationName);
			/*
			A_Attack currentAttack = fighter.currentAction;
			//Set an attack from dictionary to a public variable currentAction
			//fighter.SetCurrentAttack();
			//assign attack name
			//string attackName = currentAction.attack_name;
			
			if(currentAction == ActionCommand.NONE)
			{
				//if there's no attack go back to idle state
				c.dispatch("idle");
			}
			
			else
			{
				//if yes,run the animation
				gobj.animation.CrossFade(currentAction.animationName);
				//store animation length, it will be used it in Action_AttackUpdate 
				currentAction.attackLength = gobj.animation[currentAction.animationName].length;		
				currentAction.Execute();
			}
			*/
		}
	}
}

