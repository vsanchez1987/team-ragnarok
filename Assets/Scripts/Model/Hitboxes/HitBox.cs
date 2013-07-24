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
		Color initialColor;
		Color collideColor = Color.red;
		bool checkCollision;
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
			this.checkCollision = false;
			this.initialColor = gob.renderer.material.color;
		}
		
		public void Update()
		{
			UpdateActiveTime();
			ProcessCurrentInstruction();
			DeactivateExpired();
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
		
		void DeactivateExpired()
		{
			
			// deactivate if after last valid keyframe
			if(this.currentInstruction != null)
			{
				
				int expired = 0;
				int count = currentInstruction.onOffTimes.Count;
				
				for (int i = 0; i < count ; i++)
				{
					
					if(currentInstruction.onOffTimes[i].expired)
					{
						//Debug.Log(currentInstruction.onOffTimes[i].expired);
						expired+=1;
					}
				}
				
				if (expired>=count)
				{
					Debug.Log("Deactivating " + this.gob.name);
					DeActivate();
				}
			}
			
		}
		
		void Activate()
		{
			SetRadius(currentInstruction.radius);
			active = true;
			activeTime = 0.0f;
			this.checkCollision=false;
		}
		
		public void DeActivate()
		{
			radius = 0.1f;
			this.checkCollision=false;
			//ResetHBKeyFrames();
			active= false;
			this.currentInstruction= null;
			
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
			if (checkCollision)
			{
				gob.renderer.material.color = collideColor;
			}
			else 
			{
				gob.renderer.material.color = initialColor;
			}
		}
		
		void CheckCollision()
		{
			if(checkCollision)
			{
				//Physics.CheckSphere(gob.transform.position, radius/2.0f) <-- simple 
				 Collider[] hitColliders = Physics.OverlapSphere(gob.transform.position,radius/2.0f,CreateLayerMask());
	        
				foreach(Collider c in hitColliders)
				{
					Debug.Log(c.gameObject.name + " " +Time.time);
				}
			}
		}
		
		void ResetHBKeyFrames()
		{
			if(this.currentInstruction!=null)
			{
				for (int i = 0; i < currentInstruction.onOffTimes.Count ; i++)
				{
					HB_KeyFrame key =  currentInstruction.onOffTimes[i];
					key.expired = false;
					currentInstruction.onOffTimes[i]=key;
				}
			}
		}
		
		void ProcessCurrentInstruction()
		{
			//check all keyframes for activation and flag collission if needed
			if(this.currentInstruction!=null)
			{
				for (int i = 0; i < currentInstruction.onOffTimes.Count ; i++)
				{
					HB_KeyFrame key =  currentInstruction.onOffTimes[i];
					
					if (this.activeTime > key.onTime && this.activeTime < key.offTime)
					{
						this.checkCollision = true;
					}
					else if(this.activeTime > key.offTime && key.expired == false)
					{
						this.checkCollision = false;
						key.expired = true;
						currentInstruction.onOffTimes[i]=key;
					}
				}
				/*foreach(HB_KeyFrame key in currentInstruction.onOffTimes)
				{
					if (this.activeTime > key.onTime && this.activeTime < key.offTime)
					{
						this.checkCollision = true;
					}
					else if(this.activeTime > key.offTime && key.expired == false)
					{
						this.checkCollision = false;
						key.expired = true;
					}
				}
				*/
			}
		}
		
		void SetRadius(float r)
		{
			this.radius = r;
			this.gob.transform.localScale = new Vector3(r,r,r);
		}
		
		public void SendInstruction(HB_Instruction hb_instruction)
		{
			if(this.currentInstruction!=null) DeActivate();
			
			this.currentInstruction = hb_instruction.DuplicateHBInstructions(hb_instruction);
			//Debug.Log(currentInstruction);
			Debug.Log(this.gob.name);
			Activate();
		}
		
		
		
		public void ParentToProjectile(GameObject projectile){}
	
		
	}
}
