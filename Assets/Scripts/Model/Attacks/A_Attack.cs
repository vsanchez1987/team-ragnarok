using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public abstract class A_Attack
	{
		public		float						timer;
		public		float						attackLength;
		public 		string 						animationName;
		public	 	List<A_HitBoxInstruction>	instructions;
		public		float						animationSpeed;
		protected 	A_Fighter 					attackOwner;
		
		protected A_Attack( string animationName, float animationSpeed, A_Fighter attackOwner )
		{
			this.timer				= timer;
			this.instructions 		= new List<A_HitBoxInstruction>();
			this.attackOwner		= attackOwner;
			this.animationName 		= animationName;
			this.animationSpeed		= animationSpeed;
			
			if (attackOwner.gobj.animation.GetClip(animationName) != null){
				this.attackLength  = attackOwner.gobj.animation[animationName].clip.length;
			}
		}
		
		public virtual void Execute(){
			this.timer += Time.deltaTime;
		}
		
		public void Reset(){
			foreach (A_HitBoxInstruction hbi in this.instructions){
				hbi.Reset();
			}
		}
	}
}

