using UnityEngine;
using System.Collections;
using FightGame;

namespace FightGame
{
	public class Attack_Shot01: A_Attack
	{
		float attackDuration = 3.0f;
		string attack_name = "Shot01";
		
		public Attack_Shot01 (A_Fighter attackOwner, float preAttackPeriod = 0.0f, float attackPeriod = 0.0f, float animationDuration = 0.0f):base(attackPeriod,attackOwner)
		{
			base.attack_name=attack_name;
			//_---------------------------------

			//JONATHAN'S ORIGINAL CODE
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
