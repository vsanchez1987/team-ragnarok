using UnityEngine;
using System.Collections;
using FightGame;
using FSM;

public class GlobalInputListener : MonoBehaviour {
	
	const float halfCircle = 3.14f;
	const float one16thCircle = halfCircle/8;
	
	void Start () {	}

	void Update ()
	{
		// we can add "foreach(A_Fighter Player in GameManager.players)" to prevent code duplication
		
		//Player 1 Input
		if (GameManager.P1!= null)
		{
			GameManager.P1.inputDirection = GetInputDirection(GameManager.P1.hAxis,GameManager.P1.vAxis);
			GameManager.P1.controllerDirection = GetControllerDirection(GameManager.P1.inputDirection);
			//GameManager.P1.attackPressed = Input.GetButton(GameManager.P1.atkBtn);
			GameManager.P1.attackPressed = Input.GetMouseButtonDown(0);
			GameManager.P1.uniquePressed = Input.GetButton(GameManager.P1.unqBtn);
			GameManager.P1.specialPressed = Input.GetButton(GameManager.P1.spcBtn);
			GameManager.P1.blockPressed = Input.GetButton(GameManager.P1.blckBtn);
		}
		
		//Player 2 Input
		if (GameManager.P2!= null)
		{
			GameManager.P2.inputDirection = GetInputDirection(GameManager.P2.hAxis,GameManager.P2.vAxis);
			GameManager.P2.controllerDirection = GetControllerDirection(GameManager.P2.inputDirection);
			GameManager.P1.attackPressed = Input.GetButton(GameManager.P2.atkBtn);
			GameManager.P1.uniquePressed = Input.GetButton(GameManager.P2.unqBtn);
		}			
		
		GameManager.Update();	
	}
	
	private Vector2 GetInputDirection(string hAxis, string vAxis)
	{
		return new Vector2(Input.GetAxis(hAxis),Input.GetAxisRaw(vAxis));
	}
	
	private float GetInputAngle(Vector2 forward, Vector2 inputDirection)
	{
		if(inputDirection.y>0)
			return Mathf.Acos(Vector2.Dot(inputDirection.normalized,forward));
		else if(inputDirection.y<0)
			return Mathf.Acos(Vector2.Dot(inputDirection.normalized,-forward)) + halfCircle;
		else if (inputDirection.normalized == -forward)
			return halfCircle;
		else
			return 0;
	}
	
	private string GetControllerDirection(Vector2 inputDirection)
	{
		
		if (inputDirection.x == 0 && inputDirection.y == 0)
		{
			return "none";
		}
		else
		{
			float inputAngle = GetInputAngle(GameManager.P1.ForwardVector, inputDirection);
			
			if (inputAngle >= 0 && inputAngle < one16thCircle * 1 ||
				inputAngle >= one16thCircle *15 && inputAngle < one16thCircle *16)
			{
				return "forward";
			}
			else if (inputAngle >= one16thCircle *1 && inputAngle < one16thCircle *3)
			{
				return"forwardUp";
			}
			else if (inputAngle >= one16thCircle *3 && inputAngle < one16thCircle *5)
			{
				return "up";
			}
			else if (inputAngle >= one16thCircle *5 && inputAngle < one16thCircle *7)
			{
				return "backUp";
			}
			else if (inputAngle >= one16thCircle *7 && inputAngle < one16thCircle *9)
			{
				return "back";
			}
			else if (inputAngle >= one16thCircle *9 && inputAngle < one16thCircle *11)
			{
				return "backDown";
			}
			else if (inputAngle >= one16thCircle *11 && inputAngle < one16thCircle *13)
			{
				return "down";
			}
			else if (inputAngle >= one16thCircle *13 && inputAngle < one16thCircle *15)
			{
				return "forwardDown";
			}
			else
			{
				return "invalid";
			}
		}

	}
	

}
