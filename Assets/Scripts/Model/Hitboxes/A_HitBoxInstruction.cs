using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using FightGame;

namespace FightGame{
	public abstract class A_HitBoxInstruction
	{
		protected A_Fighter	fighter;
		protected float		startTime;
		protected float		endTime;
		protected float		damage;
		protected bool		started;
		protected Vector3	movement;
		protected float		radius;
		protected Vector3	knockback;
		protected bool		canKnockDown;
		
		protected A_HitBoxInstruction(A_Fighter fighter, float radius, float damage, float startTime, float endTime, Vector3 movement, bool canKnockDown = false){
			this.fighter		= fighter;
			this.startTime 		= startTime;
			this.endTime 		= endTime;
			this.radius			= radius;
			this.damage			= damage;
			this.started		= false;
			this.movement		= movement;
			this.canKnockDown	= canKnockDown;
		}
		
		public abstract void Init();
		public abstract void Disable();
		
		public virtual void Start(){
			this.fighter.AddMovement( this.movement );
			this.started = true;
		}
		
		public virtual void Execute(){
			if (!this.started){
				this.Start();
			}
		}
		
		public virtual void Reset(){
			this.started = false;
		}
		
		public float StartTime{
			get { return this.startTime; }
		}
		
		public float EndTime{
			get { return this.endTime; }
		}
	}
}