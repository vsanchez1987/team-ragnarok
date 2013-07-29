using UnityEngine;
using System.Collections;
using FightGame;
using System.Collections.Generic;

namespace FightGame
{
	public class HitBoxCollisionInfo
	{
		public Vector3 location;
		public Mechanic m;
		public float damage;
		public ParticleSystem particleSystem;
		public A_Fighter hitPlayer;
		
		public HitBoxCollisionInfo(Vector3 location, float damage, A_Fighter hitPlayer)
		{
			this.location = location;
			this.damage =damage;
			this.hitPlayer = hitPlayer;
		}
	}
}
