using UnityEngine;
using System.Collections;
using FightGame;
using System.Collections.Generic;

namespace FightGame
{
	public class HurtBox
	{
		public A_Fighter 	owner;
		public GameObject 	gobj;
		public Location		location;
		
		public HurtBox(A_Fighter owner, GameObject gobj)
		{
			this.owner = owner;
			this.gobj = gobj;
			this.location = gobj.GetComponent<HurtBoxInput>().location;
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
	}
}
