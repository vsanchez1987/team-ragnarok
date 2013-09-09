using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using FightGame;

namespace FightGame{
	public class JointHitBoxInstruction : A_HitBoxInstruction
	{
		private Transform 	joint;
		private Vector3		offset;
		
		public JointHitBoxInstruction( string joint, A_Fighter fighter, float radius, float damage, float startTime, float endTime, Vector3 offset = default(Vector3), Vector3 movement = default(Vector3), bool canKnockDown = false) : base(fighter, radius, damage, startTime, endTime, movement,canKnockDown){
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