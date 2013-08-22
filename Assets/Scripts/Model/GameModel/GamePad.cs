using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame{
	public enum MoveCommand { FORWARD, FORWARD_DOWN, FORWARD_UP, BACK, BACK_DOWN, BACK_UP, UP, DOWN, NONE };
	public enum ActionCommand {  NONE, BLOCK,
		REGULAR, REGULAR_FORWARD, REGULAR_BACK, REGULAR_UP, REGULAR_DOWN,
		UNIQUE, UNIQUE_FORWARD, UNIQUE_BACK, UNIQUE_UP, UNIQUE_DOWN, 
		SPECIAL, SPECIAL_FORWARD, SPECIAL_BACK, SPECIAL_UP, SPECIAL_DOWN
	};
	
	public class GamePad{
		private Dictionary<string, KeyCode> keys;
		private MoveCommand[]				moveCommands;
		private ActionCommand[]				actionCommands;
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
			Debug.Log(player.PlayerNumber.ToString() + " - XAxis: " + XAxis + " YAxis: " + YAxis);
			
			if (Application.platform.ToString().Substring(0, 3) == "OSX"){
				this.keys["RegularJoystick"] = (KeyCode) Enum.Parse(typeof(KeyCode), "Joystick" + playerNumber + "Button16");
				this.keys["UniqueJoystick"] = (KeyCode) Enum.Parse(typeof(KeyCode), "Joystick" + playerNumber + "Button19");
				this.keys["SpecialJoystick"] = (KeyCode) Enum.Parse(typeof(KeyCode), "Joystick" + playerNumber + "Button17");
				this.keys["BlockJoystick"] = (KeyCode) Enum.Parse(typeof(KeyCode), "Joystick" + playerNumber + "Button18");
			}
			
			this.moveCommands = new MoveCommand[] { MoveCommand.FORWARD, MoveCommand.FORWARD_DOWN, MoveCommand.FORWARD_UP, MoveCommand.BACK, MoveCommand.BACK_DOWN, MoveCommand.BACK_UP, MoveCommand.UP, MoveCommand.DOWN, MoveCommand.NONE };
			this.actionCommands = new ActionCommand[] { ActionCommand.REGULAR, ActionCommand.UNIQUE, ActionCommand.SPECIAL, ActionCommand.BLOCK, ActionCommand.NONE };
		}
		
		
		// Get a movement command when there has been an input
		public MoveCommand GetMoveCommand(){
			Vector2 inputDirection = this.GetInputDirection(this.XAxis, this.YAxis);
			return this.GetControllerDirection(inputDirection, this.player.Fighter.ForwardVector);
		}
		
		
		// Get a list of attack commands when there has been an input
		public List<ActionCommand> GetActionCommands(){
			List<ActionCommand> commands = new List<ActionCommand>();
			foreach (ActionCommand ac in this.actionCommands){
				if ( this.IsCorrectCommand(ac) ){
					commands.Add(ac);
				}
			}
			return commands;
		}
		
		// Get single action commands when there has been an input
		public ActionCommand GetActionCommand(){
			foreach (ActionCommand ac in this.actionCommands){
				if ( this.IsCorrectCommand(ac) ){
					return ac;
				}
			}
			return ActionCommand.NONE;
		}
		
		// Private Helper Functions
		private void AssignKeysByPlayerNumber(int number){
			PlayerControls controls 		= GameObject.Find("GlobalInputListener").GetComponent<GlobalInputListener>().GetControls(number);
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
		
		private bool IsCorrectCommand( ActionCommand command ){
			switch (command){
			case ActionCommand.BLOCK:
				return (this.GetKey("BlockJoystick") || this.GetKey("BlockKey"));
				break;
			case ActionCommand.REGULAR:
				return (this.GetKey("RegularJoystick") || this.GetKey("RegularKey"));
				break;
			case ActionCommand.SPECIAL:
				return (this.GetKey("SpecialJoystick") || this.GetKey("SpecialKey"));
				break;
			case ActionCommand.UNIQUE:
				return (this.GetKey("UniqueJoystick") || this.GetKey("UniqueKey"));
				break;
			default:
				break;
			}
			return false;
		}
	}
}