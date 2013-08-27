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
		/*
		public ProjectileHitBoxInstruction( string projectileName, string startJoint, Vector3 direction, float speed, A_Fighter fighter, float radius, float damage, float startTime, float endTime, Vector3 offset = default(Vector3), Vector3 movement = default(Vector3)) : base(fighter, radius, damage, startTime, endTime, movement){
			float timePeriod	= (endTime - startTime);
			this.projectileName = projectileName;
			this.startJoint		= fighter.joints[startJoint];
			this.increment		= direction.normalized * speed * (Time.deltaTime);
			this.offset			= offset;
		}*/
		
		public ProjectileHitBoxInstruction( string projectileName, string startJoint, Vector3 direction, float speed, A_Fighter fighter, float radius, float damage, float startTime, float endTime, Vector3 offset, Vector3 movement) : base(fighter, radius, damage, startTime, endTime, movement){
			float timePeriod	= (endTime - startTime);
			this.projectileName = projectileName;
			this.startJoint		= fighter.joints[startJoint];
			this.increment		= direction.normalized * speed * (Time.deltaTime);
			this.offset			= offset;
			this.speed			= speed;
		}
		
		public override void Start(){
			//Debug.Break();
			GameObject projectile = (GameObject)GameObject.Instantiate( Resources.Load("Projectiles/" + this.projectileName, typeof(GameObject)),
				this.startJoint.position + this.startJoint.TransformDirection(this.offset), Quaternion.identity );
			ProjectileInput pInput = projectile.GetComponent<ProjectileInput>();
			pInput.direction = new Vector3(this.increment.x * fighter.GlobalForwardVector.x, this.increment.y, this.increment.z);
			pInput.hitbox = new HitBox( this.fighter, pInput.hitboxObject, true );
			pInput.speed = this.speed;
			this.hitbox = pInput.hitbox;
			
			HitBoxInput hInput = pInput.hitboxObject.GetComponent<HitBoxInput>();
			hInput.hitbox = pInput.hitbox;
			
			/*
			GameObject hitbox = (GameObject)GameObject.Instantiate( Resources.Load("Prefabs/HitBox"), this.startJoint.position, Quaternion.identity );
			hitbox.transform.parent = projectile.transform;
			HitBox hb = new HitBox( this.fighter, hitbox, true );
			*/
			base.Start();
			
			GameObject.Destroy(projectile, (endTime - startTime));
		}
		
		/*
		public override void Execute ()
		{
			if (!this.started){
				this.Start();
				this.started = true;
			}
			this.projectile.transform.position += this.increment;
			this.hitbox.gobj.transform.position = projectile.transform.position;
		}
		*/
	}
}

