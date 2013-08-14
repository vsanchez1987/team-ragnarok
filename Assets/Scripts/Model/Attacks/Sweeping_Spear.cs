using UnityEngine;
using System.Collections;
using FightGame;

namespace FightGame
{
	public class Sweeping_Spear: A_Attack
	{
		public Sweeping_Spear(string animationName, float attackLength, A_Fighter attackOwner) : base(attackOwner)
		{
			this.animationName = animationName;
		}
		/*
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
		*/
		public override void Execute ()
		{
			timer += Time.deltaTime;
		}
	}
}

