using UnityEngine;
using System.Collections;
using FightGame;

namespace FightGame
{
	public class Attack_MegatonPunch: A_Attack
	{	
		public Attack_MegatonPunch(string animationName, A_Fighter attackOwner) : base(animationName, attackOwner)
		{
			//this.instructions.Add(new JointHitBoxInstruction(attackOwner.joints["r_wrist_jnt"], attackOwner.hitBoxes["Hitbox1"], 5.0f, 10.0f, 0.7f, 1.0f));
		}
		
		public override void Execute ()
		{
			this.timer += Time.deltaTime;
		}
	}
}

