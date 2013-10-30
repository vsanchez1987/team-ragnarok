using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_TriplePunch: Attack_Melee
	{	
		public Heavy_TriplePunch(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.AddInstruction(new JointHitBoxInstruction(
				"l_wrist_jnt", 					// joint
				attackOwner, 					// fighter
				3.0f, 							// radius
				2.0f,							// damage
				0.35f, 							// startTime
				0.6f,  							// endTime
				Vector3.zero,					// offset
				new Vector3( 0.0f, 0, 0 )		// movement
				));			
			this.AddInstruction(new JointHitBoxInstruction(
				"r_wrist_jnt", 					// joint
				attackOwner, 					// fighter
				3.0f, 							// radius
				2.0f,							// damage
				0.85f, 							// startTime
				1.2f,  							// endTime
				Vector3.zero,					// offset
				new Vector3( 0.1f, 0, 0 )		// movement
				));
			
			this.AddInstruction(new JointHitBoxInstruction(
				"l_wrist_jnt", 					// joint
				attackOwner, 					// fighter
				3.0f, 							// radius
				2.0f,							// damage
				1.5f, 							// startTime
				1.9f,  							// endTime
				Vector3.zero,					// offset
				new Vector3( 0.2f, 0, 0 )		// movement
				));	
		}
	}
}

