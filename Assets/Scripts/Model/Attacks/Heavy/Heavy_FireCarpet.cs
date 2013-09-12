using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_FireCarpet: Attack_Projectile
	{	
		public Heavy_FireCarpet(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{

			//this.instructions.Add(new ProjectileHitBoxInstruction( "MilkySpore", "r_wrist_jnt", new Vector3(1.0f, 0.0f, 0.0f), 10.0f, attackOwner, 2.0f, 10.0f, 0.7f, 2.0f ));
			//this.instructions.Add(new ProjectileHitBoxInstruction( "Projectile_Cube", "r_wrist_jnt", new Vector3(1.0f, 0.0f, 0.0f), 10.0f, attackOwner, 2.0f, 10.0f, 0.9f, 2.2f ));
			//this.instructions.Add(new ProjectileHitBoxInstruction( "Projectile_Cube", "r_wrist_jnt", new Vector3(1.0f, 0.0f, 0.0f), 10.0f, attackOwner, 2.0f, 10.0f, 1.1f, 2.4f ));

			this.AddInstruction(new ProjectileHitBoxInstruction(
				"Heavy_projectile", 				// projectile name
				"r_wrist_jnt", 					// starting joint
				new Vector3(1.0f, 0.0f, 0.0f), 	// direction
				10.0f, 							// speed
				attackOwner, 					// A_fighter
				2.0f, 							// radius
				3.0f, 							// damage
				0.8f, 							// startTime
				5.0f,							// endTime
				new Vector3(2.0f, 0.0f, 0.0f),	// offset
				new Vector3(-0.15f, 0.0f, 0.0f)	// movement
				));
		}
	}
}