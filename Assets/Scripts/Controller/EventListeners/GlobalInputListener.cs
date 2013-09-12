using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using FightGame;
using FSM;

[System.Serializable]
public class PlayerControls{
	public KeyCode Regular 			= KeyCode.C;
	public KeyCode Unique			= KeyCode.F;
	public KeyCode Special			= KeyCode.V;
	public KeyCode Block			= KeyCode.B;
	public KeyCode RegularJoystick	= KeyCode.Joystick1Button0;
	public KeyCode UniqueJoystick	= KeyCode.Joystick1Button3;
	public KeyCode SpecialJoystick	= KeyCode.Joystick1Button2;
	public KeyCode BlockJoystick	= KeyCode.Joystick1Button1;
	public KeyCode Left				= KeyCode.A;
	public KeyCode Right			= KeyCode.D;
	public KeyCode Up				= KeyCode.W;
	public KeyCode Down				= KeyCode.S;
}

public class GlobalInputListener : MonoBehaviour {
	public PlayerControls p1Controls;
	public PlayerControls p2Controls;
	
	public PlayerControls GetControls( int playerNumber ){
		return (playerNumber == 1 ? this.p1Controls : this.p2Controls );
	}
	
	void Update(){
		GameManager.ProcessInput();
		GameManager.Update();
	}
}