using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using FightGame;

[System.Serializable]
public class Animations{
	public AnimationClip WalkForward;
	public AnimationClip WalkBackward;
	public AnimationClip Idle;
	public AnimationClip Block;
	public AnimationClip FlinchUp;
	public AnimationClip FlinchDown;
	
	public AnimationClip RegularAttack;
	public AnimationClip RegularForwardAttack;
	public AnimationClip RegularBackAttack;
	public AnimationClip RegularUpAttack;
	public AnimationClip RegularDownAttack;
	
	public AnimationClip UniqueAttack;
	public AnimationClip UniqueForwardAttack;
	public AnimationClip UniqueBackAttack;
	public AnimationClip UniqueUpAttack;
	public AnimationClip UniqueDownAttack;
	
	public AnimationClip SpecialAttack;
	public AnimationClip SpecialForwardAttack;
	public AnimationClip SpecialBackAttack;
	public AnimationClip SpecialUpAttack;
	public AnimationClip SpecialDownAttack;
	
}

public enum FighterAnimation { WALK_FORWARD, WALK_BACKWARD, IDLE, BLOCK, FLINCH_UP, FLINCH_DOWN,
	REGULAR_ATTACK, REGULAR_FORWARD_ATTACK, REGULAR_BACK_ATTACK, REGULAR_UP_ATTACK, REGULAR_DOWN_ATTACK, 
	UNIQUE_ATTACK, UNIQUE_FORWARD_ATTACK, UNIQUE_BACK_ATTACK, UNIQUE_UP_ATTACK, UNIQUE_DOWN_ATTACK, 
	SPECIAL_ATTACK, SPECIAL_FORWARD_ATTACK, SPECIAL_BACK_ATTACK, SPECIAL_UP_ATTACK, SPECIAL_DOWN_ATTACK, 
};

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
		
		this.animationNameMap[FighterAnimation.WALK_FORWARD] 			= this.animations.WalkForward.name;
		this.animationNameMap[FighterAnimation.WALK_BACKWARD] 			= this.animations.WalkBackward.name;
		this.animationNameMap[FighterAnimation.IDLE] 					= this.animations.Idle.name;
		this.animationNameMap[FighterAnimation.BLOCK]		 			= this.animations.Block.name;
		this.animationNameMap[FighterAnimation.FLINCH_UP]		 		= this.animations.FlinchUp.name;
		this.animationNameMap[FighterAnimation.FLINCH_DOWN]		 		= this.animations.FlinchDown.name;
		
		this.animationNameMap[FighterAnimation.REGULAR_ATTACK] 			= this.animations.RegularAttack.name;
		this.animationNameMap[FighterAnimation.REGULAR_FORWARD_ATTACK] 	= this.animations.RegularForwardAttack.name;
		this.animationNameMap[FighterAnimation.REGULAR_BACK_ATTACK] 	= this.animations.RegularBackAttack.name;
		this.animationNameMap[FighterAnimation.REGULAR_UP_ATTACK] 		= this.animations.RegularUpAttack.name;
		this.animationNameMap[FighterAnimation.REGULAR_DOWN_ATTACK] 	= this.animations.RegularDownAttack.name;
		
		this.animationNameMap[FighterAnimation.SPECIAL_ATTACK] 			= this.animations.SpecialAttack.name;
		this.animationNameMap[FighterAnimation.SPECIAL_FORWARD_ATTACK] 	= this.animations.SpecialForwardAttack.name;
		this.animationNameMap[FighterAnimation.SPECIAL_BACK_ATTACK] 	= this.animations.SpecialBackAttack.name;
		this.animationNameMap[FighterAnimation.SPECIAL_UP_ATTACK] 		= this.animations.SpecialUpAttack.name;
		this.animationNameMap[FighterAnimation.SPECIAL_DOWN_ATTACK] 	= this.animations.SpecialDownAttack.name;
		
		this.animationNameMap[FighterAnimation.UNIQUE_ATTACK] 			= this.animations.UniqueAttack.name;
		this.animationNameMap[FighterAnimation.UNIQUE_FORWARD_ATTACK] 	= this.animations.UniqueForwardAttack.name;
		this.animationNameMap[FighterAnimation.UNIQUE_BACK_ATTACK] 		= this.animations.UniqueBackAttack.name;
		this.animationNameMap[FighterAnimation.UNIQUE_UP_ATTACK] 		= this.animations.UniqueUpAttack.name;
		this.animationNameMap[FighterAnimation.UNIQUE_DOWN_ATTACK] 		= this.animations.UniqueDownAttack.name;
	}
}