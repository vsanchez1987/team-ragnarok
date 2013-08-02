using UnityEngine;
using System.Collections;
using FightGame;

namespace FightGame
{
	public class Attack_SweepingSpear: A_Attack
	{
		float attackDuration = 3.0f;
		public string attack_name = "SweepingSpear";
		
		public Attack_SweepingSpear(A_Fighter attackOwner, float preAttackPeriod, 
								float attackPeriod, 
								float animationDuration):base(attackPeriod,attackOwner)
		{
			base.attack_name = attack_name;
			this.preAttackPeriod = preAttackPeriod;
			this.attackPeriod = attackPeriod;
			this.animationDuration = animationDuration;
			this.postAttackPeriod = animationDuration - (preAttackPeriod + attackPeriod);
		}
		public override void Execute ()
		{
			base.Execute ();
			
		}
	}
}

