using UnityEngine;
using System.Collections;
using FightGame;

public class HurtBoxInput : MonoBehaviour
{
	[HideInInspector]
	public HurtBox hurtbox;
	
	public Location location;
	
	/*
	void OnTriggerEnter( Collider other ){
		//Debug.Log(hitbox.gobj.name + " is Colliding with " + other.gameObject.name);
		if (other.tag == "HitBox"){
			HurtBox hurtbox = other.GetComponent<HurtBoxInput>().hurtbox;
			if (hurtbox.attackOwner.playerNumber != hitbox.attackOwner.playerNumber){
				hurtbox.attackOwner.TakeDamage(hitbox.damage);
				hitbox.Disable();
				
				if (hitbox.isProjectile){
					GameObject.Destroy(this.transform.parent.gameObject);
				}
			}
		}
	}
	*/
}

