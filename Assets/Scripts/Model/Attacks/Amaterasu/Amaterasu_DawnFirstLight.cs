using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Amaterasu_DawnFirstLight: A_Attack
	{	
		public Amaterasu_DawnFirstLight(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			
			this.instructions.Add(new JointHitBoxInstruction(
				"r_knee_jnt", 				
				attackOwner, 					// fighter
				1.5f, 							// radius
				1.5f,							// damage
				0.3f, 							// startTime
				1.0f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.0f, 0.0f, 0.0f)
				));
		}
	}
}

