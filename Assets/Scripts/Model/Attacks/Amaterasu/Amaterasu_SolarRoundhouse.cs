using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Amaterasu_SolarRoundhouse: Attack_Melee
	{	
		public Amaterasu_SolarRoundhouse(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
				this.AddInstruction(new JointHitBoxInstruction(
				"r_ball_jnt", 				
				attackOwner, 					// fighter
				3.0f, 							// radius
				3.5f,							// damage
				0.7f, 							// startTime
				1.35f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.0f, 0.0f, 0.0f)
				));
				recoilStrength = 2.0f;
		}
	}
}

