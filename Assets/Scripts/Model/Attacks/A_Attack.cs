using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public abstract class A_Attack
	{
		protected float preAttackPeriod;
		protected float attackPeriod;
		protected float postAttackPeriod;
		protected float animationDuration;
		
		public string name;
		public List<HBM> attackInstructions;
		float attackLength;
		
		public A_Attack(float attackLength)
		{
			this.attackInstructions=new List<HBM>();
			this.attackLength=attackLength;

		}
		
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

