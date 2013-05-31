using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character_Select : MonoBehaviour 
{
	
public bool P1CharSelect = false;
public bool P2CharSelect = false;
	
private float WidthScale = 1.0f;
private float HeightScale = 1.0f;
	
//Timer Offset, Width and Height
public float timerX;
public float timerY;
public float timerWdth;
public float timerHght;
	
//Random Offset, Width and Height
public float randomX;
public float randomY;
public float randomWdth;
public float randomHght;
	
public GUISkin characterSkin;
public Rect godArea;
public Rect mechArea;
public Rect godBox;
public Rect mechBox;
	
//God select buttons
public Rect god1Button;
public Rect god2Button;
public Rect god3Button;
public Rect god4Button;
public Rect god5Button;
public Rect god6Button;
public Rect god7Button;
public Rect god8Button;
public Rect god9Button;
	
//Mech select buttons
public Rect mech1Button;
public Rect mech2Button;
public Rect mech3Button;
public Rect mech4Button;
public Rect mech5Button;
public Rect mech6Button;
public Rect mech7Button;
public Rect mech8Button;
public Rect mech9Button;
	
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
		godTex = godTextures[4];
		mechTex = mechTextures[4];
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		timerWdth = Screen.width * 0.115f * WidthScale;
		timerHght = Screen.height * 0.154f * HeightScale;
		
		timerX = Screen.width * 0.44f * WidthScale;
		timerY = Screen.height * 0.07f * HeightScale;
		
		randomWdth = Screen.width * 0.115f * WidthScale;
		randomHght = Screen.height * 0.154f * HeightScale;
		
		randomX = Screen.width * 0.44f * WidthScale;
		randomY = Screen.height * 0.75f * HeightScale;
		
		godAreaNormalize =
			new Rect(godArea.x * Screen.width - (godArea.width * 0.05f),
				godArea.y * Screen.height - (godArea.height * 0.01f),
				godArea.width * Screen.width, godArea.height * Screen.height);
		
		mechAreaNormalize =
			new Rect(mechArea.x / Screen.width + (mechArea.width * 0.75f),
				mechArea.y / Screen.height + (mechArea.height * 0.01f - 110.0f),
				mechArea.width * Screen.width, mechArea.height * Screen.height);
	}
	
	void OnGUI()
	{
		GUI.skin = characterSkin;
		
		GUI.Box(new Rect(timerX, timerY, timerWdth, timerHght),"");
		
		GUI.Box(new Rect(randomX, randomY, randomWdth, randomHght),"");
		
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
		
		if(GUI.Button(new Rect(god4Button), "God 4"))
		{
			//Select this god
		}
		
		if(GUI.Button(new Rect(god5Button), "God 5"))
		{
			//Select this god
		}
		
		if(GUI.Button(new Rect(god6Button), "God 6"))
		{
			//Select this god
		}
		
		if(GUI.Button(new Rect(god7Button), "God 7"))
		{
			//Select this god
		}
		
		if(GUI.Button(new Rect(god8Button), "God 8"))
		{
			//Select this god
		}
		
		if(GUI.Button(new Rect(god9Button), "God 9"))
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
		
		if(GUI.Button(new Rect(mech2Button), "Heacy"))
		{
			//Select this mech
		}
		
		if(GUI.Button(new Rect(mech3Button), "Japan Mech"))
		{
			//Select this mech
		}
		
		if(GUI.Button(new Rect(mech4Button), "China Mech"))
		{
			//Select this mech
		}
		
		if(GUI.Button(new Rect(mech5Button), "Russia Mech"))
		{
			//Select this mech
		}
		
		if(GUI.Button(new Rect(mech6Button), "England Mech"))
		{
			//Select this mech
		}
		
		if(GUI.Button(new Rect(mech7Button), "Spain Mech"))
		{
			//Select this mech
		}
		
		if(GUI.Button(new Rect(mech8Button), "Mexico Mech"))
		{
			//Select this mech
		}
		
		if(GUI.Button(new Rect(mech9Button), "Sweden Mech"))
		{
			//Select this mech
		}
		
		GUI.EndGroup();
	}
}
