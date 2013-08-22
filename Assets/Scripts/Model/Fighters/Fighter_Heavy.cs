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
			this.name = "Heavy";
			this.actionsCommandMap = new Dictionary<ActionCommand, A_Attack>();
			
			this.actionsCommandMap[ActionCommand.REGULAR] 			= new Heavy_MegatonPunch(this.animationNameMap[FighterAnimation.REGULAR_ATTACK], this);
			this.actionsCommandMap[ActionCommand.REGULAR_FORWARD] 	= new Heavy_MegatonPunch(this.animationNameMap[FighterAnimation.REGULAR_FORWARD_ATTACK], this);
			this.actionsCommandMap[ActionCommand.REGULAR_BACK] 		= new Heavy_MegatonPunch(this.animationNameMap[FighterAnimation.REGULAR_BACK_ATTACK], this);
			this.actionsCommandMap[ActionCommand.REGULAR_UP] 		= new Heavy_MegatonPunch(this.animationNameMap[FighterAnimation.REGULAR_UP_ATTACK], this);
			this.actionsCommandMap[ActionCommand.REGULAR_DOWN] 		= new Heavy_MegatonPunch(this.animationNameMap[FighterAnimation.REGULAR_DOWN_ATTACK], this);
			
			this.actionsCommandMap[ActionCommand.SPECIAL] 			= new Heavy_ColdShoulder(this.animationNameMap[FighterAnimation.SPECIAL_ATTACK], this);
			this.actionsCommandMap[ActionCommand.SPECIAL_FORWARD] 	= new Heavy_ColdShoulder(this.animationNameMap[FighterAnimation.SPECIAL_FORWARD_ATTACK], this);
			this.actionsCommandMap[ActionCommand.SPECIAL_BACK] 		= new Heavy_ColdShoulder(this.animationNameMap[FighterAnimation.SPECIAL_BACK_ATTACK], this);
			this.actionsCommandMap[ActionCommand.SPECIAL_UP] 		= new Heavy_ColdShoulder(this.animationNameMap[FighterAnimation.SPECIAL_UP_ATTACK], this);
			this.actionsCommandMap[ActionCommand.SPECIAL_DOWN] 		= new Heavy_ColdShoulder(this.animationNameMap[FighterAnimation.SPECIAL_DOWN_ATTACK], this);
			
			this.actionsCommandMap[ActionCommand.UNIQUE] 			= new Heavy_FireCarpet(this.animationNameMap[FighterAnimation.UNIQUE_ATTACK], this);
			this.actionsCommandMap[ActionCommand.UNIQUE_FORWARD] 	= new Heavy_FireCarpet(this.animationNameMap[FighterAnimation.UNIQUE_FORWARD_ATTACK], this);
			this.actionsCommandMap[ActionCommand.UNIQUE_BACK] 		= new Heavy_FireCarpet(this.animationNameMap[FighterAnimation.UNIQUE_BACK_ATTACK], this);
			this.actionsCommandMap[ActionCommand.UNIQUE_UP] 		= new Heavy_FireCarpet(this.animationNameMap[FighterAnimation.UNIQUE_UP_ATTACK], this);
			this.actionsCommandMap[ActionCommand.UNIQUE_DOWN] 		= new Heavy_FireCarpet(this.animationNameMap[FighterAnimation.UNIQUE_DOWN_ATTACK], this);
			//this.actionsCommandMap[ActionCommand.BLOCK] = new Heavy_MegatonPunch(this.animationNameMap[FighterAnimation.BLOCK], this);
		}
	}
}

