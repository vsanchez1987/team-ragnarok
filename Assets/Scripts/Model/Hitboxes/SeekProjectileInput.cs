using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

public class SeekProjectileInput : ProjectileInput
{
	private	Vector3		newDirection;
	private float 		timer;
	private Vector3 	target;

	void Start()
	{
		this.target = hitbox.GetTarget().hurtBoxes["HurtBox_Hip"].gobj.transform.position;
		this.newDirection = Vector3.zero;
		this.timer = 0f;
	}
	
	protected override void Execute(){
		this.ReCenter();
		if(timer > 0.7f)
		{
			if ( this.newDirection == Vector3.zero){
				this.newDirection = target - this.transform.position;
			}
			this.transform.position += newDirection.normalized * speed * Time.deltaTime;
		}
		else{
			this.transform.position += direction;
		}

		timer += Time.deltaTime;
	}
}

