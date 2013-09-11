using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Attack_Melee : A_Attack
	{
		public Attack_Melee (string animationName, float animationSpeed, A_Fighter attackOwner) : base (animationName, animationSpeed, attackOwner) { }
		
		public override void Init(){
			foreach (A_HitBoxInstruction hbi in this.instructions){
				hbi.Init();
			}
			base.Init();
		}
		
		public void AddInstruction ( JointHitBoxInstruction hbi ){
			this.instructions.Add( hbi );
		}
	}
}

