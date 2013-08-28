using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FightGame
{
	public class Fighter_Heavy : A_Fighter
	{
		public Fighter_Heavy (GameObject gobj, int playerNumber) : base (gobj, playerNumber)
		{			
			this.gobj.animation[this.animationNameMap[FighterAnimation.WALK_FORWARD]].speed = 1.5f;
			this.gobj.animation[this.animationNameMap[FighterAnimation.WALK_BACKWARD]].speed = 1.5f;
			
			this.actionsCommandMap = new Dictionary<ActionCommand, A_Attack>();
			
			this.actionsCommandMap[ActionCommand.REGULAR] 			= new Heavy_FireCarpet(this.animationNameMap[FighterAnimation.REGULAR_ATTACK], this, 2.0f);
			this.actionsCommandMap[ActionCommand.REGULAR_FORWARD] 	= new Heavy_ColdShoulder(this.animationNameMap[FighterAnimation.REGULAR_FORWARD_ATTACK], this, 1.3f);
			this.actionsCommandMap[ActionCommand.REGULAR_BACK] 		= new Heavy_TriplePunch(this.animationNameMap[FighterAnimation.REGULAR_BACK_ATTACK], this, 2.0f);
			this.actionsCommandMap[ActionCommand.REGULAR_UP] 		= new Heavy_MegatonPunch(this.animationNameMap[FighterAnimation.REGULAR_UP_ATTACK], this, 1.5f);
			this.actionsCommandMap[ActionCommand.REGULAR_DOWN] 		= new Heavy_FireCarpet(this.animationNameMap[FighterAnimation.REGULAR_DOWN_ATTACK], this, 2.0f);
			
			this.actionsCommandMap[ActionCommand.UNIQUE] 			= new Heavy_HeatSeeker(this.animationNameMap[FighterAnimation.UNIQUE_ATTACK], this, 2.0f);
			this.actionsCommandMap[ActionCommand.UNIQUE_FORWARD] 	= new Heavy_NapalmFlameThrower(this.animationNameMap[FighterAnimation.UNIQUE_FORWARD_ATTACK], this, 1.5f);
			this.actionsCommandMap[ActionCommand.UNIQUE_BACK] 		= new Heavy_123Fire(this.animationNameMap[FighterAnimation.UNIQUE_ATTACK], this, 2.0f);
			this.actionsCommandMap[ActionCommand.UNIQUE_UP] 		= new Heavy_HeatSeeker(this.animationNameMap[FighterAnimation.UNIQUE_UP_ATTACK], this, 2.0f);
			this.actionsCommandMap[ActionCommand.UNIQUE_DOWN] 		= new Heavy_NapalmFlameThrower(this.animationNameMap[FighterAnimation.UNIQUE_DOWN_ATTACK], this, 1.5f);
			
			this.actionsCommandMap[ActionCommand.SPECIAL] 			= new Heavy_Railgun(this.animationNameMap[FighterAnimation.SPECIAL_ATTACK], this, 2.0f);
			this.actionsCommandMap[ActionCommand.SPECIAL_FORWARD] 	= new Heavy_Railgun(this.animationNameMap[FighterAnimation.SPECIAL_FORWARD_ATTACK], this, 2.0f);
			this.actionsCommandMap[ActionCommand.SPECIAL_BACK] 		= new Heavy_Railgun(this.animationNameMap[FighterAnimation.SPECIAL_BACK_ATTACK], this, 2.0f);
			this.actionsCommandMap[ActionCommand.SPECIAL_UP] 		= new Heavy_Railgun(this.animationNameMap[FighterAnimation.SPECIAL_UP_ATTACK], this, 2.0f);
			this.actionsCommandMap[ActionCommand.SPECIAL_DOWN] 		= new Heavy_Railgun(this.animationNameMap[FighterAnimation.SPECIAL_DOWN_ATTACK], this, 2.0f);
			
			//this.actionsCommandMap[ActionCommand.BLOCK] = new Heavy_MegatonPunch(this.animationNameMap[FighterAnimation.BLOCK], this);
		}
	}
}

