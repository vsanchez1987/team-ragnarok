using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Attack_Mixed : A_Attack
	{
		public Attack_Mixed (string animationName, float animationSpeed, A_Fighter attackOwner) : base (animationName, animationSpeed, attackOwner) { }
		
		public override void AddInstruction ( A_HitBoxInstruction hbi ){
			base.AddInstruction( hbi );
		}
	}
}

