using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Projectile
	{
		public GameObject gob;
		//Vector3 velocity;
		float speed;
		A_Fighter owner;
		public Projectile( A_Fighter owner,UnityEngine.Object prefab)
		{
			gob = GameObject.Instantiate(prefab) as GameObject;
			gob.transform.position = owner.gob.transform.position + A_Fighter.projectileOffset;
			//velocity = new Vector3(1,0,0);
			speed = .2f;
			this.owner = owner;
		}
		
		public void Update()
		{
			this.gob.transform.position+=speed*owner.ForwardVector;
		}
		
		public void Delete()
		{
			GameObject.Destroy(gob);
		}
		
	}
}