using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Amaterasu_Backdraft: A_Attack
	{	
		public Amaterasu_Backdraft(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			//range attack, range 1.5, speed med, size med, damage small
			this.instructions.Add(new ProjectileHitBoxInstruction("Projectile_Cube","l_ball_jnt",
				new Vector3(1,0,0), 7.0f,attackOwner,1.0f,1.0f,1.0f,1.5f,Vector3.zero,Vector3.zero));	
			//empty hitbox to cause slide back at start of animation, rather than projectile at spawn.
			this.instructions.Add(new JointHitBoxInstruction("r_ball_jnt", attackOwner,
				0.0f, 0.0f, 0.0f, 0.1f, Vector3.zero, new Vector3(-0.1f,0.0f,0.0f)));								
		}
	}
}

