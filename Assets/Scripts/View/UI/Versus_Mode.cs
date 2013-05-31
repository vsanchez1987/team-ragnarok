using UnityEngine;
using System.Collections;

public class Versus_Mode : MonoBehaviour 
{
	
private bool created = false;
	
public Texture2D background, btn1, btn2, btn3, btn4;
	
public float WidthScale = 1.0f;
public float HeightScale = 1.0f;
	
//Campaign Height and Width
public float pvpHght;
public float pvpWdth;
	
//Story Mode Height and Width
public float tagHght;
public float tagWdth;
	
//Arcade Mode Height and Width
public float teamHght;
public float teamWdth;
	
//Survival Mode Height and Width
public float mvgHght;
public float mvgWdth;

//Campaign Offset X and Y
public float playerX = 0.0f;
public float playerY = 0.0f;
	
//Story Mode Offset X and Y
public float tagX = 0.0f;
public float tagY = 0.0f;
	
//Arcade Offset X and Y
public float teamX = 0.0f;
public float teamY = 0.0f;
	
//Survival Mode Offset X and Y
public float mechX = 0.0f;
public float mechY = 0.0f;
	
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
		    if (GUI.Button(new Rect(playerX, playerY, pvpWdth, pvpHght), "Player vs. Player"))
			{
				Application.LoadLevel("gameStart");
		        created = true;
			}	
		}
		
		if (!created)
		{
		    if (GUI.Button(new Rect(tagX, tagY, tagWdth, tagHght), "Tag Battle"))
			{
				Application.LoadLevel("gameStart");
		        created = true;
			}	
		}
		
		if (!created)
		{
		    if (GUI.Button(new Rect(teamX, teamY, teamWdth, teamHght), "Team Battle"))
			{
				Application.LoadLevel("gameStart");
		        created = true;
			}	
		}
		
		if (!created)
		{
		    if (GUI.Button(new Rect(mechX, mechY, mvgWdth, mvgHght), "Mech vs. Gods"))
			{
				Application.LoadLevel("gameStart");
		        created = true;
			}	
		}
	}
	
	void Update()
	{
		pvpWdth = Screen.width * 0.2f * WidthScale;
		pvpHght = Screen.height * 0.1f * HeightScale;
		
		tagWdth = Screen.width * 0.2f * WidthScale;
		tagHght = Screen.height * 0.1f * HeightScale;
		
		teamWdth = Screen.width * 0.2f * WidthScale;
		teamHght = Screen.height * 0.1f * HeightScale;
		
		mvgWdth = Screen.width * 0.2f * WidthScale;
		mvgHght = Screen.height * 0.1f * HeightScale;
	}
}
