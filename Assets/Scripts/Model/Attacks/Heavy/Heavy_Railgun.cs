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
				new Vector3(1.0f, 0.0f, 0.0f), 	// direction
				20.0f, 							// speed
				attackOwner, 					// A_fighter
				4.5f, 							// radius
				4.0f, 							// damage
				3.0f, 							// startTime
				8.0f,  							// endTime
				new Vector3(-3.0f, 1.2f, 0.0f),	// offset
				new Vector3(0.0f, 0.0f, 0.0f)	// movement							
				));
			this.instructions.Add(new ProjectileHitBoxInstruction(
				"Projectile_Cube", 				// projectile name
				"head_jnt", 					// starting joint
				new Vector3(1.0f, 0.0f, 0.0f), 	// direction
				20.0f, 							// speed
				attackOwner, 					// A_fighter
				4.5f, 							// radius
				4.0f, 							// damage
				3.2f, 							// startTime
				8.0f,  							// endTime
				new Vector3(-3.0f, 0.0f, 0.0f),	// offset
				new Vector3(0.0f, 0.0f, 0.0f)	// movement							
				));
			this.instructions.Add(new ProjectileHitBoxInstruction(
				"Projectile_Cube", 				// projectile name
				"head_jnt", 					// starting joint
				new Vector3(1.0f, 0.0f, 0.0f), 	// direction
				20.0f, 							// speed
				attackOwner, 					// A_fighter
				4.5f, 							// radius
				4.0f, 							// damage
				3.4f, 							// startTime
				8.0f,  							// endTime
				new Vector3(-3.0f, 0.0f, 0.0f),	// offset
				new Vector3(0.0f, 0.0f, 0.0f)	// movement							
				));
		}
		public override void SpecialExecute(){
			this.attackOwner.cur_meter = 0f;
		}
	}
}

