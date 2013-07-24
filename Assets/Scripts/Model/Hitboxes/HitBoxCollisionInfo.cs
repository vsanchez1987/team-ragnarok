using UnityEngine;
using System.Collections;
using FightGame;
using System.Collections.Generic;

namespace FightGame
{
	public class HitBoxCollisionInfo
	{
		Vector3 location;
		Mechanic m;
		float damage;
		ParticleSystem particleSystem;
		A_Fighter hitPlayer;
	}
}
