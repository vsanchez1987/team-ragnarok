using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

public class HitBox{
	
	GameObject 				gob;
	List<HitBoxInstruction> HBinstructionList;
	HitBoxInstruction 		currentInstruction;
	Vector3 				scale;
	Vector3 				velocity;
	public bool 			collisionEnabled;
	float 					currentDmg;
	Mechanic 				currentMechanic;
	float 					endTime, startTime,elapsedTime;
	bool 					lockVisibility,visible;
	bool 					active;
	HitBoxInfo 				hitBoxInfo;
	
	public HitBox(string name)
	{
		GOBset(name);
		scale = 			gob.transform.lossyScale;
		Debug.Log(name + " :hitbox scale:" + scale);
		velocity = 			new Vector3(0,0,0);
		collisionEnabled = 	false;
		currentDmg =		0;
		currentMechanic = 	null;
		lockVisibility=visible=false;
		active = 			false;
		hitBoxInfo = 		null;
	}
	
	#region get/set methods
	public void setDamage(float damage)
	{
		this.currentDmg = damage;
	}
	
	public float getDamage()
	{
		return this.currentDmg;
	}
	
	public void setMechanic(Mechanic m)
	{
		currentMechanic=m;
	}
	
	public Mechanic getMechanic()
	{
		return currentMechanic;
	}
	
	public GameObject GOB {
		get {return gob;}
	}
	public void GOBset(string name)
	{
		gob = GameObject.Find(name);
	}
	public void setVelocity(Vector3 v)
	{
		velocity = v;
	}
	public void setRadius(float f)
	{
		Vector3 size = new Vector3(f,f,f);
		gob.transform.localScale=size;
		this.scale = size;
	}
	
	public void setCollisionEnable(bool b)
	{
		collisionEnabled=b;
	}
	public bool getCollisionEnabled()
	{
		return collisionEnabled;
	}
	public void setLocation(Vector3 l)
	{
		gob.transform.position=l;
	}
	
	public void LockVisiblity(bool b)
	{
		lockVisibility=b;
	}
	
	public bool VisiblityLocked()
	{
		return lockVisibility;
	}
	
	public void SetVisiblity(bool b)
	{
		visible=b;
	}
	
	public HitBoxInfo getHitBoxInfo()
	{
		return hitBoxInfo;
	}
	
	public void removeHitBoxInfo()
	{
		hitBoxInfo=null;
	}
	#endregion
	
	public bool sendInstruction(HitBoxInstruction HBI)
	{
		if(currentInstruction==null)
		{
			collisionEnabled 	= true;
			startTime			= HBI.startTime;
			elapsedTime			= 0;
			endTime				= HBI.endTime;
			if(HBI.startLoc!=Vector3.zero) //flag for using parent location
			{
				setLocation(HBI.startLoc);
			}
			setVelocity(HBI.velocity);
			setDamage(HBI.damage);
			setRadius(HBI.radius);
			setMechanic(HBI.attackMechanic);
			return true;
		}
		else return false;
	}
	
	void SetActive()
	{
		if(CheckIfAlreadyCollided())
		{
			Deactivate();
			return;
		}
		
		else if (CheckIfInsideActiveTimeScope())
		{
			active=true;
		}
		else
		{
			if(CheckIfAfterActiveTimeScope())
			{
				Deactivate();
			}
		}
	}
	
	void Deactivate()
	{
		active 				= false;
		hitBoxInfo			= null;
		currentInstruction	= null;
		velocity 			= Vector3.zero;
		collisionEnabled 	= false;
		currentDmg			= 0;
		currentMechanic 	= null;
		elapsedTime			= endTime+1;
	}
	
	bool CheckIfInsideActiveTimeScope()
	{	
		if(elapsedTime < endTime && elapsedTime > startTime)
		{
			return true;
		}
		return false;
	}
	
	bool CheckIfAfterActiveTimeScope()
	{
		return elapsedTime>startTime;
	}
	
	#region collision methods
	bool CheckIfAlreadyCollided()
	{
		return hitBoxInfo!=null;
	}
	
	public bool CheckCollision()
	{
		return (Physics.CheckSphere(gob.transform.position,scale.x/2.0f) && collisionEnabled);
	}
	
	public bool CheckCollision(LayerMask layerToCheck)
	{
		return (Physics.CheckSphere(gob.transform.position,scale.x/2.0f, layerToCheck) && collisionEnabled);
	}
	
	Vector3 FindCollidingHurtBoxLocation(int enemyPlayerHurtBoxLayer)
	// runs a move expensive collision check to find exact location, returns 0,0,0 if failed
	{
		Collider[] hitColliders = Physics.OverlapSphere(this.gob.transform.position,this.scale.x/2.0f,enemyPlayerHurtBoxLayer);
		if (hitColliders==null) //if this collision check fails
		{
			return Vector3.zero;
		}
		Vector3 Distance = hitColliders[0].gameObject.transform.position - this.gob.transform.position;
		return Distance.normalized * this.scale.x/2.0f;
	}
	#endregion
	
	HitBoxInfo ConstructHitBoxInformation(int LayerM)
	{
		Vector3 location = FindCollidingHurtBoxLocation(LayerM);
		if (location==Vector3.zero) //collision check failed
		{
			return null;
		}	
		return new HitBoxInfo(location,this,this.currentMechanic,this.currentDmg);
	}

	#region Update methods
	public void Update()
	{
		if(active)
		{
			UpdatePosition();	
			UpdateCollision();
		}
		SetActive(); 
		UpdateTimer();
		UpdateVisibility();
	}
	
	void UpdateCollision()
	{
		bool collide=false;
		int layer;
		//see if collission happened
		
		//if this is player 1
		if (gob.layer==A_Fighter.P1_HIT_BOX_LAYER_NUMBER) 
		{
			collide=CheckCollision(1<<A_Fighter.P2_HURT_BOX_LAYER_NUMBER);
			layer=1<<A_Fighter.P2_HURT_BOX_LAYER_NUMBER;
		}
		else //if this is player 2
		{
			collide=CheckCollision(1<<A_Fighter.P1_HURT_BOX_LAYER_NUMBER);
			layer=1<<A_Fighter.P1_HURT_BOX_LAYER_NUMBER;
		}
		
		//construct hitbox information if hit happened
		if (collide)
		{
			hitBoxInfo=ConstructHitBoxInformation(layer);
		}
		
	}
	
	void UpdateTimer()
	{
		this.elapsedTime+=Time.deltaTime;
	}
	
	public void UpdatePosition()
	{
		gob.transform.position+=velocity*Time.deltaTime;
	}
	
	void UpdateVisibility()
	{
		if(lockVisibility)
		{
			gob.renderer.enabled = true;
		}
		else
		{
			if(visible)
				gob.renderer.enabled = active;
			
			else gob.renderer.enabled = false;
		}	
	}
	#endregion

}
