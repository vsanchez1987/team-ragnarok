using UnityEngine;
using System.Collections;
using FightGame;

namespace FightGame
{
	public class Attack_Melee: A_Attack
	{
		float attackDuration = 3.0f;
		string attack_name = "melee";
		
		public Attack_Melee (A_Fighter attackOwner, float preAttackPeriod = 0.0f, float attackPeriod = 0.0f, float animationDuration = 0.0f):base(attackPeriod,attackOwner)
		{
			// <<<HIT BOX MESSAGES>>>
			string recipient;
			Vector3 startLoc,velocity;
			float startTime,endTime,damage,radius;
			Mechanic attackMechanic;
			HitBoxInstruction HB_message;
			
			// ******** LEFT FIST ********
			recipient = A_Fighter.HB_FIST_L;
			startLoc = new Vector3(0,0,0);
			velocity = new Vector3(0,0,0);
			startTime = 0.0f;
			endTime = attackDuration;
			damage = 30.0f;
			radius = 1.0f;
			attackMechanic = new Mechanic(); //knowdown, launch etc..
			
			HB_message = new HitBoxInstruction(recipient,startTime,endTime,damage,attackMechanic,velocity,startLoc,radius);
			base.attackInstructions.Add(HB_message);
			//_---------------------------------
			
			// ******** RIGHT FIST ********
			recipient = A_Fighter.HB_FIST_R;
			startLoc = new Vector3(0,0,0);
			velocity = new Vector3(0,0,0);
			startTime = 1.0f;
			endTime = 2.0f;
			damage = 20.0f;
			radius = 1.5f;
			attackMechanic = new Mechanic(); //knowdown, launch etc..
			
			HB_message = new HitBoxInstruction(recipient,startTime,endTime,damage,attackMechanic,velocity,startLoc,radius);
			base.attackInstructions.Add(HB_message);
			//_---------------------------------
			
			
			// ******** GLOBAL01 ********
			recipient = A_Fighter.HB_GLOBAL01;
			startLoc = new Vector3(0,2.0f,0);
			velocity = new Vector3(0.4f,-0.01f,0);
			startTime = 0.0f;
			endTime = 10.0f;
			damage = 10.0f;
			radius = 1.0f;
			attackMechanic = new Mechanic(); //knowdown, launch etc..
			
			HB_message = new HitBoxInstruction(recipient,startTime,endTime,damage,attackMechanic,velocity,startLoc,radius);
			base.attackInstructions.Add(HB_message);
			base.name=attack_name;
			//_---------------------------------


			
			//JONATHAN'S ORIGINAL CODE
			this.preAttackPeriod = preAttackPeriod;
			this.attackPeriod = attackPeriod;
			this.animationDuration = animationDuration;
			this.postAttackPeriod = animationDuration - (preAttackPeriod + attackPeriod);
			
			
		}
	}
}

