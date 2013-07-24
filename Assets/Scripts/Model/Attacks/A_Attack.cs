using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public abstract class A_Attack
	{
		protected float preAttackPeriod;
		protected float attackPeriod;
		protected float postAttackPeriod;
		protected float animationDuration;
		protected A_Fighter attackOwner;
		
		// NEW HITBOX CODE 7/23
		public List<HB_Instruction> hb_instructions;
		// ***
		
		public string attack_name;
		
		public float attackLength;
		
		public A_Attack(float attackLength,A_Fighter attackOwner)
		{
			
			this.attackLength=attackLength;
			this.attackOwner = attackOwner;
			
			hb_instructions = new List<HB_Instruction>();
			
		}
		
		
		public virtual void Execute()
		{
			UnityEngine.Debug.Log("hit attack");
			
			attackOwner.GetHitBox("HB_Fist_L").SendInstruction(hb_instructions[0]);
			attackOwner.GetHitBox("HB_Foot_L").SendInstruction(hb_instructions[0]);
			attackOwner.GetHitBox("HB_Projectile_0").SendInstruction(hb_instructions[0]);
			//attackOwner.SendHitBoxInstructions(this);
		}

	}
}

