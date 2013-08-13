using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame{
	public enum MoveCommand { FORWARD, FORWARD_DOWN, FORWARD_UP, BACK, BACK_DOWN, BACK_UP, UP, DOWN, NONE };
	public enum AttackCommand { REGULAR, UNIQUE, SPECIAL, BLOCK, NONE };
	
	public class GamePad{
		private Dictionary<string, KeyCode> keys;
		private MoveCommand[]				moveCommands;
		private AttackCommand[]				attackCommands;
		private string 						XAxis;
		private string						YAxis;
		private const float 				halfCircle 		= 3.1415f;
		private const float 				one16thCircle 	= 3.1415f/8.0f;
		private Player						player;
		
		public GamePad(Player player){
			int playerNumber 	= player.PlayerNumber + 1;
			
			this.player 		= player;
			this.keys 			= new Dictionary<string, KeyCode>();
			this.XAxis 			= "HorizontalP" + playerNumber;
			this.YAxis 			= "VerticalP" + playerNumber;
			this.AssignKeysByPlayerNumber(playerNumber);
			
			if (Application.platform.ToString().Substring(0, 3) == "OSX"){
				this.keys["RegularJoystick"] = (KeyCode) Enum.Parse(typeof(KeyCode), "Joystick" + playerNumber + "Button16");
				this.keys["UniqueJoystick"] = (KeyCode) Enum.Parse(typeof(KeyCode), "Joystick" + playerNumber + "Button19");
				this.keys["SpecialJoystick"] = (KeyCode) Enum.Parse(typeof(KeyCode), "Joystick" + playerNumber + "Button17");
				this.keys["BlockJoystick"] = (KeyCode) Enum.Parse(typeof(KeyCode), "Joystick" + playerNumber + "Button18");
			}
			
			this.moveCommands = new MoveCommand[] { MoveCommand.FORWARD, MoveCommand.FORWARD_DOWN, MoveCommand.FORWARD_UP, MoveCommand.BACK, MoveCommand.BACK_DOWN, MoveCommand.BACK_UP, MoveCommand.UP, MoveCommand.DOWN, MoveCommand.NONE };
			this.attackCommands = new AttackCommand[] { AttackCommand.REGULAR, AttackCommand.UNIQUE, AttackCommand.SPECIAL, AttackCommand.BLOCK, AttackCommand.NONE };
		}
		
		
		// Get a movement command when there has been an input
		public MoveCommand GetMoveCommand(){
			Vector2 inputDirection = this.GetInputDirection(this.XAxis, this.YAxis);
			return this.GetControllerDirection(inputDirection, this.player.Fighter.ForwardVector);
		}
		
		
		// Get a list of attack commands when there has been an input
		public List<AttackCommand> GetAttackCommands(){
			List<AttackCommand> commands = new List<AttackCommand>();
			foreach (AttackCommand ac in this.attackCommands){
				if ( this.IsCorrectCommand(ac) ){
					commands.Add(ac);
				}
			}
			return commands;
		}
		
		
		// Private Helper Functions
		private void AssignKeysByPlayerNumber(int number){
			switch (number){
			case 1:
				/*
				this.keys["LeftKey"] 	 		= KeyCode.LeftArrow;
				this.keys["RightKey"] 	 		= KeyCode.RightArrow;
				this.keys["UpKey"] 		 		= KeyCode.UpArrow;
				this.keys["DownKey"]	 		= KeyCode.DownArrow;
				this.keys["RegularKey"] 	 	= KeyCode.K;
				this.keys["UniqueKey"] 			= KeyCode.I;
				this.keys["SpecialKey"]	 		= KeyCode.J;
				this.keys["BlockKey"]	 		= KeyCode.L;
				*/
				this.keys["RegularJoystick"] 	= KeyCode.Joystick1Button0;
				this.keys["UniqueJoystick"] 	= KeyCode.Joystick1Button3;
				this.keys["SpecialJoystick"]	= KeyCode.Joystick1Button2;
				this.keys["BlockJoystick"]	  	= KeyCode.Joystick1Button1;
				break;
			case 2:
				/*
				this.keys["LeftKey"] 	 		= KeyCode.A;
				this.keys["RightKey"] 	 		= KeyCode.D;
				this.keys["UpKey"] 		 		= KeyCode.W;
				this.keys["DownKey"]	 		= KeyCode.S;
				this.keys["RegularKey"]			= KeyCode.V;
				this.keys["UniqueKey"] 	 		= KeyCode.F;
				this.keys["SpecialKey"]	 		= KeyCode.C;
				this.keys["BlockKey"]	 		= KeyCode.B;
				*/
				this.keys["RegularJoystick"] 	= KeyCode.Joystick2Button0;
				this.keys["UniqueJoystick"]		= KeyCode.Joystick2Button3;
				this.keys["SpecialJoystick"]	= KeyCode.Joystick2Button2;
				this.keys["BlockJoystick"]	  	= KeyCode.Joystick2Button1;
				break;
			default:
				break;
			}
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
		
		
		Vector2 ThreeD_to_TwoDVector(Vector3 direction)
		{
			return new Vector2(direction.x + direction.y + direction.z,0);
		}
		
		private MoveCommand GetControllerDirection(Vector2 inputDirection, Vector3 forwardDirection)
		{
			if (inputDirection.x == 0 && inputDirection.y == 0)
			{
				return MoveCommand.NONE;
			}
			else
			{
				float inputAngle = GetInputAngle(ThreeD_to_TwoDVector(forwardDirection), inputDirection);

				if (inputAngle >= 0 && inputAngle < one16thCircle * 1 ||
					inputAngle >= one16thCircle *15 && inputAngle < one16thCircle *16)
				{
					return MoveCommand.FORWARD;
				}
				else if (inputAngle >= one16thCircle *1 && inputAngle < one16thCircle *3)
				{
					return MoveCommand.FORWARD_UP;
				}
				else if (inputAngle >= one16thCircle *3 && inputAngle < one16thCircle *5)
				{
					return MoveCommand.UP;
				}
				else if (inputAngle >= one16thCircle *5 && inputAngle < one16thCircle *7)
				{
					return MoveCommand.BACK_UP;
				}
				else if (inputAngle >= one16thCircle *7 && inputAngle < one16thCircle *9)
				{
					return MoveCommand.BACK;
				}
				else if (inputAngle >= one16thCircle *9 && inputAngle < one16thCircle *11)
				{
					return MoveCommand.BACK_DOWN;
				}
				else if (inputAngle >= one16thCircle *11 && inputAngle < one16thCircle *13)
				{
					return MoveCommand.DOWN;
				}
				else if (inputAngle >= one16thCircle *13 && inputAngle < one16thCircle *15)
				{
					return MoveCommand.FORWARD_DOWN;
				}
				else
				{
					return MoveCommand.NONE;
				}
			}
		}
		
		
		private bool GetKey( string key ){
			if (this.keys.ContainsKey(key)){
				if (Input.GetKey(this.keys[key])){
					return true;
				}
			}
			
			//Debug.Log("Key " + key + " not found");
			return false;
		}
		
		private bool GetKeyDown( string key ){
			if (this.keys.ContainsKey(key)){
				if ( Input.GetKeyDown(this.keys[key]) ){
					return true;
				}
			}
			//Debug.Log("Key " + key + " not found");
			return false;
		}
		
		private float GetAxisRaw( string axis ){
			return ( Input.GetAxisRaw(axis) );
		}
		
		private bool IsCorrectCommand( AttackCommand command ){
			switch (command){
			case AttackCommand.REGULAR:
				return (this.GetKeyDown("RegularJoystick"));
				break;
			case AttackCommand.SPECIAL:
				return (this.GetKeyDown("SpecialJoystick"));
				break;
			case AttackCommand.UNIQUE:
				return (this.GetKeyDown("UniqueJoystick"));
				break;
			case AttackCommand.BLOCK:
				return (this.GetKeyDown("BlockJoystick"));
				break;
			default:
				break;
			}
			return false;
		}
	}
}