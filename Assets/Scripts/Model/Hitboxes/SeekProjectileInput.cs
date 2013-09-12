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
		//this.transform.rotation = Quaternion.AngleAxis(-90,Vector3.forward);
		this.target = hitbox.GetTarget().hurtBoxes["HurtBox_Head"].gobj.transform.position;
		
		this.newDirection = Vector3.zero;
		this.timer = 0f;
	}
	
	protected override void Execute(){
		this.transform.LookAt(this.target);
		this.ReCenter();
		if(timer > 0.2f && timer < 0.6f)
		{
			this.transform.position += new Vector3(1.0f * this.hitbox.attackOwner.GlobalForwardVector.x, 0, 0).normalized * speed * Time.deltaTime;	
		}
		if(timer > 0.6f)
		{
			if ( this.newDirection == Vector3.zero){
				this.newDirection = target - this.transform.position;
			}
			speed = 30f;
			this.transform.position += newDirection.normalized * speed * Time.deltaTime;
		}
		else{
			this.transform.position += direction;
		}

		timer += Time.deltaTime;
	}
}

