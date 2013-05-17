using UnityEngine;
using System.Collections;
using FightGame;
using FSM;

namespace FightGame
{
	public class Effect_Hit : A_Effect
	{
		public Effect_Hit(GameObject prefab){
			this.position = Vector3.zero;
			this.rotation = Quaternion.identity;
			this.prefab = prefab;
		}
		
		public override void Play()
		{
		}
		
		public override void DestroySelf()
		{
		}
	}
}

