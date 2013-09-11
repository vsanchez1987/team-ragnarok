using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using FightGame;

namespace FightGame{
	public class ProjectileHitBoxInstruction : A_HitBoxInstruction
	{
		private string 		projectileName;
		private Transform	startJoint;
		private Vector3		increment;
		private Vector3		offset;
		private float		speed;

		public ProjectileHitBoxInstruction( string projectileName, string startJoint, Vector3 direction, float speed, A_Fighter fighter, float radius, float damage, float startTime, float endTime, Vector3 offset, Vector3 movement) : base(fighter, radius, damage, startTime, endTime, movement){
			float timePeriod	= (endTime - startTime);
			this.projectileName = projectileName;
			this.startJoint		= fighter.joints[startJoint];
			this.increment		= direction.normalized * speed * (Time.deltaTime);
			this.offset			= offset;
			this.speed			= speed;
			this.knockback 		= Vector3.left;
		}
		
		public override void Init(){}
		
		public override void Start(){
			GameObject projectile = (GameObject)GameObject.Instantiate( Resources.Load("Projectiles/" + this.projectileName, typeof(GameObject)),
				this.startJoint.position + this.startJoint.TransformDirection(this.offset), Quaternion.identity );
			ProjectileInput pInput = projectile.GetComponent<ProjectileInput>();
			pInput.direction = new Vector3(this.increment.x * fighter.GlobalForwardVector.x, this.increment.y, this.increment.z);
			pInput.hitbox = new HitBox( this.fighter, pInput.hitboxObject, true );
			pInput.speed = this.speed;
			pInput.hitbox.SetKnockback(this.knockback);
			//this.hitbox = pInput.hitbox;
			
			HitBoxInput hInput = pInput.hitboxObject.GetComponent<HitBoxInput>();
			hInput.hitbox = pInput.hitbox;
			
			base.Start();
			
			GameObject.Destroy(projectile, (endTime - startTime));
		}
		
		public override void Disable(){ }
	}
}

