using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Attack_Shot04: A_Attack
	{
		float attackDuration = 3.0f;
		string attack_name = "rail_gun";
		
		public Attack_Shot04 (A_Fighter attackOwner, float preAttackPeriod = 0.0f, float attackPeriod = 0.0f, float animationDuration = 0.0f):base(attackPeriod,attackOwner)
		{
			base.attack_name=attack_name;
			//_---------------------------------
			
			//HB_Instruction(attackOwner, keyframe, "hitbox Name", damage, radius, attackMechanic, Particle)

			// ********* this goes in attacks that inherit A_Attack		
			HB_KeyFrame onOffTime;  
			List<HB_KeyFrame> keyFrames; 
			HB_Instruction hbInstruct;
			//JONATHAN'S ORIGINAL CODE
			this.preAttackPeriod = preAttackPeriod;
			this.attackPeriod = attackPeriod;
			this.animationDuration = animationDuration;
			this.postAttackPeriod = animationDuration - (preAttackPeriod + attackPeriod);		
						
			// PROJECTILE ATTACK EXAMPLE
			// *************************************
			keyFrames = new List<HB_KeyFrame>();
			keyFrames.Add(new HB_KeyFrame(0.0f,8.0f)); //turn on, turn off keyframe
			//hbInstruct =  new HB_Instruction(attackOwner,keyFrames,"P_MilkySpore",20.0f,1.5f,null,null);
			hbInstruct =  new HB_Instruction(attackOwner,keyFrames,"P_MilkySpore",5.0f,1.5f,0.2f,new Vector3(1,0,0),new Vector3(0,5,0),null,null);
			base.hb_instructions.Add(hbInstruct);
		}
		
		public override void Execute ()
		{
			base.Execute ();
			
		}
	}
}

