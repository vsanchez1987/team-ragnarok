using UnityEngine;
using System.Collections;
using FightGame;

public class TitleScreen_UI : MonoBehaviour {
	
	public Texture2D GameTitle_Texture;
	public Texture2D StartBG_Texture;
	public Texture2D Black_Texture;
	public int title_offX = 310, title_offY =200;
	public int start_offX = 337 , start_offY =353;
	public GUIStyle menuItem_GUIstyle;
	public float blackfadeTime = 0.5f;
	enum titleState {START,MENU};
	titleState state;
	
	// Use this for initialization
	void Start ()
	{
		state = titleState.START;
		
	}
	
	// Update is called once per frame
	void Update () {
		float aspectW = Screen.width/1024.0f;
		float aspectH = Screen.height/768.0f;
		if (GameManager.IsPlayerKeyPressed(1, InputButton.Start) || GameManager.IsPlayerKeyPressed(2, InputButton.Start )){
			switch (state)
			{
				case titleState.START:
					LoadMenu();
					//DrawBlackOverlay( aspectH, aspectW, Black_Texture,blackfadeTime);
					break;
				default:
				break;
			}
		}
	}
	
	void OnGUI() 
	{
		float aspectW = Screen.width/1024.0f;
		float aspectH = Screen.height/768.0f;
		
		
		DrawTitle(aspectH,aspectW,GameTitle_Texture,title_offX,title_offY);
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
	
	void LoadMenu()
	{
		Debug.Log("Load Main Menu");
		state = titleState.MENU;
		Debug.Log(state);
	}
	
	//void drawMenu(int selectNum,
	
	void DrawTitle(float aspectH, float aspectW, Texture2D texture,int offX,int offY)
	{
		const int imageW = 620;
		const int imageH = 270;
		
		float rectWidth 			= (imageW*aspectW);
		float rectHeight 			= (imageH*aspectH);
		
		GUI.DrawTexture(
			new Rect(
				offX * aspectW,
				offY * aspectH,
				rectWidth,
				rectHeight),
			texture,ScaleMode.StretchToFill,true,0);
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
	
	bool DrawStart(float aspectH, float aspectW, int offX,int offY,GUIStyle style,bool toggleVal=false)
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
	
	
	int DrawMenu(float aspectH, float aspectW, int offX,int offY,GUIStyle style,bool toggleVal=false)
	{
		const int imageW = 313;
		const int imageH = 81;
		const int fontSize = 28;
		
		float rectWidth 			= (imageW*aspectW);
		float rectHeight 			= (imageH*aspectH);
		style.fontSize = (int)(fontSize * aspectH);
		float alph = 1.0f;
		style.normal.textColor = new Color(style.normal.textColor.r,style.normal.textColor.g,style.normal.textColor.b,alph);
		Rect startButRect = new Rect(
							offX * aspectW,
							offY * aspectH,
							rectWidth,
							rectHeight);
		//GUI.DrawTexture(startButRect,texture,ScaleMode.StretchToFill,true,0);
		
		bool selected = false;
		
		string[] options = {"1 Player","2 Player", "Options", "Extras"};
		
		for (int i=0;i<4;i++)
		{
			selected = selected | 	GUI.Toggle(new Rect(
							offX * aspectW,
							offY * aspectH + i * rectHeight,
							rectWidth,
							rectHeight)
						,toggleVal, options[i],style);
			if (selected) return i+1;
		}
	
		return 0;
		
	}
	

	
}
