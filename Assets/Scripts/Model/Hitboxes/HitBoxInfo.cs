using System;
using UnityEngine;

namespace FightGame
{
	public class HitBoxInfo
	{
		public Vector3 location;
		public HitBox hitBox;
		public Mechanic mechanic;
		public float damage;
		
		public HitBoxInfo (Vector3 location, HitBox hitBox, Mechanic mechanic, float damage)
		{
			this.location=location;
			this.hitBox=hitBox;
			this.mechanic=mechanic;
			this.damage=damage;
		}
	}
}

