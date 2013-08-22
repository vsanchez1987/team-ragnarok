using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_FireCarpet: A_Attack
	{	
		public Heavy_FireCarpet(string animationName, A_Fighter attackOwner) : base(animationName, attackOwner)
		{
			this.instructions.Add(new ProjectileHitBoxInstruction( "Projectile_Cube", "r_wrist_jnt", new Vector3(1.0f, 0.0f, 0.0f), 10.0f, attackOwner, 2.0f, 10.0f, 0.7f, 2.0f ));
			this.instructions.Add(new ProjectileHitBoxInstruction( "Projectile_Cube", "r_wrist_jnt", new Vector3(1.0f, 0.0f, 0.0f), 10.0f, attackOwner, 2.0f, 10.0f, 0.9f, 2.2f ));
			this.instructions.Add(new ProjectileHitBoxInstruction( "Projectile_Cube", "r_wrist_jnt", new Vector3(1.0f, 0.0f, 0.0f), 10.0f, attackOwner, 2.0f, 10.0f, 1.1f, 2.4f ));
		}
	}
}