using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_AttackExit:FSMAction
	{
		public override void execute(FSMContext c, object o){
			A_Fighter fighter = (A_Fighter)o;
			GameObject gobj = fighter.gobj;
			
			//gobj.animation.Stop();
			fighter.movement = Vector3.zero;
			/*
			if (fighter.currentAttack.animationName != "char_amaterasu_Fury"){
				if (fighter.extraDamage != 1){
					fighter.extraDamage = 1.0f;
					fighter.extraDamageTimer = 0.0f;
					Debug.Log(fighter.extraDamage);
				}
			}
			*/
			
			fighter.currentAttack.Reset();
			fighter.currentAttack = null;
		}
	}
}

