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
		protected A_Fighter attackOwner;
		
		public string name;
		public List<HitBoxInstruction> attackInstructions;
		float attackLength;
		
		public A_Attack(float attackLength,A_Fighter attackOwner)
		{
			this.attackInstructions=new List<HitBoxInstruction>();
			this.attackLength=attackLength;
			this.attackOwner = attackOwner;

		}
		
		public virtual void Execute()
		{
			if(attackInstructions!=null)
			{		
				foreach(HitBoxInstruction hbi in attackInstructions)
				{
					attackOwner.GetHitBox(hbi.HB_recip_name).sendInstruction(hbi);
				}
			
			}
		}

	}
}

