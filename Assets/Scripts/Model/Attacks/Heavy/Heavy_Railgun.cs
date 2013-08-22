using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_Railgun: A_Attack
	{
		public Heavy_Railgun(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.instructions.Add(new ProjectileHitBoxInstruction(
				"Projectile_Cube", 				// projectile name
				"head_jnt", 					// starting joint
				new Vector3(2.0f, 0.0f, 0.0f), 	// direction
				15.0f, 							// speed
				attackOwner, 					// A_fighter
				5.0f, 							// radius
				10.0f, 							// damage
				3.0f, 							// startTime
				8.0f  							// endTime
				));
		}
	}
}

