using UnityEngine;
using System.Collections;
using FightGame;

namespace FightGame
{
	public class Attack_Melee: A_Attack
	{
		public Attack_Melee (float preAttackPeriod = 0.0f, float attackPeriod = 0.0f, float animationDuration = 0.0f)
		{
			this.preAttackPeriod = preAttackPeriod;
			this.attackPeriod = attackPeriod;
			this.animationDuration = animationDuration;
			this.postAttackPeriod = animationDuration - (preAttackPeriod + attackPeriod);
		}
	}
}

