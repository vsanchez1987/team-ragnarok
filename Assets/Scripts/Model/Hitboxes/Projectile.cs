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
		A_Fighter owner;
		public Projectile( A_Fighter owner,UnityEngine.Object prefab,float speed,Vector3 direction, Vector3 startlocation)
		{
			gob = GameObject.Instantiate(prefab) as GameObject;
			gob.transform.position = owner.gob.transform.position + startlocation;
			this.direction = direction;
			this.speed = speed;
			this.startLocation = startLocation;
			this.owner = owner;
		}
		
		public void Update()
		{
			this.gob.transform.position += new Vector3(owner.ForwardVector.x * this.direction.x, this.direction.y,this.direction.z)*speed;
			//this.gob.transform.position+=this.direction*owner.ForwardVector.x*speed;
		}
		
		public void Delete()
		{
			GameObject.Destroy(gob);
		}
		
	}
}