using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_TriplePunch: A_Attack
	{	
		public Heavy_TriplePunch(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.instructions.Add(new JointHitBoxInstruction(
				"l_wrist_jnt", 					// joint
				attackOwner, 					// fighter
				3.0f, 							// radius
				2.0f,							// damage
				0.08f, 							// startTime
				0.5f,  							// endTime
				Vector3.zero,					// offset
				new Vector3( 0.0f, 0.0f, 0.0f )// movement
				));			
			this.instructions.Add(new JointHitBoxInstruction(
				"r_wrist_jnt", 					// joint
				attackOwner, 					// fighter
				3.0f, 							// radius
				2.0f,							// damage
				1.0f, 							// startTime
				1.4f,  							// endTime
				Vector3.zero,					// offset
				new Vector3( 0.0f, 0.0f, 0.0f )// movement
				));

		}
	}
}

