using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

public class HitBox{
	
	#region data
	GameObject gob;
	List<HBM> inbox;
	HBM currentMsg;
	Vector3 scale;
	Vector3 velocity;
	public bool collisionEnabled;
	float currentDmg;
	Mechanic currentMechanic;
	float endTime, startTime,elapsedTime;
	bool lockVisibility,visible;
	bool active;
	HitBoxInfo hitBoxInfo;
	#endregion
	
	#region constructor
	public HitBox(string name)
	{
		GOBset(name);
		scale = gob.transform.lossyScale;
		Debug.Log(name + " :hitbox scale:" + scale);
		velocity = new Vector3(0,0,0);
		collisionEnabled = false;
		currentDmg=0;
		currentMechanic = null;
		lockVisibility=visible=false;
		active = false;
		hitBoxInfo = null;
	}
	#endregion
	
	#region properties
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
	
	#region actions
	
	public bool sendMessage(HBM HB_message)
	{
		if(currentMsg==null)
		{
			collisionEnabled = true;
			startTime=HB_message.startTime;
			elapsedTime=0;
			endTime=HB_message.endTime;
			if(HB_message.startLoc!=Vector3.zero)
				setLocation(HB_message.startLoc);
			setVelocity(HB_message.velocity);
			setDamage(HB_message.damage);
			setRadius(HB_message.radius);
			setMechanic(HB_message.attackMechanic);
			return true;
		}
		else return false;
	}
	
	void setActive()
	{
		if(CheckIfAlreadyCollided())
		{
			Deactivate();
			return;
		}
		
		else if (checkIfInsideActiveTimeScope())
		{
			active=true;
		}
		else
		{
			if(checkIfAfterActiveTimeScope())
			{
				Deactivate();
			}
		}
	}
	
	bool CheckIfAlreadyCollided()
	{
		return hitBoxInfo!=null;
	}
	
	void Deactivate()
	{
		active = false;
		hitBoxInfo=null;
		currentMsg=null;
		velocity = Vector3.zero;
		collisionEnabled = false;
		currentDmg=0;
		currentMechanic = null;
		elapsedTime=endTime+1;
	}
	
	
	
	bool checkIfInsideActiveTimeScope()
	{	
		if(elapsedTime < endTime && elapsedTime > startTime) //active
			return true;
		return false;//out of scope of activation time
	}
	
	bool checkIfAfterActiveTimeScope()
	{
		return elapsedTime>startTime;
	}
	
	public bool checkCollision()
	{
		return (Physics.CheckSphere(gob.transform.position,scale.x/2.0f) && collisionEnabled);
	}
	
	public bool checkCollision(LayerMask layerToCheck)
	{
		return (Physics.CheckSphere(gob.transform.position,scale.x/2.0f, layerToCheck) && collisionEnabled);
	}
	
	HitBoxInfo constructHitBoxInformation(int LayerM)
	{
		Vector3 location;
		location = findCollidingHurtBoxLocation(LayerM);
		if (location==Vector3.zero) return null;//collision check failed
		HitBoxInfo hbi = new HitBoxInfo(location,this,this.currentMechanic,this.currentDmg);
		return hbi;
	}
	
	Vector3 findCollidingHurtBoxLocation(int enemyPlayerHurtBoxLayer)
	{
		Collider[] hitColliders = Physics.OverlapSphere(this.gob.transform.position,this.scale.x/2.0f,enemyPlayerHurtBoxLayer);
		if (hitColliders==null)return Vector3.zero;//its possible this will fail and other collision check will pass
		Vector3 Distance = hitColliders[0].gameObject.transform.position - this.gob.transform.position;
		return Distance.normalized * this.scale.x/2.0f;
	}
	
	public void update()
	{
		if(active)
		{
			updatePosition();	
			updateCollision();
		}
		setActive(); 
		updateTimer();
		updateVisibility();
	}
	
	void updateCollision()
	{
		bool collide=false;
		int layer;
		//see if collission happened
		
		//if this is player 1
		if (gob.layer==A_Fighter.P1_HIT_BOX_LAYER_NUMBER) 
		{
			collide=checkCollision(1<<A_Fighter.P2_HURT_BOX_LAYER_NUMBER);
			layer=1<<A_Fighter.P2_HURT_BOX_LAYER_NUMBER;
		}
		else //if this is player 2
		{
			collide=checkCollision(1<<A_Fighter.P1_HURT_BOX_LAYER_NUMBER);
			layer=1<<A_Fighter.P1_HURT_BOX_LAYER_NUMBER;
		}
		
		//construct hitbox information if hit happened
		if (collide)
		{
			hitBoxInfo=constructHitBoxInformation(layer);
		}
		
	}
	void updateTimer()
	{
		this.elapsedTime+=Time.deltaTime;
	}
	
	
	public void updatePosition()
	{
		gob.transform.position+=velocity*Time.deltaTime;
	}
	
	void updateVisibility()
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
