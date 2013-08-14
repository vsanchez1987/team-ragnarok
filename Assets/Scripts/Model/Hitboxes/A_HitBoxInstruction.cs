using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using FightGame;

namespace FightGame{
	public abstract class A_HitBoxInstruction
	{
		public HitBox 	hitbox;
		public float	startTime;
		public float	endTime;
		
		protected A_HitBoxInstruction(HitBox hitbox, float startTime, float endTime){
			this.hitbox 	= hitbox;
			this.startTime 	= startTime;
			this.endTime 	= endTime;
		}
		
		public abstract void Execute();
		/*
		public List<HB_KeyFrame> onOffTimes;
		public A_Fighter owner;
		public string jointName;//pass "projectile" if projectile
		public float damage;
		public float radius;
		public Mechanic attackMechanic;
		public ParticleSystem particleSystem;
		
		public A_HitBoxInstruction(A_Fighter owner, List<HB_KeyFrame> onOffTimes, string jointName, float damage, float radius, Mechanic attackMechanic = null, ParticleSystem p = null)
		{
			this.owner = owner;
			this.onOffTimes = onOffTimes;
			this.jointName = jointName;
			this.damage = damage;
			this.radius = radius;
			this.attackMechanic = attackMechanic;
			this.particleSystem = particleSystem;
		}
		
		List<HB_KeyFrame> DuplicateKeyFrames (List<HB_KeyFrame> keyFrames)
		{
			if (keyFrames==null) return null;
			
			List<HB_KeyFrame> keyframeList = new List<HB_KeyFrame>();
			
			for(int i=0;i< keyFrames.Count;i++)
			{
				keyframeList.Add(new HB_KeyFrame( keyFrames[i].onTime,keyFrames[i].offTime));
				
			}
			return keyframeList;
		}
		
		public  HB_Instruction DuplicateHBInstructions(HB_Instruction hbi)
		{
			HB_Instruction HBI = new HB_Instruction(hbi.owner,DuplicateKeyFrames(hbi.onOffTimes),
				hbi.jointName,hbi.damage,hbi.radius,hbi.attackMechanic,hbi.particleSystem);
			return HBI;
		}
		*/
	}
}