using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Heavy_ColdShoulder: Attack_Melee
	{
		private GameObject fire1;
		private GameObject fire2;
		
		public Heavy_ColdShoulder(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner)
		{
			this.AddInstruction(new JointHitBoxInstruction(
				"l_elbow_jnt", 					// joint
				attackOwner, 					// fighter
				5.0f, 							// radius
				100.0f,							// damage
				0.7f, 							// startTime
				1.6f,  							// endTime
				new Vector3(0.0f, 0.0f, 0.0f), 	// offset
				new Vector3(0.5f, 0.0f, 0.0f),	// movement
				true							// canKnockDown
				));
		}
		
		public override void Init(){
			GameObject effect = Resources.Load("Effect/heavy_coldshoulder_effect", typeof(GameObject)) as GameObject;
			this.fire1 = GameObject.Instantiate(effect, this.attackOwner.joints["l_ball_jnt 2"].position, Quaternion.Euler(new Vector3(0.0f, -90.0f * this.attackOwner.GlobalForwardVector.x, 0.0f))) as GameObject;
			this.fire2 = GameObject.Instantiate(effect, this.attackOwner.joints["r_balr_jnt 2"].position, Quaternion.Euler(new Vector3(0.0f, -90.0f * this.attackOwner.GlobalForwardVector.x, 0.0f))) as GameObject;
			
			GameObject.Destroy(this.fire1, (2.0f/this.speed));
			GameObject.Destroy(this.fire2, (2.0f/this.speed));
			
			base.Init();
		}
		
		public override void SpecialExecute ()
		{
			if (this.fire1) this.fire1.transform.position = this.attackOwner.joints["l_ball_jnt 2"].position;
			if (this.fire2) this.fire2.transform.position = this.attackOwner.joints["r_balr_jnt 2"].position;
		}
	}
}
