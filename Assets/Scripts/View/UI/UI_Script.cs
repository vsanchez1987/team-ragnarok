using UnityEngine;
using System.Collections;
using FightGame;

public class UI_Script : MonoBehaviour
{	
	private bool created = false;
	
    void OnGUI() {
		if (!created){
	        if (GUI.Button(new Rect(Screen.width/2, Screen.height/2, 50, 30), "Start")){
				GameManager.CreateFighter("Fighter_Heavy",1);
				GameManager.CreateFighter("Fighter_Odin",2);
	            created = true;
			}
			/*
			if (GUI.Button(new Rect(Screen.width/3, Screen.height/2, 50, 30), "Heacy")){
				GameManager.CreateFighter("Fighter_Heacy");
	            created = true;
			}
			*/
		}
		/*
		else{
			if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2, 100, 30), "Idle")){
				//GameManager.P1.Dispatch("idle");
			}
			if (GUI.Button(new Rect(Screen.width/2 + 100, Screen.height/2, 100, 30), "Walk Forward")){
				//GameManager.P1.Dispatch("walkForward");
			}
		}
		*/
    }
}