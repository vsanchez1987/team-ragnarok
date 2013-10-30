using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Attack_Projectile : A_Attack
	{
		public Attack_Projectile (string animationName, float animationSpeed, A_Fighter attackOwner) : base(animationName, animationSpeed, attackOwner) {
			this.attackType = "ranged";
			this.recoilStrength = 0;
		}
		
		public void AddInstruction ( ProjectileHitBoxInstruction hbi ){
			base.AddInstruction( hbi );
		}
	}
}

