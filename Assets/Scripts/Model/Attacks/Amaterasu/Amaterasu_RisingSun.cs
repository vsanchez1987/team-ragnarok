using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Amaterasu_RisingSun: A_Attack
	{	
		public Amaterasu_RisingSun(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.instructions.Add(new JointHitBoxInstruction(
				"r_ball_jnt", 				
				attackOwner, 					// fighter
				1.50f, 							// radius
				2.0f,							// damage
				0.4f, 							// startTime
				0.8f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.1f, 0.0f, 0.0f)
				));		
			
			this.instructions.Add(new JointHitBoxInstruction(
				"l_ball_jnt", 				
				attackOwner, 					// fighter
				1.50f, 							// radius
				2.0f,							// damage
				0.9f, 							// startTime
				1.5f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.15f, 0.0f, 0.0f)
				));
			
			this.instructions.Add(new JointHitBoxInstruction(
				"l_ball_jnt", 				
				attackOwner, 					// fighter
				1.50f, 							// radius
				3.0f,							// damage
				2.2f, 							// startTime
				3.0f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.0f, 0.0f, 0.0f)
				));
			
			this.instructions.Add(new JointHitBoxInstruction(
				"r_ball_jnt", 				
				attackOwner, 					// fighter
				1.50f, 							// radius
				5.0f,							// damage
				2.2f, 							// startTime
				3.0f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.5f, 0.0f, 0.0f)
				));
			
		}
	}
}

