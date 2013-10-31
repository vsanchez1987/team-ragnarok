using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Amaterasu_SpinningHookKick: Attack_Melee
	{	
		public Amaterasu_SpinningHookKick(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.AddInstruction(new JointHitBoxInstruction(
				"r_ball_jnt", 				
				attackOwner, 					// fighter
				3.0f, 							// radius
				2.0f,							// damage
				0.7f, 							// startTime
				1.0f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.05f, 0.0f, 0.0f)
				));
			recoilStrength = 2.0f;
		}
	}
}

