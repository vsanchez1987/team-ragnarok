using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using FightGame;

namespace FightGame{
	public class JointHitBoxInstruction : A_HitBoxInstruction
	{
		public	HitBox		hitbox;
		private Transform 	joint;
		private Vector3		offset;
		
		public JointHitBoxInstruction( string joint, A_Fighter fighter, float radius, float damage, float startTime, float endTime, Vector3 offset = default(Vector3), Vector3 movement = default(Vector3), bool canKnockDown = false) : base(fighter, radius, damage, startTime, endTime, movement,canKnockDown){
			this.joint 	= fighter.joints[joint];
			this.offset = offset;
			this.knockback = Vector3.left;
		}
		
		public override void Init(){
			this.hitbox = fighter.FindFreeHitBox();
		}
		
		public override void Start(){
			this.hitbox.Enable();
			this.hitbox.SetRadius(this.radius);
			if (this.hitbox.damage != this.damage){ this.hitbox.damage = this.damage; }
			this.hitbox.canKnockDown = this.canKnockDown;
			base.Start();
		}
		
		public override void Execute ()
		{
			base.Execute();
			hitbox.gobj.transform.position = joint.position + joint.TransformDirection(this.offset);
		}
		
		public override void Reset(){
			base.Reset();
			this.hitbox.Reset();
		}
		
		public override void Disable(){
			this.hitbox.Disable();
		}
	}
}