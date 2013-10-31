using UnityEngine;
using System.Collections.Generic;
using System;
using FightGame;
using FSM;

public enum InputState { UI, FIGHTER };

namespace FightGame{
	public class GameManager {
		private static GameManager instance = new GameManager();
		private GameModel gModel;
		public static InputState inputState = InputState.FIGHTER;
		
	    private GameManager() {
			this.gModel = new GameModel();
	    }
		
	    public static GameManager Instance {
	        get { return instance; }
	    }
		
		public static Player P1{
			get { return instance.gModel.p1; }
		}
		
		public static Player P2{
			get { return instance.gModel.p2; }
		}
		
		public static FightCamera Camera{
			get { return instance.gModel.camera; }
		}
		
		public static UI_Script UI{
			get { return instance.gModel.ui; }
		}
		
		public static float LeftBoundary {
			get { return instance.gModel.leftBoundary; }
		}
		
		public static float RightBoundary {
			get { return instance.gModel.rightBoundary; }
		}
		
		public static GameSounds Sounds{
			get { return instance.gModel.sounds; }
		}
		
		public static void Restart(){
			instance.gModel.p1.RestartFighter();
			instance.gModel.p2.RestartFighter();
		}
		
		public static void ProcessInput(){
			if (GameManager.inputState == InputState.FIGHTER){
				foreach (Player p in instance.gModel.players){
					//Debug.Log("Player " + p.PlayerNumber);
					if (p.Fighter != null){
						int moveCommand = p.controls.GetMoveCommand();
						int actionCommand = p.controls.GetActionCommand();
						
						p.DoMoveCommand(moveCommand);
						p.DoActionCommand(actionCommand);
					}
				}
			}
			else if (GameManager.inputState == InputState.UI){
				// do UI stuff
			}
		}
		
		public static bool IsPlayerKeyPressed( int playerNumber, InputButton button ){
			return playerNumber == 1 ? 
				instance.gModel.p1.controls.IsKeyPressed( button ) 
					: instance.gModel.p2.controls.IsKeyPressed( button );
		}
		
		public static void Update(){
			if (instance.gModel.p1 != null){
				instance.gModel.p1.Update();
			}
			if (instance.gModel.p2 != null){
				instance.gModel.p2.Update();
			}
			if (instance.gModel.camera != null){
				instance.gModel.camera.Update();
			}
			
			if (instance.gModel.ui != null){
				if (instance.gModel.ui.hurtboxOn){
					GameObject[] hurtboxes = GameObject.FindGameObjectsWithTag("HurtBox");
					foreach (GameObject hurtbox in hurtboxes){
						if (!hurtbox.renderer.enabled){
							hurtbox.renderer.enabled = true;
						}
					}
				}
				else{
					GameObject[] hurtboxes = GameObject.FindGameObjectsWithTag("HurtBox");
					foreach (GameObject hurtbox in hurtboxes){
						if (hurtbox.renderer.enabled){
							hurtbox.renderer.enabled = false;
						}
					}
				}
			}
		}
		
		public static void CreateFighter(string fighter, int playerNum)
		{
			Player player = instance.gModel.players[playerNum - 1];
			GameObject locator = GameObject.FindGameObjectWithTag("LocatorP" + playerNum.ToString());
			
			player.InstantiateFighter(fighter, locator.transform.position, locator.transform.rotation);
		}
		
		public static float GetPlayersDistance(){
			return Mathf.Abs(instance.gModel.p1.Fighter.gobj.transform.position.x - instance.gModel.p2.Fighter.gobj.transform.position.x);
		}
		
		public static bool CheckCanMoveForward(A_Fighter fighter){
			if ( GameManager.P1.Fighter != null && GameManager.P2.Fighter != null ){
				if (GameManager.GetPlayersDistance() > GameManager.P1.Fighter.radius + GameManager.P2.Fighter.radius){
					if (fighter.GlobalForwardVector.x == 1){
						if (GameManager.CheckWithinRightBoundary(fighter)){
							return true;
						}
					}
					else if (fighter.GlobalForwardVector.x == -1){
						if (GameManager.CheckWithinLeftBoundary(fighter)){
							return true;
						}
					}
				}
			}
			return false;
		}
		
		
		public static bool CheckCanMoveBackward(A_Fighter fighter){
			if ( GameManager.P1.Fighter != null && GameManager.P2.Fighter != null ){
				if (GameManager.GetPlayersDistance() < GameManager.Camera.maxDistance){
					if (fighter.GlobalForwardVector.x == 1){
						if (GameManager.CheckWithinLeftBoundary(fighter)){
							return true;
						}
					}
					else if (fighter.GlobalForwardVector.x == -1){
						if (GameManager.CheckWithinRightBoundary(fighter)){
							return true;
						}
					}
				}
			}
			return false;
		}
		
		public static Player GetOpponentPlayer(int playerNumber){
			return playerNumber == 1 ? instance.gModel.p2 : instance.gModel.p1;
		}
		
		public static void AssignCharacterSelectInfo(string p1Fighter, string p2Fighter, string level)
		{
			Instance.gModel.p1.chosenFighter = p1Fighter;
			Instance.gModel.p2.chosenFighter = p2Fighter;
			Instance.gModel.chosenLevel = level;
			
		}
		
		private static bool CheckWithinLeftBoundary(A_Fighter fighter){
			return fighter.gobj.transform.position.x > GameManager.LeftBoundary;
		}
		
		private static bool CheckWithinRightBoundary(A_Fighter fighter){
			return fighter.gobj.transform.position.x < GameManager.RightBoundary;
		}
		
		public static void CreateFightCamera(){
			instance.gModel.camera = new FightCamera( instance.gModel.p1, instance.gModel.p2 );
			instance.gModel.leftBoundary = instance.gModel.camera.leftBoundary;
			instance.gModel.rightBoundary = instance.gModel.camera.rightBoundary;
		}
		
		public static void CreateFightUI(){
			instance.gModel.ui = GameObject.Find("UI").GetComponent<UI_Script>();
		}
		
		public static void PlayAudio (AudioClip sound){
			AudioSource.PlayClipAtPoint( sound, Camera.camera.transform.position );
		}
	}
}