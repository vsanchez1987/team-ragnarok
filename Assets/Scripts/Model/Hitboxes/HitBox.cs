using UnityEngine;
using System.Collections;
using FightGame;
using System.Collections.Generic;

namespace FightGame
{
	public class HitBox
	{
		public GameObject 	gobj;
		public A_Fighter	owner;
		public bool			isProjectile;
		public bool			inUse;
		public float		damage;
		
		public HitBox(A_Fighter owner, GameObject gobj, bool isProjectile)
		{
			this.owner			= owner;
			this.gobj			= gobj;
			this.isProjectile 	= isProjectile;
			this.inUse			= false;
			this.damage			= 0.0f;
			
			this.Reset();
		}
		
		public void Enable(){
			this.inUse = true;
			this.TurnOnCollider();
			this.TurnOnVisibility();
		}
		
		public void Disable(){
			this.inUse = false;
			if (this.gobj != null){
				this.TurnOffCollider();
				this.TurnOffVisibility();
			}
		}
		
		public void SetRadius(float radius){
			this.gobj.transform.localScale = new Vector3(radius, radius, radius);
		}
		
		public void Reset(){
			if (!this.isProjectile){
				if (this.gobj != null){
					this.gobj.transform.localPosition = Vector3.zero;
					this.gobj.transform.localScale = Vector3.one;
				}
				this.Disable();
			}
		}
		
		public void TurnOnCollider(){
			if (!this.gobj.collider.enabled){
				this.gobj.collider.enabled = true;
			}
		}
		
		public void TurnOffCollider(){
			if (this.gobj.collider.enabled){
				this.gobj.collider.enabled = false;
			}
		}
		
		public void TurnOnVisibility(){
			if (!this.gobj.renderer.enabled){
				this.gobj.renderer.enabled = true;
			}
		}
		
		public void TurnOffVisibility(){
			if (this.gobj.renderer.enabled){
				this.gobj.renderer.enabled = false;
			}
		}
	}
}
