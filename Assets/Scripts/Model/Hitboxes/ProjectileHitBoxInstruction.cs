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

		public ProjectileHitBoxInstruction( string projectileName, string startJoint, Vector3 direction, float speed, A_Fighter fighter, float radius, float damage, float startTime, float endTime, Vector3 offset = default(Vector3), Vector3 movement = default(Vector3), Vector3 knockback = default(Vector3)) : base(fighter, radius, damage, startTime, endTime, knockback, movement){
			float timePeriod	= (endTime - startTime);
			this.projectileName = projectileName;
			this.startJoint		= fighter.joints[startJoint];
			this.increment		= direction.normalized * speed * (Time.deltaTime);
			this.offset			= offset;
			this.speed			= speed;
			this.knockback 		= knockback;
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
			pInput.hitbox.SetRadius( this.radius );
			pInput.hitbox.damage = this.damage;
			//this.hitbox = pInput.hitbox;
			
			HitBoxInput hInput = pInput.hitboxObject.GetComponent<HitBoxInput>();
			hInput.hitbox = pInput.hitbox;
			
			if (GameManager.UI.hitboxOn){
				hInput.hitbox.TurnOnVisibility();
			}
			
			base.Start();
			
			GameObject.Destroy(projectile, (endTime - startTime));
		}
		
		public override void Disable(){ }
	}
}

