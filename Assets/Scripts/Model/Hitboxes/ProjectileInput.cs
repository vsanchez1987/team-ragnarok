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
	
	void Update(){
		this.transform.position += direction;
	}
}

