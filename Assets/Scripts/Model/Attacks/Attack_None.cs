using UnityEngine;
using System.Collections;
using FightGame;

namespace FightGame
{
	public class Attack_None: A_Attack
	{
		public Attack_None(string animationName, A_Fighter attackOwner) : base(animationName, attackOwner)
		{
			this.animationName = animationName;
		}
		
		public override void Execute ()
		{
			this.timer += Time.deltaTime;
		}
	}
}

