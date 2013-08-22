using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_MegatonPunch: A_Attack
	{	
		public Heavy_MegatonPunch(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.instructions.Add(new JointHitBoxInstruction(
				"r_wrist_jnt", 					// joint
				attackOwner, 					// fighter
				new Vector3(2.0f, 0.0f, 0.0f), 	// offset
				3.0f, 							// radius
				20.0f,							// damage
				1.3f, 							// startTime
				1.8f ) 							// endTime
				);
			this.instructions.Add(new JointHitBoxInstruction(
				"r_wrist_jnt", 					// joint
				attackOwner, 					// fighter
				new Vector3(2.0f, 0.0f, 0.0f), 	// offset
				3.0f, 							// radius
				20.0f,							// damage
				1.9f, 							// startTime
				2.2f ) 							// endTime
				);
		}
	}
}

