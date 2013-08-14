using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using FightGame;

namespace FightGame{
	public class ProjectileHitBoxInstruction : A_HitBoxInstruction
	{
		public ProjectileHitBoxInstruction(HitBox hitbox, Transform joint, float startTime, float endTime) : base(hitbox, startTime, endTime){
			
		}
		
		public override void Execute ()
		{
			
		}
	}
}

