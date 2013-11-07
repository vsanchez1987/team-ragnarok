using UnityEngine;
using System.Collections;
using FightGame;


//unique range attack - up
namespace FightGame{	
	public class Odin_RavenStorm : Attack_Projectile{
		public Odin_RavenStorm(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner){
			
			ProjectileHitBoxInstruction raven1 = new ProjectileHitBoxInstruction(
				"odin_ravens", 			// projectile name
				"neck_jnt", 						// starting joint
				new Vector3(.45f, .80f, 0.0f), 		// direction
				10.0f, 								// speed
				attackOwner, 						// A_fighter
				2.0f, 								// radius
				2.0f, 								// damage
				0.7f, 								// startTime
				5.0f,								// endTime
				new Vector3(0.0f, 0.0f, 0.0f),		// offset
				new Vector3(0.0f, 0.0f, 0.0f)		// movement
				);
			ProjectileHitBoxInstruction raven2 = new ProjectileHitBoxInstruction(
				"odin_ravens", 			// projectile name
				"neck_jnt", 						// starting joint
				new Vector3(-.45f, .80f, 0.0f), 		// direction
				10.0f, 								// speed
				attackOwner, 						// A_fighter
				2.0f, 								// radius
				2.0f, 								// damage
				0.7f, 								// startTime
				5.0f,								// endTime
				new Vector3(0.0f, 0.0f, 0.0f),		// offset
				new Vector3(0.0f, 0.0f, 0.0f)		// movement
				);
			ProjectileHitBoxInstruction raven3 = new ProjectileHitBoxInstruction(
				"odin_ravens", 			// projectile name
				"neck_jnt", 						// starting joint
				new Vector3(0, 1f, 0.0f), 		// direction
				10.0f, 								// speed
				attackOwner, 						// A_fighter
				2.0f, 								// radius
				2.0f, 								// damage
				0.7f, 								// startTime
				5.0f,								// endTime
				new Vector3(0.0f, 0.0f, 0.0f),		// offset
				new Vector3(0.0f, 0.0f, 0.0f)		// movement
				);
			ProjectileHitBoxInstruction raven4 = new ProjectileHitBoxInstruction(
				"odin_ravens", 			// projectile name
				"neck_jnt", 						// starting joint
				new Vector3(.45f, .45f, 0.0f), 		// direction
				10.0f, 								// speed
				attackOwner, 						// A_fighter
				2.0f, 								// radius
				2.0f, 								// damage
				0.7f, 								// startTime
				5.0f,								// endTime
				new Vector3(0.0f, 0.0f, 0.0f),		// offset
				new Vector3(0.0f, 0.0f, 0.0f)		// movement
				);
			ProjectileHitBoxInstruction raven5 = new ProjectileHitBoxInstruction(
				"odin_ravens", 			// projectile name
				"neck_jnt", 						// starting joint
				new Vector3(-0.45f, .45f, 0.0f), 		// direction
				10.0f, 								// speed
				attackOwner, 						// A_fighter
				2.0f, 								// radius
				2.0f, 								// damage
				0.7f, 								// startTime
				5.0f,								// endTime
				new Vector3(0.0f, 0.0f, 0.0f),		// offset
				new Vector3(0.0f, 0.0f, 0.0f)		// movement
				);
			this.AddInstruction(raven1);
			this.AddInstruction(raven2);
			this.AddInstruction(raven3);
			this.AddInstruction(raven4);
			this.AddInstruction(raven5);
			
		}
	}
}
