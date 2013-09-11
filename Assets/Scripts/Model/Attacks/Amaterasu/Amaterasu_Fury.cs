using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Amaterasu_Fury: A_Attack
	{	
		
		public Amaterasu_Fury(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			
			//increase damage for the next attack
			//increase more fire effect on her feet
		}
		
		public override void SpecialExecute(){
			
			if(attackOwner.extraDamage == 1)
			{
				attackOwner.CreateParticle("l_elbow_jnt","FireBall",out attackOwner.particleHolder1,Vector3.zero,Quaternion.identity);
				attackOwner.CreateParticle("r_elbow_jnt","FireBall",out attackOwner.particleHolder2,Vector3.zero,Quaternion.identity);
				attackOwner.extraDamage = 5f;
				Debug.Log(attackOwner.extraDamage);
				
			}
			/*else{
				attackOwner.extraDamageTimer = 0.0f;
			}*/
		}
	}
}

