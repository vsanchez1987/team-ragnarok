using UnityEngine;
using System.Collections;
using FightGame;

namespace FightGame
{
	public abstract class A_Attack
	{
		protected float preAttackPeriod;
		protected float attackPeriod;
		protected float postAttackPeriod;
		protected float animationDuration;
		
		/*
		public I_Attack (float preAttackPeriod = 0.0f, float attackPeriod = 0.0f, float animationDuration = 0.0f)
		{
			this.preAttackPeriod = preAttackPeriod;
			this.attackPeriod = attackPeriod;
			this.animationDuration = animationDuration;
			this.postAttackPeriod = animationDuration - (preAttackPeriod + attackPeriod);
		}
		*/
	}
}

