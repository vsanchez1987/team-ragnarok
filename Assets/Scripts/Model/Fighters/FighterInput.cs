using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using FightGame;

[System.Serializable]
public class Animations{
	public string WalkForward;
	public string WalkBackward;
	public string Idle;
	public string RegularAttack;
}

public enum FighterAnimation { WALK_FORWARD, WALK_BACKWARD, IDLE, REGULAR_ATTACK };

public class FighterInput : MonoBehaviour
{
	public string name;
	public List<GameObject> hurtboxObjects;
	public List<GameObject> hitboxObjects;
	public List<Transform>	jointTransforms;
	public Animations 		animations;
	
	[HideInInspector]
	public Dictionary<FighterAnimation, string> animationNameMap;
	
	void Awake(){
		this.animationNameMap = new Dictionary<FighterAnimation, string>();
		this.animationNameMap[FighterAnimation.WALK_FORWARD] 	= this.animations.WalkForward;
		this.animationNameMap[FighterAnimation.WALK_BACKWARD] 	= this.animations.WalkBackward;
		this.animationNameMap[FighterAnimation.IDLE] 			= this.animations.Idle;
		this.animationNameMap[FighterAnimation.REGULAR_ATTACK] 	= this.animations.RegularAttack;
	}
}