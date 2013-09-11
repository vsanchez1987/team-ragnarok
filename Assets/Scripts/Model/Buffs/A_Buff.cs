using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public abstract class A_Buff
	{
		public		string		name;
		private 	float 		timer;
		private 	float 		duration;
		private 	bool		activated;
		protected 	A_Fighter 	attackOwner;
		protected	float		chargeTime;
		
		public A_Buff ( float duration, A_Fighter attackOwner, string name, float chargeTime )
		{
			this.timer 		= 0.0f;
			this.duration 	= duration;
			this.activated 	= false;
			this.attackOwner 		= attackOwner;
			this.name		= name;
			this.chargeTime = chargeTime;
		}
		
		protected abstract void ApplyBuff();
		
		public virtual bool CheckFinished(){
			if (this.timer >= duration){
				return true;
			}
			return false;
		}
		
		public void Update(){
			if (!this.activated && this.timer >= chargeTime){
				this.ApplyBuff();
				this.activated = true;
			}
			this.timer += Time.deltaTime;
		}
		
		public virtual void DeActivate(){
			this.timer = 0.0f;
			this.activated = false;
		}
	}
}

