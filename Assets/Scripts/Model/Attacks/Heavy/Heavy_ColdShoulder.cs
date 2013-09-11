using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_ColdShoulder: Attack_Melee
	{	
		public Heavy_ColdShoulder(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.AddInstruction(new JointHitBoxInstruction(
				"l_elbow_jnt", 					// joint
				attackOwner, 					// fighter
				5.0f, 							// radius
				4.0f,							// damage
				0.7f, 							// startTime
				1.6f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.4f, 0.0f, 0.0f),
				true
				));
		}
		
		public override void SpecialExecute(){
			if(!owner.specialEffect && owner.currentAttack!= null){
				owner.CreateParticle("l_ball_jnt 2","heavy_coldshoulder_effect",out owner.particleHolder1,Vector3.zero,Quaternion.AngleAxis(-90,Vector3.up));
				owner.CreateParticle("r_balr_jnt 2","heavy_coldshoulder_effect",out owner.particleHolder2,Vector3.zero,Quaternion.AngleAxis(-90,Vector3.up));
				owner.specialEffect = true;
			}
		}
		
	}
}
