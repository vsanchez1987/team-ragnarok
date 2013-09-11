using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Attack_Mixed : A_Attack
	{
		public Attack_Mixed (string animationName, float animationSpeed, A_Fighter attackOwner) : base (animationName, animationSpeed, attackOwner) { }
		
		public override void Init(){
			foreach (A_HitBoxInstruction hbi in this.instructions){
				hbi.Init();
			}
			base.Init();
		}
		
		public void AddInstruction ( A_HitBoxInstruction hbi ){
			this.instructions.Add( hbi );
		}
	}
}

