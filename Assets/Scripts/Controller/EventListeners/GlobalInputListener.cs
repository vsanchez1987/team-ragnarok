using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using FightGame;
using FSM;

public class GlobalInputListener : MonoBehaviour {
	void Update(){
		GameManager.ProcessInput();
		GameManager.Update();
	}
}