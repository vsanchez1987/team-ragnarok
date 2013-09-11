using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_NapalmFlameThrower: Attack_Projectile
	{	
		public Heavy_NapalmFlameThrower(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.AddInstruction(new ProjectileHitBoxInstruction(
				"Projectile_Cube", 					// projectile name
				"l_wrist_jnt", 						// starting joint
				new Vector3(1.0f, 0.0f, 0.0f), 		// direction
				0.5f, 								// speed
				attackOwner, 						// A_fighter
				1.0f, 								// radius
				1.0f, 								// damage
				0.4f, 								// startTime
				1.6f,  								// endTime
				new Vector3(-1.2f, 0.0f, 0.0f),		// offset
				new Vector3(0.0f, 0.0f, 0.0f)		// movement
				));
			this.AddInstruction(new ProjectileHitBoxInstruction(
				"Projectile_Cube", 					// projectile name
				"l_wrist_jnt", 						// starting joint
				new Vector3(1.0f, 0.0f, 0.0f), 		// direction
				0.5f, 								// speed
				attackOwner, 						// A_fighter
				1.0f, 								// radius
				1.0f, 								// damage
				0.4f, 								// startTime
				1.6f,  								// endTime
				new Vector3(-1.8f, 0.4f, 0.0f),		// offset
				new Vector3(0.0f, 0.0f, 0.0f)		// movement
				));
			this.AddInstruction(new ProjectileHitBoxInstruction(
				"Projectile_Cube", 					// projectile name
				"l_wrist_jnt", 						// starting joint
				new Vector3(1.0f, 0.0f, 0.0f), 		// direction
				0.5f, 								// speed
				attackOwner, 						// A_fighter
				1.0f, 								// radius
				1.0f, 								// damage
				0.5f, 								// startTime
				1.6f,  								// endTime
				new Vector3(-2.4f, 0.0f, 0.0f),		// offset
				new Vector3(0.0f, 0.0f, 0.0f)		// movement
				));
			this.AddInstruction(new ProjectileHitBoxInstruction(
				"Projectile_Cube", 					// projectile name
				"l_wrist_jnt", 						// starting joint
				new Vector3(1.0f, -0.4f, 0.0f), 	// direction
				0.5f, 								// speed
				attackOwner, 						// A_fighter
				2.0f, 								// radius
				1.0f, 								// damage
				0.5f, 								// startTime
				1.6f,  								// endTime
				new Vector3(-3.0f, 0.6f, 0.0f),		// offset
				new Vector3(0.0f, 0.0f, 0.0f)		// movement
				));
		}
	}
}

