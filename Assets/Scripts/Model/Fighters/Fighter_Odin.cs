using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FightGame
{
	public class Fighter_Odin : A_Fighter
	{
		public Fighter_Odin (GameObject gobj, int playerNumber) : base (gobj, playerNumber){
			
			this.gobj.animation[this.animationNameMap[FighterAnimation.WALK_FORWARD]].speed = 2.0f;
			this.gobj.animation[this.animationNameMap[FighterAnimation.WALK_BACKWARD]].speed = 2.0f;
			
			this.actionsCommandMap = new Dictionary<int, A_Attack>();
			
			this.actionsCommandMap[ActionCommand.REGULAR] 			= new Odin_SpeedJab(this.animationNameMap[FighterAnimation.REGULAR_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.REGULAR_FORWARD] 	= new Odin_ThrustLunge(this.animationNameMap[FighterAnimation.REGULAR_FORWARD_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.REGULAR_BACK] 		= new Odin_SweepingSpear(this.animationNameMap[FighterAnimation.REGULAR_BACK_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.REGULAR_UP] 		= new Odin_ScorpionUppercut(this.animationNameMap[FighterAnimation.REGULAR_UP_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.REGULAR_DOWN] 		= new Odin_BackhandSwipe(this.animationNameMap[FighterAnimation.REGULAR_DOWN_ATTACK], this, 1.0f);
			
			this.actionsCommandMap[ActionCommand.UNIQUE] 			= new Odin_RavensFury(this.animationNameMap[FighterAnimation.UNIQUE_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.UNIQUE_FORWARD] 	= new Odin_ThrustLunge(this.animationNameMap[FighterAnimation.UNIQUE_FORWARD_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.UNIQUE_BACK] 		= new Odin_SweepingSpear(this.animationNameMap[FighterAnimation.UNIQUE_BACK_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.UNIQUE_UP] 		= new Odin_RavenStorm(this.animationNameMap[FighterAnimation.UNIQUE_UP_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.UNIQUE_DOWN] 		= new Odin_RavenSoulSteal(this.animationNameMap[FighterAnimation.UNIQUE_DOWN_ATTACK], this, 1.0f);
			
			this.actionsCommandMap[ActionCommand.SPECIAL] 			= new Odin_RavenStorm(this.animationNameMap[FighterAnimation.SPECIAL_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.SPECIAL_FORWARD] 	= new Odin_RavenStorm(this.animationNameMap[FighterAnimation.SPECIAL_FORWARD_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.SPECIAL_BACK] 		= new Odin_RavenStorm(this.animationNameMap[FighterAnimation.SPECIAL_BACK_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.SPECIAL_UP] 		= new Odin_RavenStorm(this.animationNameMap[FighterAnimation.SPECIAL_UP_ATTACK], this, 1.0f);
			this.actionsCommandMap[ActionCommand.SPECIAL_DOWN] 		= new Odin_RavenStorm(this.animationNameMap[FighterAnimation.SPECIAL_DOWN_ATTACK], this, 1.0f);
		}
	}
}

