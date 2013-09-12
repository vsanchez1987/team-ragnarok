using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_AttackUpdate:FSMAction
	{
		public override void execute(FSMContext c, object o)
		{
			A_Fighter 	fighter = (A_Fighter)o;
			A_Attack 	attack 	= fighter.currentAttack;
			
			attack.Execute();
			attack.SpecialExecute();
			
<<<<<<< HEAD
			fighter.currentAttack.SpecialExecute(time);
			if(fighter.takeDamage)
			{
				fighter.Dispatch("takeDamage");			
			}
			
			if(time >= fighter.currentAttack.attackLength)
			{
				//Debug.Log ("attackinginginginging");
				time=0f;
				fighter.currentAttack = new Attack_None(fighter,0,0,0);
				fighter.Dispatch("idle");
			}	
			time+=Time.deltaTime;
=======
			if( attack.CheckComplete() ) { c.dispatch("idle", o); }
			fighter.gobj.animation.CrossFade(attack.AnimationName);
>>>>>>> fd2511965e41334cb3fce993bcedcd531205f267
		}
	}
}
