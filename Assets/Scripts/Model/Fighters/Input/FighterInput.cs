using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using FightGame;

public class FighterInput : MonoBehaviour
{
	public string name;
	public List<Transform> jointTransforms;
	
	[HideInInspector]
	public Dictionary<string, Transform> joints;
	
	void Awake(){
		this.joints = new Dictionary<string, Transform>();
		
		if (this.joints != null){
			foreach (Transform t in this.jointTransforms){
				this.joints[t.name] = t;
			}
		}
	}
}

