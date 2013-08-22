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
			
			this.actionsCommandMap[ActionCommand.REGULAR] = new Heavy_MegatonPunch(this.animationNameMap[FighterAnimation.REGULAR_ATTACK], this);
			this.actionsCommandMap[ActionCommand.SPECIAL] = new Heavy_ColdShoulder(this.animationNameMap[FighterAnimation.SPECIAL_ATTACK], this);
			this.actionsCommandMap[ActionCommand.UNIQUE] = new Heavy_FireCarpet(this.animationNameMap[FighterAnimation.UNIQUE_ATTACK], this);
			//this.actionsCommandMap[ActionCommand.BLOCK] = new Heavy_MegatonPunch(this.animationNameMap[FighterAnimation.BLOCK], this);
		}
	}
}

