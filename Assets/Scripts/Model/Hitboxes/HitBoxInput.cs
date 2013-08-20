using UnityEngine;
using System.Collections;
using FightGame;

public class HitBoxInput : MonoBehaviour
{
	[HideInInspector]
	public HitBox hitbox;
	
	void OnTriggerEnter( Collider other ){
		//Debug.Log(hitbox.gobj.name + " is Colliding with " + other.gameObject.name);
		if (other.tag == "HurtBox"){
			HurtBox hurtbox = other.GetComponent<HurtBoxInput>().hurtbox;
			if (hurtbox.owner.playerNumber != hitbox.owner.playerNumber){
				hurtbox.owner.TakeDamage(hitbox.damage);
				hitbox.Disable();
				
				if (hitbox.isProjectile){
					GameObject.Destroy(this.transform.parent.gameObject);
				}
			}
		}
	}
}

