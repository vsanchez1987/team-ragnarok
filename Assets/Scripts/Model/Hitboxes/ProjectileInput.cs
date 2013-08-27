using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

public class ProjectileInput : MonoBehaviour
{
	public GameObject 	hitboxObject;
	
	[HideInInspector]
	public Vector3		direction;
	public Vector3		newDirection;
	[HideInInspector]
	public HitBox 		hitbox;
	float timer;
	Vector3 target;
	[HideInInspector]
	public float speed;
	
	void Start()
	{
		this.target = hitbox.GetTarget().hurtBoxes["HurtBox_Hip"].gobj.transform.position;
		this.newDirection = Vector3.zero;
		timer = 0f;
	}
	
	void Update(){
		
		//Debug.Log(this.name);
		
		if(timer > 0.7f)
		{
			if(this.name == "Projectile_Seek(Clone)")
			{
				if ( this.newDirection == Vector3.zero){
					this.newDirection = target - this.transform.position;
				}
				this.transform.position += newDirection.normalized * speed * Time.deltaTime;
				//this.transform.Translate(newDirection*5*Time.deltaTime);
			}
			else{
				this.transform.position += direction;
			}
		}
		else{
			this.transform.position += direction;
		}
		if(this.transform.position.y < 0){
			GameObject.Destroy(this.gameObject);
		}
		
		timer +=Time.deltaTime;
	}
}

