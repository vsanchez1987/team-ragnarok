using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

public class ProjectileInput : MonoBehaviour
{
	public GameObject 	hitboxObject;
	
	[HideInInspector]
	public Vector3		direction;
	[HideInInspector]
	public HitBox 		hitbox;
	float timer = 0f;
	Vector3 target;
	
	void Start()
	{
		target = hitbox.GetTarget().gobj.transform.position;
	}
	
	void Update(){
		timer +=Time.deltaTime;
		this.transform.position += direction;
		//Debug.Log(this.name);
		if(this.name == "Projectile_Seek(Clone)")
		{
			if(timer > 0.5f)
			{
				Vector3 newdirection = target - this.transform.position;
				this.transform.Translate(newdirection*5*Time.deltaTime);
			}
		}
	}
}

