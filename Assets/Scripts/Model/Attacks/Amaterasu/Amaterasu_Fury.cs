using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Amaterasu_Fury: Attack_SelfBuff
	{	
		public Amaterasu_Fury(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.buff = new Buff_Fury( 5.0f, attackOwner, "Fury" );
			//increase damage for the next attack
			//increase more fire effect on her feet
		}
		/*
		public override void SpecialExecute(){
			
			if(attackOwner.extraDamage == 1)
			{
				attackOwner.extraDamage = 5f;
				Debug.Log(attackOwner.extraDamage);
				
			}
			else{
				attackOwner.extraDamageTimer = 0.0f;
			}
		}
		*/
	}
}

