using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_Railgun: Attack_Projectile
	{
		private GameObject fire1;
		private GameObject fire2;
		public Heavy_Railgun(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.AddInstruction(new ProjectileHitBoxInstruction(
				"Heavy_projectile_railgun", 			// projectile name
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
			this.AddInstruction(new ProjectileHitBoxInstruction(
				"Heavy_projectile", 			// projectile name
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
			this.AddInstruction(new ProjectileHitBoxInstruction(
				"Heavy_projectile_railgun", 			// projectile name
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
		
		public override void Init(){
			GameObject effect1 = Resources.Load("Effect/heavy_railgun_effect1", typeof(GameObject)) as GameObject;
			//GameObject effect2 = Resources.Load("Effect/heavy_railgun_effect2", typeof(GameObject)) as GameObject;
			this.fire1 = GameObject.Instantiate(effect1,this.attackOwner.joints["head_jnt"].position,
			 Quaternion.Euler(new Vector3(0.0f, -90.0f * this.attackOwner.GlobalForwardVector.x, 0.0f))) as GameObject;
			/*
			this.fire2 = GameObject.Instantiate(effect2, new Vector3(this.attackOwner.joints["head_jnt"].position.x, 
				this.attackOwner.joints["head_jnt"].position.y,this.attackOwner.joints["head_jnt"].position.z),
				Quaternion.Euler(new Vector3(0.0f, 90.0f * this.attackOwner.GlobalForwardVector.x, 0.0f))) as GameObject;
			*/
			GameObject.Destroy(this.fire1, (4.0f/this.speed));
			//GameObject.Destroy(this.fire2, (4.0f/this.speed));
			
			base.Init();
		}
		
		public override void SpecialExecute(){
			//this.attackOwner.cur_meter--;
		}
	}
}

