using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Projectile
	{
		public GameObject gob;
		Vector3 direction;
		Vector3 startLocation; //relative to player's transform
		float speed;
		float startTime;
		float time = 0f;
		A_Fighter owner;
		public Projectile( A_Fighter owner,UnityEngine.Object prefab,float speed,Vector3 direction, Vector3 startlocation, float startTime)
		{
			gob = GameObject.Instantiate(prefab) as GameObject;
			gob.transform.position = owner.gob.transform.position + startlocation;
			this.direction = direction;
			this.speed = speed;
			this.startLocation = startLocation;
			this.owner = owner;
			this.startTime = startTime;
		}
		
		public void Update()
		{
			if(time >= startTime)
			{
				this.gob.transform.position += new Vector3(owner.ForwardVector.x * this.direction.x, this.direction.y,this.direction.z)*speed;
				//time = 0f;
				//this.gob.transform.position+=this.direction*owner.ForwardVector.x*speed;
			}
			time+=Time.deltaTime;
		}
		
		public void Delete()
		{
			GameObject.Destroy(gob);
		}
		
	}
}