using UnityEngine;
using System.Collections;
using FightGame;

namespace FightGame
{
	public class Shield_Swipe: A_Attack
	{
		float attackDuration = 3.0f;
		public string attack_name = "Shield_Swipe";
		
		public Shield_Swipe(A_Fighter attackOwner, float preAttackPeriod, 
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

