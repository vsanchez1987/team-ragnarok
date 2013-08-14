using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Attack_Melee: A_Attack
	{
		public Attack_Melee(string animationName, float attackLength, A_Fighter attackOwner) : base(attackOwner)
		{
			this.animationName = animationName;
		}
		
		public override void Execute ()
		{
			this.timer += Time.deltaTime;
		}
		/*
		float attackDuration = 3.0f;
		string attack_name = "melee";
		
		public Attack_Melee (A_Fighter attackOwner, float preAttackPeriod = 0.0f, float attackPeriod = 0.0f, float animationDuration = 0.0f):base(attackPeriod,attackOwner)
		{
			
			base.attack_name=attack_name;
			//_---------------------------------
			
			// NEW HITBOX CODE 7/23
			
			// HOW TO SCRIPT ATTACKS
			// ********* this goes in attacks that inherit A_Attack		
			HB_KeyFrame onOffTime;  
			List<HB_KeyFrame> keyFrames; 
			HB_Instruction hbInstruct;
			
			
			// ****************************************
			//  MELEE ATTACK EXAMPLE
			// ****************************************
			// construct a list of on and off times
			keyFrames = new List<HB_KeyFrame>();
			keyFrames.Add(new HB_KeyFrame(0.0f,1.0f));
			keyFrames.Add(new HB_KeyFrame(2.0f,4.0f));
			
			
			// compose hitbox instruction
			hbInstruct =  new HB_Instruction(attackOwner,keyFrames,"HB_Fist_L",20.0f,1.0f,null,null);
			base.hb_instructions.Add(hbInstruct);
			
			
			
			// *************************************
			// PROJECTILE ATTACK EXAMPLE
			// *************************************
			keyFrames = new List<HB_KeyFrame>();
			keyFrames.Add(new HB_KeyFrame(0.0f,attackLength));
			
			hbInstruct =  new HB_Instruction(attackOwner,keyFrames,"projectile",20.0f,1.0f,null,null);
			base.hb_instructions.Add(hbInstruct);
			
			// ***
			

			
			//JONATHAN'S ORIGINAL CODE
			this.preAttackPeriod = preAttackPeriod;
			this.attackPeriod = attackPeriod;
			this.animationDuration = animationDuration;
			this.postAttackPeriod = animationDuration - (preAttackPeriod + attackPeriod);
			
			
		}
		*/
	}
}

