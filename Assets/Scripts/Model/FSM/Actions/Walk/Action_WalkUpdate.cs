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
			
			A_Fighter fighter;
			fighter = (A_Fighter)o;				
			GameObject gobj = fighter.gobj;
			float moveSpeed = fighter.moveSpeed;
			
			//Debug.Log ("fighter "+fighter.playerNumber+" "+"localforwardvector "+fighter.localForwardVector);
			
			/*
			if(fighter.controllerDirection == "forward" )
			{
				gobj.transform.Translate(fighter.localForwardVector*fighter.movespeed*Time.deltaTime);				
			}
			else if(fighter.controllerDirection == "back")
			{				
				gobj.transform.Translate(fighter.localForwardVector*-1*fighter.movespeed*Time.deltaTime);
			}			
			
			if(fighter.takeDamage)
			{
				fighter.Dispatch("takeDamage");			
			}
			
			else if(fighter.blockPressed)
			{
				fighter.Dispatch("block");
			}
			
			else if(fighter.attackPressed || fighter.uniquePressed )
			{				
				fighter.Dispatch("attack");
			}
			
			else if( fighter.controllerDirection == "forward" || fighter.controllerDirection == "back")
			{
				fighter.Dispatch("walk");
			}
			 
			else if( fighter.controllerDirection != "forward" || fighter.controllerDirection != "back"  )
			{
				fighter.Dispatch("idle");
			}
			*/
			
			if(fighter.currentMovement == MoveCommand.FORWARD || fighter.currentMovement == MoveCommand.FORWARD_UP)
			{
				gobj.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
				gobj.animation.CrossFade(fighter.animationNameMap[FighterAnimation.WALK_FORWARD]);
			}
			else if(fighter.currentMovement == MoveCommand.BACK || fighter.currentMovement == MoveCommand.BACK_UP)
			{
				gobj.transform.Translate(Vector3.forward * -1 * moveSpeed * Time.deltaTime);
				gobj.animation.CrossFade(fighter.animationNameMap[FighterAnimation.WALK_BACKWARD]);
			}

			if( fighter.currentMovement == MoveCommand.NONE)
			{
				c.dispatch("idle", o);
			}
		}
	}
}

