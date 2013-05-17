using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

public class HitBox{

	GameObject gob;
	List<HBM> inbox;
	HBM currentMsg;
	Vector3 scale;
	Vector3 velocity;
	bool collisionEnabled;
	
	public GameObject GOB {
		get {return gob;}
	}
	public void GOBset(string name)
	{
		gob = GameObject.Find(name);
	}
	
	public HitBox(string name)
	{
		GOBset(name);
		inbox = new List<HBM>();
		scale = gob.transform.lossyScale;
		Debug.Log(name + " :hitbox scale:" + scale);
		velocity = new Vector3(0,0,0);
		collisionEnabled = false;
	}
	
	public bool checkCollision()
	{
		return (Physics.CheckSphere(gob.transform.position,scale.x/2.0f) && collisionEnabled);
	}
	
	public bool checkCollision(LayerMask layerMask)
	{
		return (Physics.CheckSphere(gob.transform.position,scale.x/2.0f, layerMask) && collisionEnabled);
	}
	
	public void setVelocity(Vector3 v)
	{
		velocity = v;
	}
	
	public void updatePosition()
	{
		gob.transform.position+=velocity*Time.deltaTime;
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
	
	public void Display(bool b)
	{
		gob.renderer.enabled = b;
	}
	
	
}
