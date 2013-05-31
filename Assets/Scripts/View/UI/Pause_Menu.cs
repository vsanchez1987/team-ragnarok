using UnityEngine;
using System.Collections;

public class Pause_Menu : MonoBehaviour 
{

public Font pauseMenuFont;
	
public Texture2D main,move,charSel,stageSel,options,quit;
	
public GUISkin pauseSkin;
public Rect pauseArea;
public Rect pauseBox;
public Rect mainButton;
public Rect moveButton;
public Rect charButton;
public Rect stageButton;
public Rect optionsButton;
public Rect quitButton;
	
private bool pauseEnabled = false;
	
private Rect pauseAreaNormalize;

	// Use this for initialization
	void Start () 
	{
		
		pauseEnabled = false;
		Time.timeScale = 1;
		AudioListener.volume = 1;
		Screen.showCursor = false;
	
	}
	
	// Update is called once per frame
	void Update () 
	{		
		pauseAreaNormalize =
			new Rect(pauseArea.x * Screen.width - (pauseArea.width * 0.5f),
				pauseArea.y * Screen.height - (pauseArea.height * 0.5f),
				pauseArea.width, pauseArea.height);

		//check if pause button (escape key) is pressed
		if(Input.GetKeyDown("escape"))
		{
			//check if game is already paused		
			if(pauseEnabled == true)
			{
				//unpause the game
				pauseEnabled = false;
				Time.timeScale = 1;
				AudioListener.volume = 1;
				Screen.showCursor = false;			
			}
			//else if game isn't paused, then pause it
			else if(pauseEnabled == false)
			{
				pauseEnabled = true;
				AudioListener.volume = 0;
				Time.timeScale = 0;
				Screen.showCursor = true;
			}
		}
	}
	
	void OnGUI()
	{
		GUI.skin.box.font = pauseMenuFont;
		GUI.skin.button.font = pauseMenuFont;
		
		if(pauseEnabled == true)
		{		
			GUI.skin = pauseSkin;
			
			GUI.BeginGroup(pauseAreaNormalize);
			
			GUI.Box(new Rect(pauseBox), "Pause Menu");
	
			if(GUI.Button(new Rect(mainButton), "Main Menu"))
			{
				Application.LoadLevel("mainMenu");
			}
			
			if(GUI.Button(new Rect(moveButton), "Move List"))
			{
				
			}
			
			if(GUI.Button(new Rect(charButton), "Return to Character Select"))
			{
				Application.LoadLevel("");
			}
			
			if(GUI.Button(new Rect(stageButton), "Return to Stage Select"))
			{
				Application.LoadLevel("");
			}
			
			if(GUI.Button(new Rect(optionsButton), "Options Menu"))
			{
				Application.LoadLevel("options");
			}
			
			if(GUI.Button(new Rect(quitButton), "Quit Game"))
			{
				Debug.Log("This works");
				Application.Quit();
			}
			
			GUI.EndGroup();

		}
	}
}
