using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Attack_SelfBuff : A_Attack
	{
		private bool activated;
		protected A_Buff buff;
		
		public Attack_SelfBuff (string animationName, float animationSpeed, A_Fighter attackOwner) : base (animationName, animationSpeed, attackOwner)
		{
			this.activated = false;
		}
		
		public override void Execute(){
			if (!this.activated){
				this.owner.AddBuff(this.buff);
				this.activated = true;
			}
			this.timer += Time.deltaTime;
		}
		
		public override void Reset(){ 
			this.activated = false;
			this.timer = 0.0f;
		}
	}
}

