using UnityEngine;
using System.Collections;
using FightGame;
using FSM;

namespace FightGame
{
	public abstract class A_Effect
	{
		protected Vector3 position;
		protected Quaternion rotation;
		protected GameObject prefab;
		
		public abstract void Play();
		public abstract void DestroySelf();
	}
}

