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
			this.attacksCommandMap = new Dictionary<AttackCommand, A_Attack>();
			this.attacksCommandMap[AttackCommand.REGULAR] = new Attack_MegatonPunch("MegatonPunch", 5.0f, this);
		}
	}
}

