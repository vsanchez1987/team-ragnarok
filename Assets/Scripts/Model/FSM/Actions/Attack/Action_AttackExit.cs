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
			
			gobj.animation.Stop();
			fighter.movement = Vector3.zero;
			
			if (fighter.currentAttack.animationName != "char_amaterasu_Fury"){
				if (fighter.extraDamage != 1){
					fighter.extraDamage = 1.0f;
					fighter.extraDamageTimer = 0.0f;
					GameObject.Destroy(fighter.particleHolder1);
					GameObject.Destroy(fighter.particleHolder2);
					Debug.Log(fighter.extraDamage);
				}
			}
			if (fighter.currentAttack.animationName == "char_heavy_cold_shoulder"){
				GameObject.Destroy(fighter.particleHolder1);
				GameObject.Destroy(fighter.particleHolder2);
				fighter.specialEffect=false;
				
			}
			
			
			fighter.currentAttack.timer = 0.0f;
			fighter.currentAttack.Reset();
			fighter.currentAttack = null;
		}
	}
}

