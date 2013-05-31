using UnityEngine;
using System.Collections;

public class Single_Player : MonoBehaviour 
{
	
private bool created = false;
	
public Texture2D background, btn1, btn2, btn3, btn4;
	
public float WidthScale = 1.0f;
public float HeightScale = 1.0f;
	
//Campaign Height and Width
public float camHght;
public float camWdth;
	
//Story Mode Height and Width
public float storyHght;
public float storyWdth;
	
//Arcade Mode Height and Width
public float arcHght;
public float arcWdth;
	
//Survival Mode Height and Width
public float surHght;
public float surWdth;

//Campaign Offset X and Y
public float campaignX = 0.0f;
public float campaignY = 0.0f;
	
//Story Mode Offset X and Y
public float storyX = 0.0f;
public float storyY = 0.0f;
	
//Arcade Offset X and Y
public float arcadeX = 0.0f;
public float arcadeY = 0.0f;
	
//Survival Mode Offset X and Y
public float survivalX = 0.0f;
public float survivalY = 0.0f;
	
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
		    if (GUI.Button(new Rect(campaignX, campaignY, camWdth, camHght), "Campaign"))
			{
				Application.LoadLevel("gameStart");
		        created = true;
			}	
		}
		
		if (!created)
		{
		    if (GUI.Button(new Rect(storyX, storyY, storyWdth, storyHght), "Story Mode"))
			{
				Application.LoadLevel("gameStart");
		        created = true;
			}	
		}
		
		if (!created)
		{
		    if (GUI.Button(new Rect(arcadeX, arcadeY, arcWdth, arcHght), "Arcade"))
			{
				Application.LoadLevel("gameStart");
		        created = true;
			}	
		}
		
		if (!created)
		{
		    if (GUI.Button(new Rect(survivalX, survivalY, surWdth, surHght), "Survival Mode"))
			{
				Application.LoadLevel("gameStart");
		        created = true;
			}	
		}
	}
	
	void Update()
	{
		camWdth = Screen.width * 0.2f * WidthScale;
		camHght = Screen.height * 0.1f * HeightScale;
		
		storyWdth = Screen.width * 0.2f * WidthScale;
		storyHght = Screen.height * 0.1f * HeightScale;
		
		arcWdth = Screen.width * 0.2f * WidthScale;
		arcHght = Screen.height * 0.1f * HeightScale;
		
		surWdth = Screen.width * 0.2f * WidthScale;
		surHght = Screen.height * 0.1f * HeightScale;
	}
}
