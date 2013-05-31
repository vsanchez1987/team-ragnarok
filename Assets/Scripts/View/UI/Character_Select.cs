using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character_Select : MonoBehaviour 
{
	
public GUISkin characterSkin;
public Rect godArea;
public Rect mechArea;
public Rect godBox;
public Rect mechBox;
public Rect god1Button;
public Rect god2Button;
public Rect god3Button;
public Rect mech1Button;
public Rect mech2Button;
public Rect mech3Button;
	
//List of textures for character selection
public List<Texture2D> godTextures = new List<Texture2D>();
public List<Texture2D> mechTextures = new List<Texture2D>();
	
private Texture2D godTex;
private Texture2D mechTex;
	
private Rect godAreaNormalize;
private Rect mechAreaNormalize;

	// Use this for initialization
	void Start () 
	{
		godTex = godTextures[3];
		mechTex = mechTextures[3];
	}
	
	// Update is called once per frame
	void Update () 
	{
		godAreaNormalize =
			new Rect(godArea.x * Screen.width - (godArea.width * 0.05f),
				godArea.y * Screen.height - (godArea.height * 0.02f),
				godArea.width, godArea.height);
		
		mechAreaNormalize =
			new Rect(mechArea.x / Screen.width + (mechArea.width * 0.75f),
				mechArea.y / Screen.height + (mechArea.height * 0.01f),
				mechArea.width, mechArea.height);
	}
	
	void OnGUI()
	{
		GUI.skin = characterSkin;
		
		//Buttons for Gods go here
		GUI.BeginGroup(godAreaNormalize);
		
		GUI.Box(new Rect(godBox), "Choose Your God");
		
		if(GUI.Button(new Rect(god1Button), "Odin"))
		{
			//Select this god
		}
		
		if(GUI.Button(new Rect(god2Button), "Amatarasu"))
		{
			//Select this god
		}
		
		if(GUI.Button(new Rect(god3Button), "Echidna"))
		{
			//Select this god
		}
		
		GUI.EndGroup();
		
		//Buttons for Mechs go here
		GUI.BeginGroup(mechAreaNormalize);
		
		GUI.Box(new Rect(mechBox), "Choose Your Mech");
		
				
		if(GUI.Button(new Rect(mech1Button), "Brazil Mech"))
		{
			//Select this mech
		}
		
		if(GUI.Button(new Rect(mech2Button), "US Mech"))
		{
			//Select this mech
		}
		
		if(GUI.Button(new Rect(mech3Button), "Japan Mech"))
		{
			//Select this mech
		}
		
		GUI.EndGroup();
	}
}
