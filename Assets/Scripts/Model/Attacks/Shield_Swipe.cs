using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Shield_Swipe: A_Attack
	{
		float attackDuration = 3.0f;
		public string attack_name = "Shield_Swipe";
		
		public Shield_Swipe(A_Fighter attackOwner, float preAttackPeriod, 
								float attackPeriod, 
								float animationDuration):base(attackPeriod,attackOwner)
		{
			base.attack_name = attack_name;
			
			
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
			
			
			
			this.preAttackPeriod = preAttackPeriod;
			this.attackPeriod = attackPeriod;
			this.animationDuration = animationDuration;
			this.postAttackPeriod = animationDuration - (preAttackPeriod + attackPeriod);
		}
		public override void Execute ()
		{
			base.Execute ();
			
		}
	}
}

