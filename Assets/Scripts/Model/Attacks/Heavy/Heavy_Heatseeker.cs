using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_HeatSeeker: Attack_Projectile
	{	
		public Heavy_HeatSeeker(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			ProjectileHitBoxInstruction missile1 = new ProjectileHitBoxInstruction(
				"heavy_missile", 					// projectile name
				"r_shoulder_jnt", 					// starting joint
				new Vector3(.45f, .80f, 0.0f), 		// direction
				15.0f, 								// speed
				attackOwner, 						// A_fighter
				2.0f, 								// radius
				3.0f, 								// damage
				0.7f, 								// startTime
				5.0f,								// endTime
				new Vector3(0.0f, 0.0f, 0.0f),		// offset
				new Vector3(0.0f, 0.0f, 0.0f)		// movement
				);
			missile1.onCollisionSound = GameManager.Sounds.Sheep;
			missile1.onStartSound = GameManager.Sounds.HeavyMissile;
			this.AddInstruction(missile1);				
		}
	}
}

