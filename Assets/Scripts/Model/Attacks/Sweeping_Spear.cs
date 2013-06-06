using UnityEngine;
using System.Collections;
using FightGame;

namespace FightGame
{
	public class Sweeping_Spear: A_Attack
	{
		float attackDuration = 3.0f;
		public string attack_name = "Sweeping_Spear";
		
		public Sweeping_Spear(A_Fighter attackOwner, float preAttackPeriod, 
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

