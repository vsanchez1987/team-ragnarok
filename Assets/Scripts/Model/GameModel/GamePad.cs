using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame{
	public class GamePad{
		private Dictionary<string, KeyCode> keys;
		private int[]						moveCommands;
		private int[]						actionCommands;
		private string 						XAxis;
		private string						YAxis;
		private const float 				halfCircle 		= 3.1415f;
		private const float 				one16thCircle 	= 3.1415f/8.0f;
		private Player						player;
		
		public GamePad(Player player){
			int playerNumber 	= player.PlayerNumber;
			
			this.player 		= player;
			this.keys 			= new Dictionary<string, KeyCode>();
			this.XAxis 			= "HorizontalP" + playerNumber;
			this.YAxis 			= "VerticalP" + playerNumber;
			this.AssignKeysByPlayerNumber(playerNumber);
			//Debug.Log(player.PlayerNumber.ToString() + " - XAxis: " + XAxis + " YAxis: " + YAxis);
			
			if (Application.platform.ToString().Substring(0, 3) == "OSX"){
				this.keys["RegularJoystick"] = (KeyCode) Enum.Parse(typeof(KeyCode), "Joystick" + playerNumber + "Button18");
				this.keys["UniqueJoystick"] = (KeyCode) Enum.Parse(typeof(KeyCode), "Joystick" + playerNumber + "Button19");
				this.keys["SpecialJoystick"] = (KeyCode) Enum.Parse(typeof(KeyCode), "Joystick" + playerNumber + "Button17");
				this.keys["BlockJoystick"] = (KeyCode) Enum.Parse(typeof(KeyCode), "Joystick" + playerNumber + "Button16");
			}
			
			this.moveCommands = new int[] { MoveCommand.FORWARD, MoveCommand.FORWARD_DOWN, MoveCommand.FORWARD_UP, MoveCommand.BACK, MoveCommand.BACK_DOWN, MoveCommand.BACK_UP, MoveCommand.UP, MoveCommand.DOWN, MoveCommand.NONE };
			this.actionCommands = new int[] { ActionCommand.REGULAR, ActionCommand.UNIQUE, ActionCommand.SPECIAL, ActionCommand.BLOCK, ActionCommand.NONE };
		}
		
		
		// Get a movement command when there has been an input
		public int GetMoveCommand(){
			Vector2 inputDirection = this.GetInputDirection(this.XAxis, this.YAxis);
			return this.GetControllerDirection(inputDirection, this.player.Fighter.GlobalForwardVector);
		}
		
		
		// Get a list of attack commands when there has been an input
		public List<int> GetActionCommands(){
			List<int> commands = new List<int>();
			foreach (int ac in this.actionCommands){
				if ( this.IsCorrectCommand(ac) ){
					commands.Add(ac);
				}
			}
			return commands;
		}
		
		// Get single action commands when there has been an input
		public int GetActionCommand(){
			foreach (int ac in this.actionCommands){
				if ( this.IsCorrectCommand(ac) ){
					return ac;
				}
			}
			return ActionCommand.NONE;
		}
		
		// Private Helper Functions
		private void AssignKeysByPlayerNumber(int number){
			PlayerControls controls 		= GameObject.Find("GlobalInputListener").GetComponent<GlobalInputListener>().GetControls(number);
			this.keys["Left"]				= controls.Left;
			this.keys["Right"]				= controls.Right;
			this.keys["Up"]					= controls.Up;
			this.keys["Down"]				= controls.Down;
			this.keys["RegularKey"] 		= controls.Regular;
			this.keys["UniqueKey"] 			= controls.Unique;
			this.keys["SpecialKey"]			= controls.Special;
			this.keys["BlockKey"]	  		= controls.Block;
			this.keys["RegularJoystick"] 	= controls.RegularJoystick;
			this.keys["UniqueJoystick"] 	= controls.UniqueJoystick;
			this.keys["SpecialJoystick"]	= controls.SpecialJoystick;
			this.keys["BlockJoystick"]	  	= controls.BlockJoystick;
		}
		
		
		private Vector2 GetInputDirection(string hAxis, string vAxis)
		{
			float horizontal = 0.0f;
			float vertical = 0.0f;
			
			if (Input.GetKey(this.keys["Left"])){
				horizontal = -1.0f;
			}
			else if (Input.GetKey(this.keys["Right"])){
				horizontal = 1.0f;
			}
			
			if (Input.GetKey(this.keys["Up"])){
				vertical = 1.0f;
			}
			else if (Input.GetKey(this.keys["Down"])){
				vertical = -1.0f;
			}
			
			if (Input.GetAxisRaw(hAxis) != 0){
				horizontal = Input.GetAxisRaw(hAxis);
			}
			
			if (Input.GetAxisRaw(vAxis) != 0){
				vertical = Input.GetAxisRaw(vAxis);
			}
			
			return new Vector2(horizontal, vertical);
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
		
		private int GetControllerDirection(Vector2 inputDirection, Vector3 forwardDirection)
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
			return false;
		}
		
		private bool GetKeyDown( string key ){
			if (this.keys.ContainsKey(key)){
				if ( Input.GetKeyDown(this.keys[key]) ){
					return true;
				}
			}
			return false;
		}
		
		private float GetAxisRaw( string axis ){
			return ( Input.GetAxisRaw(axis) );
		}
		
		private bool IsCorrectCommand( int command ){
			switch (command){
			case ActionCommand.BLOCK:
				return (this.GetKey("BlockJoystick") || this.GetKey("BlockKey"));
			case ActionCommand.REGULAR:
				return (this.GetKeyDown("RegularJoystick") || this.GetKeyDown("RegularKey"));
			case ActionCommand.SPECIAL:
				return (this.GetKeyDown("SpecialJoystick") || this.GetKeyDown("SpecialKey"));
			case ActionCommand.UNIQUE:
				return (this.GetKeyDown("UniqueJoystick") || this.GetKeyDown("UniqueKey"));
			default:
				break;
			}
			return false;
		}
	}
}