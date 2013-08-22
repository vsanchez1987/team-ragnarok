using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_MegatonPunch: A_Attack
	{	
		public Heavy_MegatonPunch(string animationName, A_Fighter attackOwner) : base(animationName, attackOwner)
		{
			this.instructions.Add(new JointHitBoxInstruction( "r_wrist_jnt", attackOwner, new Vector3(2.0f, 0.0f, 0.0f), 3.0f, 20.0f, 1.3f, 1.8f ) );
		}
	}
}

