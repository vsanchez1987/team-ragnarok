using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;
public class CharacterSelect_UI : MonoBehaviour {
	

	public int portrait_offX = 337 , portrait_offY =353;
	public int name_offX = 337 , name_offY =353;
	public int selection_offX = 337 , selection_offY =353;
	
	public GUIStyle menuItem_GUIstyle;
	public Texture2D p1SelectTexture, p2SelectTexture,portraitBG;
	
	//NOTE THESE MUST MATCH THE NAMES IN Start() function
	Dictionary<string,Texture2D> characterPortraits;
	
	
	public List<Texture2D> Portraits;
	public Vector2 p1SelectLocation,p2SelectLocation;
	
	private bool  p1MovingH,p2MovingH,p2MovingV,p1MovingV;
	
	private string p1SelectedChar=null, p2SelectedChar=null;
	public int paddingX, paddingY;
	string[,] characters;
	
	void Start ()
	{
		characterPortraits = new Dictionary<string, Texture2D>();
		characters = new string[3,3]{
						 {"Heavy","Amaterasu", "Amaterasu"},
					     {"Heavy" ,"none"     , "none"},
					     {"none" ,"none"     , "none"}
						};
		foreach (Texture2D img in Portraits)
		{
			if (img!=null && img.name != null)
			{
				if(!characterPortraits.ContainsKey(img.name))
					characterPortraits.Add( img.name,img);
			}
		}
		
		
		
	}
	

	void Update ()
	{
		//process input
		//P1 MOVING VERT
		if (!p1MovingH)
		{
			if(Input.GetAxis("HorizontalP1") > 0.2f || Input.GetKeyDown(KeyCode.D))
			{
				Debug.Log("pushing right");
				if(p1SelectLocation.x < 2)
					p1SelectLocation+=Vector2.right;
			}
			if(Input.GetAxis("HorizontalP1") < -0.2f || Input.GetKeyDown(KeyCode.A))
			{
				Debug.Log("pushing  left");
				if(p1SelectLocation.x > 0)
					p1SelectLocation-=Vector2.right;
			}
		}
		
		// P1 MOVING RIGHT AND LEFT
		if (!p1MovingV)
		{
			if(Input.GetAxis("VerticalP1") > 0.2f || Input.GetKeyDown(KeyCode.S))
			{
				Debug.Log("pushing down");
				if(p1SelectLocation.y < 2)
					p1SelectLocation+=Vector2.up;
			}
			if(Input.GetAxis("VerticalP1") < -0.2f || Input.GetKeyDown(KeyCode.W))
			{
				
				Debug.Log("pushing  up");
				if(p1SelectLocation.y > 0)
					p1SelectLocation-=Vector2.up;
			}
		}
		
		// P1 KEEP TRACK OF JOYSTICK SENSITIVITY
		if (Mathf.Abs( Input.GetAxis("HorizontalP1")) > 0.2f)
		{
			p1MovingH = true;
		}
		else
		{
			p1MovingH = false;
		}
		
		if (Mathf.Abs( Input.GetAxis("VerticalP1")) > 0.2f)
		{
			p1MovingV = true;
		}
		else
		{
			p1MovingV = false;
		}
		
		/// P1 SELECT PLAYER
		if(Input.GetKeyDown(KeyCode.Joystick1Button0) ||  Input.GetKeyDown(KeyCode.C))
		{
			p1SelectedChar = 	characters[(int)p1SelectLocation.y,(int)p1SelectLocation.x];
			Debug.Log("pressing button at " + p1SelectedChar);	
		}
		
		///////
		
		// Player 2
		//P2 MOVING VERT
		if (!p2MovingH)
		{
			if(Input.GetAxis("HorizontalP2") > 0.2f || Input.GetKeyDown(KeyCode.RightArrow))
			{
				Debug.Log("pushing right");
				if(p2SelectLocation.x < 2)
					p2SelectLocation+=Vector2.right;
			}
			if(Input.GetAxis("HorizontalP2") < -0.2f || Input.GetKeyDown(KeyCode.LeftArrow))
			{
				Debug.Log("pushing  left");
				if(p2SelectLocation.x > 0)
					p2SelectLocation-=Vector2.right;
			}
		}
		
		// P2 MOVING RIGHT AND LEFT
		if (!p2MovingV)
		{
			if(Input.GetAxis("VerticalP2") > 0.2f || Input.GetKeyDown(KeyCode.DownArrow))
			{
				Debug.Log("pushing down");
				if(p2SelectLocation.y < 2)
					p2SelectLocation+=Vector2.up;
			}
			if(Input.GetAxis("VerticalP2") < -0.2f || Input.GetKeyDown(KeyCode.UpArrow))
			{
				
				Debug.Log("pushing  up");
				if(p2SelectLocation.y > 0)
					p2SelectLocation-=Vector2.up;
			}
		}
		
		// P2 KEEP TRACK OF JOYSTICK SENSITIVITY
		if (Mathf.Abs( Input.GetAxis("HorizontalP2")) > 0.2f)
		{
			p2MovingH = true;
		}
		else
		{
			p2MovingH = false;
		}
		
		if (Mathf.Abs( Input.GetAxis("VerticalP2")) > 0.2f)
		{
			p2MovingV = true;
		}
		else
		{
			p2MovingV = false;
		}
		
		/// P2 SELECT PLAYER
		if(Input.GetKeyDown(KeyCode.Joystick2Button0) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Return))
		{
			p2SelectedChar = 	characters[(int)p2SelectLocation.y,(int)p2SelectLocation.x];
			Debug.Log("pressing button at " + p2SelectedChar);	
		}

		

	}
	
	void OnGUI() 
	{
		float aspectW = Screen.width/1024.0f;
		float aspectH = Screen.height/768.0f;
		
		
		//DrawTitle(aspectH,aspectW,GameTitle_Texture,title_offX,title_offY);
		/*
		switch (state)
		{
			case titleState.START:
				
				if(DrawStart(aspectH,aspectW,start_offX,start_offY,menuItem_GUIstyle))//|| Input.anyKey)
				{
					LoadMenu();
				}
				DrawBlackOverlay( aspectH, aspectW, Black_Texture,blackfadeTime);
				break;
			case titleState.MENU:
			 	int selection = DrawMenu(aspectH,aspectW,start_offX,start_offY,menuItem_GUIstyle);
				if(selection>0)
				{
					LoadGame(selection);
				}
				break;
			default:
			break;
			
		}
		
		*/
		
		DrawMenuGUI(aspectH,aspectW,portrait_offX,portrait_offY, menuItem_GUIstyle,p1SelectLocation,p2SelectLocation,characterPortraits,p1SelectTexture,p2SelectTexture,portraitBG);
		
	}
	int DrawMenuGUI(float aspectH, float aspectW, int offX,int offY,GUIStyle style,Vector2 p1Loc, Vector2 p2Loc, Dictionary<string,Texture2D> characterPortraits,Texture2D p1SelectTexture,Texture2D p2SelectTexture,Texture2D portraitBG)
	{
		const int imageW = 128;
		const int imageH = 128;
		const int fontSize = 20;
		
		
		float rectWidth 			= (imageW*aspectW);
		float rectHeight 			= (imageH*aspectH);
		style.fontSize = (int)(fontSize * aspectH);

		
		for (int i=0;i<3;i++)
		{
				for (int j=0;j<3;j++)
				{
					Rect myRect = new Rect(
									portrait_offX * aspectW + j * rectWidth + paddingY * aspectW*j,
									portrait_offY * aspectH + i * rectHeight + paddingX * aspectH*i,
									rectWidth,
									rectHeight);
					string charName = characters[i,j] ;
					
					// draw portrait bg
					GUI.DrawTexture(myRect,portraitBG,ScaleMode.StretchToFill,true,0);
				
					//draw character
					if(charName!="none")
					{
						GUI.DrawTexture(myRect,characterPortraits[charName ],ScaleMode.StretchToFill,true,0);
					}
				
					myRect = new Rect(
									name_offX * aspectW + j * rectWidth + paddingY * aspectW*j,
									name_offY * aspectH + i * rectHeight + paddingX * aspectH*i,
									rectWidth,
									rectHeight);
					
					// craw character Name
					GUI.Toggle(myRect,false,charName,style);
				}
		}
	
		//draw player select icons
		GUI.DrawTexture(new Rect(
									selection_offX * aspectW + p1Loc.x * rectWidth + paddingY * aspectW * p1Loc.x,
									selection_offY * aspectH + p1Loc.y * rectHeight +  paddingX * aspectH * p1Loc.y,
									rectWidth,
									rectHeight),p1SelectTexture,ScaleMode.StretchToFill,true,0);
		GUI.DrawTexture(new Rect(
									selection_offX * aspectW + p2Loc.x * rectWidth + paddingY * aspectW * p2Loc.x,
									selection_offY * aspectH + p2Loc.y * rectHeight + paddingX * aspectH * p2Loc.y,
									rectWidth,
									rectHeight),p2SelectTexture,ScaleMode.StretchToFill,true,0);
		
		return 0;
		
	}
	void LoadGame(int selection)
	{
		switch (selection) {
		case 1:
			Application.LoadLevel("1P_CharSelect");
			break;
		case 2:
			Application.LoadLevel("2P_CharSelect");
			break;
		case 3:
			Application.LoadLevel("Options");
			break;
		case 4:
			Application.LoadLevel("Extras");
			break;
		default:
		break;
		}
		
	}
	
	
	
	bool DrawPortraits(float aspectH, float aspectW, int offX,int offY,GUIStyle style,bool toggleVal=false)
	{
		const int imageW = 313;
		const int imageH = 81;
		const int fontSize = 28;
		
		float rectWidth 			= (imageW*aspectW);
		float rectHeight 			= (imageH*aspectH);
		style.fontSize = (int)(fontSize * aspectH);
		float alph = Mathf.PingPong(Time.time,2.0f);
		style.normal.textColor = new Color(style.normal.textColor.r,style.normal.textColor.g,style.normal.textColor.b,alph);
		Rect startButRect = new Rect(
							offX * aspectW,
							offY * aspectH,
							rectWidth,
							rectHeight);
		//GUI.DrawTexture(startButRect,texture,ScaleMode.StretchToFill,true,0);
		return GUI.Toggle(startButRect,toggleVal, "Press Start",style);
		
	}
	
	
	void DrawBlackOverlay(float aspectH, float aspect,Texture2D texture,float blackfadeTime)
	{
		GUI.color = new Color(0,0,0,Mathf.Lerp(1,0,Time.time * blackfadeTime));
		GUI.DrawTexture(
			new Rect(
				0,
				0,
				Screen.width,
				Screen.height),
			texture,ScaleMode.StretchToFill,true,0);
		GUI.color = new Color(0,0,0,1);
	}
	

	
	
	
	

	
}
