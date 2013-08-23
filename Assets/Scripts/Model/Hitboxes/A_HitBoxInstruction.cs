using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using FightGame;

namespace FightGame{
	public abstract class A_HitBoxInstruction
	{
		public A_Fighter	fighter;
		public HitBox 		hitbox;
		public float		startTime;
		public float		endTime;
		public float		radius;
		public float		damage;
		public bool			started;
		public Vector3		movement;
		
		protected A_HitBoxInstruction(A_Fighter fighter, float radius, float damage, float startTime, float endTime, Vector3 movement = default(Vector3)){
			this.fighter		= fighter;
			//this.hitbox 		= fighter.FindFreeHitBox();
			this.startTime 		= startTime;
			this.endTime 		= endTime;
			this.radius			= radius;
			this.damage			= damage;
			this.started		= false;
			this.movement		= movement;
		}
		
		public void Init(){
			this.hitbox = fighter.FindFreeHitBox();
			Debug.Log(this.hitbox.gobj.name);
			//Debug.Break();
		}
		
		public virtual void Start(){
			this.hitbox.Enable();
			this.hitbox.SetRadius(radius);
			if (this.hitbox.damage != this.damage){ this.hitbox.damage = this.damage; }
			this.fighter.AddMovement( this.movement );
			this.started = true;
		}
		
		public virtual void Execute(){
			if (!this.started){
				this.Start();
			}
		}
		
		public void Reset(){
			this.started = false;
			this.hitbox.Reset();
		}
	}
}