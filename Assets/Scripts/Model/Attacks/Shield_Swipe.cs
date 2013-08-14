using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Shield_Swipe: A_Attack
	{
		public Shield_Swipe(string animationName, float attackLength, A_Fighter attackOwner) : base(attackOwner)
		{
			this.animationName = animationName;
		}
		/*
		public float attackLength;
		public string animationName;
		public Shield_Swipe(string animationName, float attackLength, A_Fighter attackOwner) : base(attackOwner)
		{
			this.animationName 	= animationName;
			this.attackLength	= attackOwner.gobj.animation[animationName].clip.length;
			
			// NEW HITBOX CODE 7/23
			
			// HOW TO SCRIPT ATTACKS
			// ********* this goes in attacks that inherit A_Attack		
			HB_KeyFrame onOffTime;
			List<HB_KeyFrame> keyFrames;
			HB_Instruction hbInstruct;
			
			
			// ****************************************
			//  MELEE ATTACK EXAMPLE
			// ****************************************
			
			////////////////////////////////
			// RIGHT FOOT
			// construct a list of on and off times
			keyFrames = new List<HB_KeyFrame>();
			keyFrames.Add(new HB_KeyFrame(0.35f,0.6f));
			//keyFrames.Add(new HB_KeyFrame(f,f)); //you can add mutliple keyframes per attack
			// compose hitbox instruction
			hbInstruct =  new HB_Instruction(attackOwner,keyFrames,"HB_Foot_R",20.0f,0.8f,null,null);
			base.hb_instructions.Add(hbInstruct);
			
			
			////////////////////////////////
			// LEFT FOOT
			keyFrames = new List<HB_KeyFrame>();
			keyFrames.Add(new HB_KeyFrame(0.85f,1.0f));
			keyFrames.Add(new HB_KeyFrame(1.15f,1.35f));
			hbInstruct =  new HB_Instruction(attackOwner,keyFrames,"HB_Foot_L",20.0f,0.8f,null,null);
			base.hb_instructions.Add(hbInstruct);		
			/////////////////////////////////////
					
			
			// *************************************
			// PROJECTILE ATTACK EXAMPLE
			// *************************************
			keyFrames = new List<HB_KeyFrame>();
			keyFrames.Add(new HB_KeyFrame(0.0f,2.0f));
			hbInstruct =  new HB_Instruction(attackOwner,keyFrames,"projectile",20.0f,1.5f,null,null);
			base.hb_instructions.Add(hbInstruct);
			
			
		}*/
	
		public override void Execute ()
		{
			timer += Time.deltaTime;
		}
	}
}

