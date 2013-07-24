using UnityEngine;
using System.Collections;
using FightGame;
using System.Collections.Generic;

namespace FightGame
{
	public class HitBox
	{
		GameObject gob;
		HB_Instruction currentInstruction;
		A_Fighter owner;
		public bool active;
		float radius;
		float activeTime;
		public bool displayWhenNotActive;
		public bool displayWhenActive;
		public bool isProjectile;
		
		public HitBox(A_Fighter owner, GameObject gob, bool isProjectile)
		{
			this.gob = gob;
			this.owner = owner;
			this.active = this.displayWhenNotActive = this.displayWhenActive = false;
			this.currentInstruction = null;
			this.radius = this.activeTime = 0.1f;
			this.isProjectile = isProjectile;
		}
		
		public void Update()
		{
			UpdateActiveTime();
			DrawBoxes();
			CheckCollision();
		}
		
		LayerMask CreateLayerMask()
		{
			// thiis needs to check player number and assign a layer 
			LayerMask m = 1 << 8;//8 references the layer number
			return m;
		}
		
		void UpdateActiveTime()
		{
			if(active)
			{
				activeTime+=Time.deltaTime;
			}
			else
				activeTime = 0;
		}
		
		public string GetName()
		{
			return gob.name;
		}
		
		void InactivityCheck(){}
		
		void Activate()
		{
			SetRadius(currentInstruction.radius);
			active = true;
			activeTime = 0.0f;
		}
		
		public void DeActivate()
		{
			radius = 0.1f;
		}
		
		HitBoxCollisionInfo GenerateCollisionInfo(){return null;}
		
		void GiveCollisionInfoToGameManager(){}
		
		void DrawBoxes()
		{
			gob.renderer.enabled =  (active && displayWhenActive  ||  !active && displayWhenNotActive);
			if(gob.renderer.enabled)
			{
				gob.transform.localScale = new Vector3(radius,radius,radius);
			}
		}
		
		void CheckCollision()
		{
			//Physics.CheckSphere(gob.transform.position, radius/2.0f) <-- simple 
			 Collider[] hitColliders = Physics.OverlapSphere(gob.transform.position,radius/2.0f,CreateLayerMask());
        
			foreach(Collider c in hitColliders)
			{
				Debug.Log(c.gameObject.name + " " +Time.time);
			}
		}
		
		void SetRadius(float r)
		{
			this.radius = r;
			this.gob.transform.localScale = new Vector3(r,r,r);
		}
		
		public void SendInstruction(HB_Instruction hb_instruction)
		{
			this.currentInstruction = hb_instruction;
			Debug.Log(this.gob.name);
			Activate();
		}
		
		public void ParentToProjectile(GameObject projectile){}
	
		
	}
}
