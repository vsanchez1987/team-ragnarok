using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Amaterasu_LightFlash: Attack_Mixed
	{	
		//spinning low kick
		public Amaterasu_LightFlash(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			//JointHitBoxInstruction(joint,attackowner,radius,damage,starttime,endtime,offset,movement)
			//ProjectileHitBoxInstruction(projectilename,starting joint,direction,speed,attackowner,radius,damage,starttime,endtime,offset,movement
			this.instructions.Add(new JointHitBoxInstruction(
				"r_ball_jnt", 		//joint
				attackOwner, 		//fighter
				2.0f, 				//radius
				5.0f, 				//damage
				0.2f, 				//start time 
				3.0f, 				//end time
				Vector3.zero, 		//offset
				Vector3.zero 		//movement
				));

			this.instructions.Add(new ProjectileHitBoxInstruction(
				"Projectile_Cube", 				// projectile name
				"spine1_jnt",				
				new Vector3(1.0f, 0.0f, 0.0f), 	// direction
				10.0f, 							// speed
				attackOwner, 					// A_fighter
				3.0f, 							// radius
				1.0f, 							// damage
				0.2f, 							// startTime
				0.8f,							// endTime
				new Vector3(-2.0f, -2.0f, 0.0f),// offset
				new Vector3(0.0f, 0.0f, 0.0f)	// movement
				));		
		}
	}
}

