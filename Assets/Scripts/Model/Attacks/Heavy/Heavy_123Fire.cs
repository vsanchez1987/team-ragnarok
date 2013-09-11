using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_123Fire: A_Attack
	{	
		public Heavy_123Fire(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.instructions.Add(new ProjectileHitBoxInstruction(
				"Heavy_projectile", 				// projectile name
				"head_jnt",						// starting joint
				new Vector3(1.0f, 0.0f, 0.0f), 	// direction
				10.0f, 							// speed
				attackOwner, 					// A_fighter
				1.0f, 							// radius
				1.0f, 							// damage
				0.1f, 							// startTime
				5.0f,							// endTime
				new Vector3(2.0f, 0.0f, 0.0f),	// offset
				new Vector3(0.0f, 0.0f, 0.0f)	// movement
				));				
			this.instructions.Add(new ProjectileHitBoxInstruction(
				"Heavy_projectile", 				// projectile name
				"head_jnt",						// starting joint
				new Vector3(1.0f, 0.0f, 0.0f), 	// direction
				10.0f, 							// speed
				attackOwner, 					// A_fighter
				1.0f, 							// radius
				1.0f, 							// damage
				0.8f, 							// startTime
				5.0f,							// endTime
				new Vector3(2.0f, 0.0f, 0.0f),	// offset
				new Vector3(0.0f, 0.0f, 0.0f)	// movement
				));				
			this.instructions.Add(new ProjectileHitBoxInstruction(
				"Heavy_projectile", 				// projectile name
				"head_jnt",						// starting joint
				new Vector3(1.0f, 0.0f, 0.0f), 	// direction
				10.0f, 							// speed
				attackOwner, 					// A_fighter
				1.5f, 							// radius
				3.0f, 							// damage
				1.6f, 							// startTime
				5.0f,							// endTime
				new Vector3(2.0f, 0.5f, 0.0f),	// offset
				new Vector3(0.0f, 0.0f, 0.0f)	// movement
				));
			//move back on each shot fired for short duration 
			this.instructions.Add(new JointHitBoxInstruction("head_jnt", attackOwner,
				0.0f, 0.0f, 0.1f, 0.4f, Vector3.zero, new Vector3(-0.01f,0.0f,0.0f)));
			this.instructions.Add(new JointHitBoxInstruction("head_jnt", attackOwner,
				0.0f, 0.0f, 0.8f, 1.2f, Vector3.zero, new Vector3(-0.01f,0.0f,0.0f)));
			this.instructions.Add(new JointHitBoxInstruction("head_jnt", attackOwner,
				0.0f, 0.0f, 1.8f, 2.0f, Vector3.zero, new Vector3(-0.2f,0.0f,0.0f)));
		}
	}
}

