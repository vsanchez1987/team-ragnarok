using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Attack_coldShoulder: A_Attack
	{
		float attackDuration = 3.0f;
		string attack_name = "cold_shoulder";
		bool moving = false;
		Vector3 origin,desire,dest;
		
		public Attack_coldShoulder (A_Fighter attackOwner, float preAttackPeriod = 0.0f, float attackPeriod = 0.0f, float animationDuration = 0.0f):base(attackPeriod,attackOwner)
		{
			base.attack_name=attack_name;
			//_---------------------------------
			
			//HB_Instruction(attackOwner, keyframe, "hitbox Name", damage, radius, attackMechanic, Particle)

			// ********* this goes in attacks that inherit A_Attack		
			HB_KeyFrame onOffTime;  
			List<HB_KeyFrame> keyFrames; 
			HB_Instruction hbInstruct;
						
			// Right Fist
			keyFrames = new List<HB_KeyFrame>();
			keyFrames.Add(new HB_KeyFrame(0.35f,1.8f));
			hbInstruct =  new HB_Instruction(attackOwner,keyFrames,"HB_Fist_R",20.0f,0.8f,null,null);
			base.hb_instructions.Add(hbInstruct);
			
			///Left Fist
			keyFrames = new List<HB_KeyFrame>();
			keyFrames.Add(new HB_KeyFrame(0.35f,1.8f));
			hbInstruct =  new HB_Instruction(attackOwner,keyFrames,"HB_Fist_L",20.0f,0.8f,null,null);					
			base.hb_instructions.Add(hbInstruct);		

			//JONATHAN'S ORIGINAL CODE
			this.preAttackPeriod = preAttackPeriod;
			this.attackPeriod = attackPeriod;
			this.animationDuration = animationDuration;
			this.postAttackPeriod = animationDuration - (preAttackPeriod + attackPeriod);	
		}
		
		public override void Execute ()
		{
			
			base.Execute ();
		}
		
		public override void SpecialExecute(float time)
		{
			if(time >= 0.8f && time <= 1.0f)
			{
				attackOwner.gob.transform.Translate(attackOwner.localForwardVector*30f*Time.deltaTime);
			}
		}
		
	}
}

