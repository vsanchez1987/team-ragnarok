using UnityEngine;
using System.Collections;
using FightGame;

namespace FightGame
{
	public class Sweeping_Spear: A_Attack
	{
		public Sweeping_Spear(string animationName, A_Fighter attackOwner) : base(animationName, attackOwner)
		{
			//this.instructions.Add(new JointHitBoxInstruction("Character1_RightHand", attackOwner, 1.0f, 10.0f, 0.5f, 0.6f));
			this.instructions.Add(new ProjectileHitBoxInstruction( "Projectile_Cube", "Character1_RightHand", new Vector3(1.0f, 0.0f, 0.0f), 10.0f, attackOwner, 2.0f, 10.0f, 0.5f, 1.0f ));
		}
	}
}

