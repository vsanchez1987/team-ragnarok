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
			//Get a gameobject
			GameObject obj = GameManager.P1.GetGOB();
			//Set an attack from dictionary to a public variable currentAttack
			GameManager.P1.SetCurrentAttack();
			//assign attack name
			string attackName = (GameManager.P1.currentAttack !=null
								? GameManager.P1.currentAttack.attack_name : null);
			
			if(attackName==null)
			{
				//if there's no attack go back to idle state
				GameManager.P1.Dispatch("idle");
			}
			else
			{
				//if yes,run the animation
				obj.animation.CrossFade(attackName);
				//store animation length, it will be used it in Action_AttackUpdate 
				GameManager.P1.currentAttack.attackLength = obj.animation[attackName].length;
			}
		}
	}
}

