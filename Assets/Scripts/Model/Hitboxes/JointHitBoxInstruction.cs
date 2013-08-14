using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using FightGame;

namespace FightGame{
	public class JointHitBoxInstruction : A_HitBoxInstruction
	{
		private Transform joint;
		public JointHitBoxInstruction(HitBox hitbox, Transform joint, float startTime, float endTime) : base(hitbox, startTime, endTime){
			this.joint = joint;
		}
		
		public override void Execute ()
		{
			hitbox.TurnOnCollider();
			hitbox.gobj.transform.position = joint.position;
		}
	}
}