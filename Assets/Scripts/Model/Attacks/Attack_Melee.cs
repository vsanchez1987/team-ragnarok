using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Attack_Melee : A_Attack
	{
		public Attack_Melee (string animationName, float animationSpeed, A_Fighter attackOwner) : base (animationName, animationSpeed, attackOwner) {
			this.attackType = "melee";
		}
		
		public void AddInstruction ( JointHitBoxInstruction hbi ){
			base.AddInstruction( hbi );
		}
	}
}

