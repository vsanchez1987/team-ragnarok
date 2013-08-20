using UnityEngine;
using System.Collections;
using FightGame;

public class UI_Script : MonoBehaviour
{	
	private bool created = false;
	
    void OnGUI() {
		if (!created){
	        if (GUI.Button(new Rect(Screen.width/2, Screen.height/2 - 15, 50, 30), "Start")){
				GameManager.CreateFighter("Fighter_Odin",1);
				GameManager.CreateFighter("Fighter_Heavy",2);
	            created = true;
			}
		}
    }
}