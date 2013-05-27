using UnityEngine;
using System.Collections;

namespace FightGame
{
	public class HBM
	{
		public string HB_recipient; //name of hitbox msg is for
		public Vector3 startLoc; // relative to fighter, is vector3.zero if parented
		public Vector3 velocity;
		public float startTime;
		public float endTime;
		public float damage;
		public float radius;
		public Mechanic attackMechanic; //knowdown, launch etc..
		
		
		public HBM(string HB_recipient, float startTime, float endTime, float damage, Mechanic atkMechanic, Vector3 velocity,  Vector3 startLoc , float radius)
		{
			this.HB_recipient = HB_recipient;
			this.startTime=startTime;
			this.endTime=endTime;
			this.damage= damage;
			this.attackMechanic=atkMechanic;
			this.velocity = velocity;
			this.startLoc=startLoc;
			this.radius=radius;
		}
	}
}
