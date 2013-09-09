using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Amaterasu_LightFlash: A_Attack
	{	
		public Amaterasu_LightFlash(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			//JointHitBoxInstruction(joint,attackowner,radius,damage,starttime,endtime,offset,movement)
			//ProjectileHitBoxInstruction(projectilename,starting joint,direction,speed,attackowner,radius,damage,starttime,endtime,offset,movement
			this.instructions.Add(new JointHitBoxInstruction("r_ball_jnt",attackOwner,2.0f,5.0f,0.2f,3f,Vector3.zero,Vector3.zero));
			
			this.instructions.Add(new ProjectileHitBoxInstruction(
				"Amaterasu_projectile", 				// projectile name
				"r_ball_jnt",				
				new Vector3(1.0f, 0.0f, 0.0f), 	// direction
				10.0f, 							// speed
				attackOwner, 					// A_fighter
				3.0f, 							// radius
				1.0f, 							// damage
				0.2f, 							// startTime
				1.0f,							// endTime
				new Vector3(0.0f, 0.0f, 0.0f),	// offset
				new Vector3(0.0f, 0.0f, 0.0f)	// movement
				));		
		}
	}
}

