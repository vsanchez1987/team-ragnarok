using UnityEngine;
using System.Collections;

public class Main_Menu : MonoBehaviour 
{
	
private bool created = false;
	
public Texture2D background;
	
public float hght;
public float wdth;

public float singleX = 0.0f;
public float singleY = 0.0f;
	
public float versusX = 0.0f;
public float versusY = 0.0f;
	
	

	void OnGUI()
	{
		
		if(background != null)
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height),background);
		
		if (!created)
		{
		    if (GUI.Button(new Rect(Screen.width/2 - 350 + singleX, Screen.height/2 + singleY, wdth, hght), "Single Player"))
			{
				Application.LoadLevel("singlePlayer");
		        created = true;
			}
		}
		
		if (!created)
		{
		    if (GUI.Button(new Rect(Screen.width/2 - 350 + versusX, Screen.height/2 + versusY, wdth, hght), "Versus"))
			{
				Application.LoadLevel("versus");
		        created = true;
			}
		}
	}
}
