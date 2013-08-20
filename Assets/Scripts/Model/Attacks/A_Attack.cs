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
		protected 	A_Fighter 					attackOwner;
		
		protected A_Attack( string animationName, A_Fighter attackOwner )
		{
			this.timer				= timer;
			this.instructions 		= new List<A_HitBoxInstruction>();
			this.attackOwner		= attackOwner;
			this.animationName 		= animationName;
			
			if (attackOwner.gobj.animation.GetClip(animationName) != null){
				this.attackLength  = attackOwner.gobj.animation[animationName].clip.length;
			}
		}
		
		public abstract void Execute();
		
		public void Reset(){
			foreach (A_HitBoxInstruction hbi in this.instructions){
				hbi.Reset();
			}
		}
	}
}

