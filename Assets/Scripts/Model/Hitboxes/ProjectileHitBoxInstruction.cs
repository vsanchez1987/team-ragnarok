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
		
		public ProjectileHitBoxInstruction( string projectileName, string startJoint, Vector3 direction, float speed, A_Fighter fighter, float radius, float damage, float startTime, float endTime ) : base(fighter, radius, damage, startTime, endTime){
			this.projectileName = projectileName;
			this.startJoint		= fighter.joints[startJoint];
			
			float timePeriod	= (endTime - startTime);
			this.increment		= direction.normalized * speed * (Time.deltaTime);
		}
		
		public override void Start(){
			//Debug.Break();
			GameObject projectile = (GameObject)GameObject.Instantiate( Resources.Load("Projectiles/" + this.projectileName, typeof(GameObject)),
				this.startJoint.position, Quaternion.identity );
			ProjectileInput pInput = projectile.GetComponent<ProjectileInput>();
			pInput.direction = this.increment;
			pInput.hitbox = new HitBox( this.fighter, pInput.hitboxObject, true );
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

