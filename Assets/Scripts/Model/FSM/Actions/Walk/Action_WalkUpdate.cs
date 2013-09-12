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
			
<<<<<<< HEAD
			A_Fighter fighter;
			fighter = (A_Fighter)o;				
			GameObject gobj = fighter.GetGOB();
			
			//Debug.Log ("fighter "+fighter.playerNumber+" "+"localforwardvector "+fighter.localForwardVector);
			
			
			if(fighter.controllerDirection == "forward" )
			{
				if(!GameManager.CheckCollideAnotherPlayer())
				{
					gobj.transform.Translate(fighter.localForwardVector*fighter.movespeed*Time.deltaTime);	
				}
			}
			else if(fighter.controllerDirection == "back")
			{		
				if(!GameManager.CheckCollideEdge(fighter,fighter.playerNumber))
				gobj.transform.Translate(fighter.localForwardVector*-1*fighter.movespeed*Time.deltaTime);	
			}		
			
			if(fighter.takeDamage)
=======
			if(fighter.currentMovement == MoveCommand.FORWARD || fighter.currentMovement == MoveCommand.FORWARD_UP)
>>>>>>> fd2511965e41334cb3fce993bcedcd531205f267
			{
				if ( GameManager.CheckCanMoveForward(fighter) ){
					gobj.transform.Translate(fighter.localForwardVector * moveSpeed * Time.deltaTime);
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
<<<<<<< HEAD
			 
			else if( fighter.controllerDirection != "forward" || fighter.controllerDirection != "back"  )
			{
				fighter.Dispatch("idle");
			}
=======
>>>>>>> fd2511965e41334cb3fce993bcedcd531205f267
		}
	}
}

