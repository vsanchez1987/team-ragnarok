using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Buff_Fury : A_Buff
	{
		GameObject fire;
		public Buff_Fury ( float duration, A_Fighter owner, string name, float chargeTime = 0.7f ) : base( duration, owner, name, chargeTime )
		{
			this.name = "Fury";
		}
		
		protected override void ApplyBuff(){
			owner.extraDamage *= 5.0f;
			
			GameObject load = (GameObject)Resources.Load("Particles/Ama_Fury", typeof(GameObject));
			this.fire = GameObject.Instantiate(load, this.owner.gobj.transform.position + new Vector3(0, 4, 0), load.transform.rotation) as GameObject;
			this.fire.transform.parent = owner.gobj.transform;
			GameObject.Destroy(this.fire, 5.0f);
			
			GameObject shock = GameObject.Instantiate(Resources.Load("Particles/Ama_FuryShock", typeof(GameObject)), this.owner.gobj.transform.position + Vector3.forward, load.transform.rotation) as GameObject;
			GameObject.Destroy(shock, 2.0f);
			
			Debug.Log("Buff: " + this.name + " Applied");
		}
		
		public override void DeActivate(){
			owner.extraDamage *= 0.2f;
			if (this.fire != null){
				GameObject.Destroy(this.fire);
				this.fire = null;
			}
			Debug.Log("Buff: " + this.name + " Removed");
			base.DeActivate();
		}
	}
}
