using UnityEngine;
using System.Collections;
using FightGame;

namespace FightGame
{
	public class Attack_MegatonPunch: A_Attack
	{	
		public Attack_MegatonPunch(string animationName, float attackLength, A_Fighter attackOwner) : base(attackOwner)
		{
			this.animationName = animationName;
			//base.attack_name=attack_name;
			//_---------------------------------

			//JONATHAN'S ORIGINAL CODE
			/*
			this.preAttackPeriod = preAttackPeriod;
			this.attackPeriod = attackPeriod;
			this.animationDuration = animationDuration;
			this.postAttackPeriod = animationDuration - (preAttackPeriod + attackPeriod);	
			*/
			this.instructions.Add(new JointHitBoxInstruction(attackOwner.hitBoxes["RightHand"], attackOwner.joints["RightHand"], 0.5f, 0.6f));
		}
		
		public override void Execute ()
		{
			this.timer += Time.deltaTime;
		}
	}
}

