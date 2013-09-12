using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_MegatonPunch: Attack_Melee
	{	
		public Heavy_MegatonPunch(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.AddInstruction(new JointHitBoxInstruction(
				"r_wrist_jnt", 					// joint
				attackOwner, 					// fighter
				5.0f, 							// radius
				3.0f,							// damage
				1.5f, 							// startTime
				2.3f, 							// endTime
				new Vector3(1.0f, 0.0f, -3.0f),	// offset
				new Vector3(0.2f, 0.0f, 0.0f),	// extraMovement
				true							// knockdown
				));
		}
	}
}

