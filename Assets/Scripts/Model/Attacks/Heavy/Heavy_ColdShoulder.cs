using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_ColdShoulder: A_Attack
	{	
		public Heavy_ColdShoulder(string animationName, A_Fighter attackOwner) : base(animationName, attackOwner)
		{
			this.instructions.Add(new JointHitBoxInstruction( "l_elbow_jnt", attackOwner, new Vector3(0.0f, 0.0f, 0.0f), 5.0f, 20.0f, 0.5f, 1.0f ) );
		}
	}
}