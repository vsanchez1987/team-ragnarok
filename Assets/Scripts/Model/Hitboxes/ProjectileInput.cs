using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

public class ProjectileInput : MonoBehaviour
{
	public GameObject 	hitboxObject;
	
	[HideInInspector]
	public Vector3		direction;
	[HideInInspector]
	public HitBox 		hitbox;
	[HideInInspector]
	public float 		speed = 1.0f;
	
	void Update(){
		this.Execute();
		
		if(this.transform.position.y < 0){
			GameObject.Destroy(this.gameObject);
		}
	}
	
	protected virtual void Execute(){
		this.transform.Translate( direction * speed * 10.0f * Time.deltaTime );
	}
}

