using UnityEngine;
using System.Collections;
using FightGame;

public class menu_Script : MonoBehaviour
{	
private bool created = false;
	
public Texture2D background, LOGO;
private string levelToLoadWhenClickedPlay = "gamestart";
private string[] AboutTextLines = new string[0];

private string clicked = "", messageDisplayOnCredits = "About \n ";
public float WidthScale = 1.0f;
public float HeightScale = 1.0f;
public float OffsetX = 0.0f;
public float OffsetY = 0.0f;
private float Width;
private float Height;
private Rect WindowRect;
private float volume = 1.0f;
	
	private void Start()
	{
		for(int x = 0; x < AboutTextLines.Length; x++)
		{
			messageDisplayOnCredits += AboutTextLines[x] + "\n";
		}
		messageDisplayOnCredits += "Press ESC to go back";
	}
	
    void OnGUI() 
	{
		Debug.Log("Width: " + Width);
		Debug.Log("Height: " + Height);
		WindowRect = new Rect( OffsetX, OffsetY, Width, Height);
		if(background != null)
			GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height),background);
		
		if(LOGO != null && clicked != "about")
			GUI.DrawTexture(new Rect((Screen.width / 2) - 100, 30, 200, 200), LOGO);
		
		
		if(clicked == "")
		{
			WindowRect = GUI.Window(0, WindowRect, menuFunc, "Main Menu");
			
			if(Input.GetKeyDown(KeyCode.LeftArrow))
			{
				Application.LoadLevel("startScreen");
			}
		}
		else if(clicked == "Single Player")
		{
			GUI.Button(new Rect(Screen.width/2 - 350 + OffsetX, Screen.height/2 + OffsetY, Width, Height), "Single Player");
		}
		else if(clicked == "Versus")
		{
			GUI.Button(new Rect(Screen.width/2 - 350 + OffsetX, Screen.height/2 + OffsetY, Width, Height), "Versus");
		}
		else if(clicked == "Options")
		{
			GUI.Button(new Rect(Screen.width/2 - 350 + OffsetX, Screen.height/2 + OffsetY, Width, Height), "Options");
		}
		else if(clicked == "Credits")
		{
			GUI.Box(new Rect(0, 0,Screen.width, Screen.height), messageDisplayOnCredits);
		}
    }

	private void menuFunc(int id)
	{
		if(GUILayout.Button("Single Player"))
		{
			Application.LoadLevel("singlePlayer");
		}
		if(GUILayout.Button("Versus"))
		{
			Application.LoadLevel("versus");
		}
		if(GUILayout.Button("Options"))
		{
			Application.LoadLevel("options");
		}
		if(GUILayout.Button("About"))
		{
			clicked = "about";
		}
		if(GUILayout.Button("Quit Game"))
		{
			Application.Quit();
		}

	}
	
	private void Update()
	{
		Width = Screen.width * 0.2f * WidthScale;
		Height = Screen.height * 0.5f * HeightScale;
		if(clicked == "about" && Input.GetKey(KeyCode.Escape))
			clicked = "";
	}
}