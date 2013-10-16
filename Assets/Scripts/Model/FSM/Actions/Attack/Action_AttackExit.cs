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
			
			fighter.movement = Vector3.zero;
			fighter.radius = fighter.gobj.GetComponent<FighterInput>().radius;
			fighter.currentAttack.Reset();
			fighter.currentAttack = null;
			
			if (fighter.gobj.transform.position.x > GameManager.GetOpponentPlayer(fighter.playerNumber).Fighter.gobj.transform.position.x){
				fighter.GlobalForwardVector = new Vector3(-1,0,0);
				fighter.gobj.transform.LookAt( fighter.gobj.transform.position + new Vector3(-1,0,0) );
			}
			else{
				fighter.GlobalForwardVector = new Vector3(1,0,0);
				fighter.gobj.transform.LookAt( fighter.gobj.transform.position + new Vector3(1,0,0) );
			}
		}
	}
}

