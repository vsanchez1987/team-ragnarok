using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Amaterasu_AxeKick: Attack_Melee
	{	
		public Amaterasu_AxeKick(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.AddInstruction(new JointHitBoxInstruction(
				"r_knee_jnt", 				
				attackOwner, 					// fighter
				1.50f, 							// radius
				2.0f,							// damage
				0.2f, 							// startTime
				0.4f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.05f, 0.0f, 0.0f)
				));		
			
			this.AddInstruction(new JointHitBoxInstruction(
				"l_ball_jnt", 				
				attackOwner, 					// fighter
				1.50f, 							// radius
				2.0f,							// damage
				0.4f, 							// startTime
				0.6f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.05f, 0.0f, 0.0f)
				));
			
			this.AddInstruction(new JointHitBoxInstruction(
				"l_ball_jnt", 				
				attackOwner, 					// fighter
				1.50f, 							// radius
				3.0f,							// damage
				0.8f, 							// startTime
				1.0f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.0f, 0.0f, 0.0f)
				));
			
			this.AddInstruction(new JointHitBoxInstruction(
				"l_ball_jnt", 				
				attackOwner, 					// fighter
				1.50f, 							// radius
				5.0f,							// damage
				1.2f, 							// startTime
				1.4f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.0f, 0.0f, 0.0f)
				));
			this.AddInstruction(new JointHitBoxInstruction(
				"l_ball_jnt", 				
				attackOwner, 					// fighter
				1.50f, 							// radius
				5.0f,							// damage
				1.6f, 							// startTime
				1.8f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.0f, 0.0f, 0.0f)
				));
		}
		
	}
}

