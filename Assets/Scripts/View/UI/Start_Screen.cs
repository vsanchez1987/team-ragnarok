using UnityEngine;
using System.Collections;
using FightGame;

public class Start_Screen : MonoBehaviour 
{
	
private bool created = false;
	
public Texture2D background, btn;
	
public float WidthScale = 1.0f;
public float HeightScale = 1.0f;
	
public float hght;
public float wdth;

public float OffsetX = 0.0f;
public float OffsetY = 0.0f;
	
	void OnGUI()
	{
		
		if(background != null)
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height),background);
		
		if (!created)
		{
		    if (GUI.Button(new Rect(OffsetX, OffsetY, wdth, hght), "Press Start"))
			{
				Application.LoadLevel("mainMenu");
		        created = true;
			}	
		}
				
	}
	
	void Update()
	{
		wdth = Screen.width * 0.2f * WidthScale;
		hght = Screen.height * 0.1f * HeightScale;
		
		OffsetX = Screen.width * 0.44f * WidthScale;
		OffsetY = Screen.height * 0.731f * HeightScale;
	}

}
