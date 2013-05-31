using UnityEngine;
using System.Collections;

public class Options_Menu : MonoBehaviour 
{
	
private bool created = false;
	
public Texture2D background, btn1, btn2, btn3, btn4;
	
public float WidthScale = 1.0f;
public float HeightScale = 1.0f;
	
//Campaign Height and Width
public float gameHght;
public float gameWdth;
	
//Story Mode Height and Width
public float videoHght;
public float videoWdth;
	
//Arcade Mode Height and Width
public float audioHght;
public float audioWdth;
	
//Survival Mode Height and Width
public float conHght;
public float conWdth;

//Campaign Offset X and Y
public float gameplayX = 0.0f;
public float gameplayY = 0.0f;
	
//Story Mode Offset X and Y
public float videoX = 0.0f;
public float videoY = 0.0f;
	
//Arcade Offset X and Y
public float audioX = 0.0f;
public float audioY = 0.0f;
	
//Survival Mode Offset X and Y
public float controlX = 0.0f;
public float controlY = 0.0f;
	
	void OnGUI()
	{
		if(background != null)
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height),background);
		
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Application.LoadLevel("mainMenu");
		}
		
		if (!created)
		{
		    if (GUI.Button(new Rect(gameplayX, gameplayY, gameWdth, gameHght), "Gameplay"))
			{
				Application.LoadLevel("gamePlay");
		        created = true;
			}	
		}
		
		if (!created)
		{
		    if (GUI.Button(new Rect(videoX, videoY, videoWdth, videoHght), "Video"))
			{
				Application.LoadLevel("gameStart");
		        created = true;
			}	
		}
		
		if (!created)
		{
		    if (GUI.Button(new Rect(audioX, audioY, audioWdth, audioHght), "Audio"))
			{
				Application.LoadLevel("gameStart");
		        created = true;
			}	
		}
		
		if (!created)
		{
		    if (GUI.Button(new Rect(controlX, controlY, conWdth, conHght), "Controller Config"))
			{
				Application.LoadLevel("gameStart");
		        created = true;
			}	
		}
	}
	
	void Update()
	{
		gameWdth = Screen.width * 0.2f * WidthScale;
		gameHght = Screen.height * 0.08f * HeightScale;
		
		gameplayX = Screen.width * 0.006f * WidthScale;
		gameplayY = Screen.height * 0.006f * HeightScale;
		
		videoWdth = Screen.width * 0.2f * WidthScale;
		videoHght = Screen.height * 0.08f * HeightScale;
		
		videoX = Screen.width * 0.006f * WidthScale;
		videoY = Screen.height * 0.006f * HeightScale;
		
		audioWdth = Screen.width * 0.2f * WidthScale;
		audioHght = Screen.height * 0.08f * HeightScale;
		
		conWdth = Screen.width * 0.2f * WidthScale;
		conHght = Screen.height * 0.08f * HeightScale;
	}
}
