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
			Debug.Log(moving);
			if(!moving)
			{
				origin = attackOwner.gob.transform.position;
				desire = new Vector3(origin.x+5,origin.y,origin.z);
				moving=true;
			}
			
			if(time >= 0.8)
			{
				/*
				attackOwner.gob.transform.position = new Vector3(attackOwner.gob.transform.position.x+1,
																 attackOwner.gob.transform.position.y,
																 attackOwner.gob.transform.position.z);
				*/
				//attackOwner.gob.transform.Translate(attackOwner.localForwardVector*7.5f*Time.deltaTime);
				attackOwner.gob.transform.position =Vector3.Lerp(origin,new Vector3(origin.x+5,origin.y,origin.z),Time.deltaTime*2);
				dest = attackOwner.gob.transform.position;
				moving=false;
			}
		}
		
	}
}

