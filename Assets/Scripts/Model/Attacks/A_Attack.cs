using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public abstract class A_Attack
	{
		public		float		speed;
		protected 	A_Fighter	owner;
		protected	float		timer;
		protected	float		length;
		protected	string		animationName;
		
		private	List<A_HitBoxInstruction> instructions;
		
		protected A_Attack( string animationName, float speed, A_Fighter owner)
		{
			this.speed			= speed;
			this.owner 			= owner;
			this.timer 			= 0.0f;
			this.animationName 	= animationName;
			this.instructions 	= new List<A_HitBoxInstruction>();
			
			if (owner.gobj.animation.GetClip(animationName) != null){
				this.length = owner.gobj.animation[animationName].clip.length;
			}
		}
		
		public virtual void Init(){
			foreach (A_HitBoxInstruction hbi in this.instructions){
				hbi.Init();
			}
			this.timer = 0.0f;
		}
		
		public virtual void Execute(){
			foreach (A_HitBoxInstruction hbi in this.instructions){
				if (this.timer < hbi.StartTime / this.speed){
					hbi.Disable();
				}
				else if ((this.timer >= hbi.StartTime / this.speed) && (this.timer <= hbi.EndTime / this.speed)){
					hbi.Execute();
				}
				else if (this.timer >= hbi.EndTime / this.speed){
					hbi.Reset();
				}
			}
			this.timer += Time.deltaTime;
		}
		
		
		public virtual void Reset(){
			foreach (A_HitBoxInstruction hbi in this.instructions){
				hbi.Reset();
			}
			this.timer = 0.0f;
		}
		
		//Hieu add
		public virtual void SpecialExecute(){ }
		
		public bool CheckComplete(){
			return (this.timer >= (this.length / this.speed));
		}
		
		public string AnimationName{
			get { return this.animationName;}
		}
		
		public virtual void AddInstruction( A_HitBoxInstruction hbi ){
			this.instructions.Add( hbi );
		}
	}
}

