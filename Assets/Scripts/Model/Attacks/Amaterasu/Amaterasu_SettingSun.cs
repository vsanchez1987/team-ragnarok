using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Amaterasu_SettingSun: A_Attack
	{	
		public Amaterasu_SettingSun(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.instructions.Add(new JointHitBoxInstruction(
				"l_ball_jnt", 				
				attackOwner, 					// fighter
				1.5f, 							// radius
				5.0f,							// damage
				0.1f, 							// startTime
				0.8f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.0f, 0.0f, 0.0f)
				));	
			
			this.instructions.Add(new JointHitBoxInstruction(
				"l_ball_jnt", 				
				attackOwner, 					// fighter
				5f, 							// radius
				7.0f,							// damage
				0.85f, 							// startTime
				1.2f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.0f, 0.0f, 0.0f)
				));	
		}
	}
}

