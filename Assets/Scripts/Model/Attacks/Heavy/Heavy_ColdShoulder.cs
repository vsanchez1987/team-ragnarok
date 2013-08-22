using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_ColdShoulder: A_Attack
	{	
		public Heavy_ColdShoulder(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.instructions.Add(new JointHitBoxInstruction(
				"l_elbow_jnt", 					// joint
				attackOwner, 					// fighter
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				3.0f, 							// radius
				5.0f,							// damage
				0.35f, 							// startTime
				1.8f  							// endTime
				));
		}
	}
}
