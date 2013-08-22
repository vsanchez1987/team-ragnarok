using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_FireCarpet: A_Attack
	{	
		public Heavy_FireCarpet(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.instructions.Add(new ProjectileHitBoxInstruction(
				"Projectile_Cube", 				// projectile name
				"r_wrist_jnt", 					// starting joint
				new Vector3(1.0f, 0.0f, 0.0f), 	// direction
				10.0f, 							// speed
				attackOwner, 					// A_fighter
				2.0f, 							// radius
				1.0f, 							// damage
				0.7f, 							// startTime
				2.0f ) 							// endTime
				);
		}
	}
}