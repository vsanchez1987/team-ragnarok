using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;
namespace FSM
{
	public class Action_WalkUpdate:FSMAction
	{
		public override void execute(FSMContext c, object o){
			A_Fighter fighter = (A_Fighter)o;				
			GameObject gobj = fighter.gobj;
			float moveSpeed = fighter.moveSpeed;
			
			if(fighter.currentMovement == MoveCommand.FORWARD || fighter.currentMovement == MoveCommand.FORWARD_UP)
			{
				if ( GameManager.CheckCanMoveForward(fighter) ){
					gobj.transform.Translate(fighter.localForwardVector * moveSpeed * Time.deltaTime);
				}
				else{
					A_Fighter opponent = GameManager.GetOpponentPlayer(fighter.playerNumber).Fighter;
					if ( GameManager.CheckCanMoveBackward(opponent) ){
						opponent.gobj.transform.Translate(fighter.localForwardVector * -1 * moveSpeed * Time.deltaTime);
						//opponent.DoMoveCommand(MoveCommand.BACK);
					}
				}
				gobj.animation.CrossFade(fighter.animationNameMap[FighterAnimation.WALK_FORWARD]);
			}
			else if(fighter.currentMovement == MoveCommand.BACK || fighter.currentMovement == MoveCommand.BACK_UP)
			{
				if ( GameManager.CheckCanMoveBackward(fighter) ){
					gobj.transform.Translate(fighter.localForwardVector * -1 * moveSpeed * Time.deltaTime);
				}
				gobj.animation.CrossFade(fighter.animationNameMap[FighterAnimation.WALK_BACKWARD]);
			}
			
			
			if( fighter.currentMovement == MoveCommand.NONE)
			{
				c.dispatch("idle", o);
			}
		}
	}
}

