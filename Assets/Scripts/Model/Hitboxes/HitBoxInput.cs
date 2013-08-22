using UnityEngine;
using System.Collections;
using FightGame;

public class HitBoxInput : MonoBehaviour
{
	[HideInInspector]
	public HitBox hitbox;
	
	void Update(){
		Debug.Log(this.hitbox.isProjectile);
	}
	
	void OnTriggerEnter( Collider other ){
		//Debug.Log(hitbox.gobj.name + " is Colliding with " + other.gameObject.name);
		if (other.tag == "HurtBox"){
			HurtBox hurtbox = other.GetComponent<HurtBoxInput>().hurtbox;
			if (hurtbox.owner.playerNumber != hitbox.owner.playerNumber){
				hurtbox.owner.TakeDamage(hitbox.damage, hurtbox);
				this.hitbox.Disable();
				
				if (this.hitbox.isProjectile){
					GameObject.Destroy(this.transform.parent.gameObject);
				}
			}
		}
		
		else if (other.tag == "HitBox"){
			if (this.hitbox.isProjectile && (this.tag != "SuperHitBox")){
				GameObject.Destroy(this.transform.parent.gameObject);
			}
		}
		
		else if (other.tag == "SuperHitBox"){
			if (this.hitbox.isProjectile){
				GameObject.Destroy(this.transform.parent.gameObject);
			}
		}
	}
}

