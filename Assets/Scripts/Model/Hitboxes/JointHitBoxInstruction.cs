using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using FightGame;

namespace FightGame{
	public class JointHitBoxInstruction : A_HitBoxInstruction
	{
		private Transform 	joint;
		private Vector3		offset;
		
		public JointHitBoxInstruction( string joint, A_Fighter fighter, float radius, float damage, float startTime, float endTime) : base(fighter, radius, damage, startTime, endTime){
			this.joint 	= fighter.joints[joint];
			this.offset = Vector3.zero;
		}
		
		public JointHitBoxInstruction( string joint, A_Fighter fighter, Vector3 offset, float radius, float damage, float startTime, float endTime) : base(fighter, radius, damage, startTime, endTime){
			this.joint 	= fighter.joints[joint];
			this.offset = offset;
		}
		
		public override void Execute ()
		{
			base.Execute();
			hitbox.gobj.transform.position = joint.position + joint.TransformDirection(this.offset);
		}
	}
}