using UnityEngine;
using System.Collections;
using FightGame;


public class UI_Script : MonoBehaviour
{	
<<<<<<< HEAD
	const int healthBarXoffSet = 113;
	public int healthBarYoffSet = 40;
	
	const int INIT_X = 1024;
	const int INIT_Y = 768;
	
	const int HEALTH_BAR_HEIGHT = 30;

	public Texture2D healthBar;
	public Texture2D backgourndTexture;
	public Texture2D mainBorderTexture;



	private bool created = false;
=======

	private bool created , p1Pick = false;
	private bool p2Pick = false;
>>>>>>> fd2511965e41334cb3fce993bcedcd531205f267
	GameObject player;
	float length_default, height_default;
	float	length_p1health,
					length_p2health,
					length_p1meter,
					length_p2meter,
					max_p1meter,
					max_p2meter,
					max_p1hp,
					max_p2hp,
					cur_p1hp,
					cur_p2hp,
					cur_p1meter,
					cur_p2meter;
	public GUIStyle health_style, meter_style;
<<<<<<< HEAD
=======
	public Texture2D controls;
	
	//float 	p1_CorX, p1_CorY,
	//				p2_CorX, p2_CorY,
	//				meterPosY;
	
	//private float	p1_GUIstartX,
	//				p1_GUIstartY,
	//				p2_GUIstartX,
	//				p2_GUIstartY;
	
	[HideInInspector]
	public bool	hitboxOn, hurtboxOn, controlsOn = false;
>>>>>>> fd2511965e41334cb3fce993bcedcd531205f267
	
	//tom for gui
	
<<<<<<< HEAD
	float 	p1_CorX, p1_CorY,
					p2_CorX, p2_CorY,
					meterPosY;
	
	float	p1_GUIstartX,
					p1_GUIstartY,
					p2_GUIstartX,
					p2_GUIstartY;
				
	
=======
	float aspectW = Screen.width/1024.0f;
	float aspectH = Screen.height/768.0f;
	
	public Texture2D UI_base;
	public Texture2D UI_healthGreen;
	public Texture2D UI_healthGreenp2;
	public Texture2D UI_healthRed;
	public Texture2D UI_staminaBlue;
	public Texture2D P1_portrait, P2_portrait;
	
	public float dmgRedBarSpeed = 0.005f;
	float dmgBarHealth_P1,dmgBarHealth_P2;
	
	// end tom
	
>>>>>>> fd2511965e41334cb3fce993bcedcd531205f267
	void Start()
	{
		//GameManager.CreateFighter("Fighter_Heavy",1);
		//GameManager.CreateFighter("Fighter_Heavy",2);
		//GameManager.CreateFighter("Fighter_Amaterasu",1);
		//GameManager.CreateFighter("Fighter_Amaterasu",2);
		//p1_GUIstartX = 25f;
		//p1_GUIstartY = 25f;
		
		
		aspectW = Screen.width/1024.0f;
		aspectH = Screen.height/768.0f;
		
		dmgBarHealth_P1 = dmgBarHealth_P2 = 100.0f;
	
		//init both player hp
		//max_p1hp = GameManager.P1.max_hp;
		//max_p2hp = GameManager.P2.max_hp;
		//since p1 and p2 are not instantiate at the beginning
		//For testing purpose, we will hard code max hp here.
		
<<<<<<< HEAD
		max_p1hp = 100f;
		max_p2hp = 100f;
		max_p1meter = 100f;
		max_p2meter = 100f;
=======
		//max_p1hp = GameManager.P1.Fighter.max_hp;
		//max_p2hp = GameManager.P2.Fighter.max_hp;
		//max_p1meter = GameManager.P1.Fighter.max_meter;
		//max_p2meter = GameManager.P2.Fighter.max_meter;
>>>>>>> fd2511965e41334cb3fce993bcedcd531205f267
		
		//cur_p1hp = GameManager.P1.cur_hp;
		//cur_p2hp = GameManager.P2.cur_hp;
		//tom
		
		//end tom
	}

	void Update ()
	{
<<<<<<< HEAD
		//max_p1hp = max_p2hp = max_p1meter = max_p2meter =100f;
		length_default = Screen.width/4;
		p2_GUIstartX = Screen.width - (length_default + p1_GUIstartX);
		p2_GUIstartY = p1_GUIstartY;
		meterPosY = Screen.height*5/6;
		
		
=======

		
		length_default = Screen.width/4;
		//p2_GUIstartX = Screen.width - (length_default + p1_GUIstartX);
		//p2_GUIstartY = p1_GUIstartY;
		//meterPosY = Screen.height*5/6;
		
		//redBarCurrentWidth = redBarCurrentWidthp2 = UI_healthGreen.width * Screen.width/1024.0f * max_p1hp/max_p1hp;
		
>>>>>>> fd2511965e41334cb3fce993bcedcd531205f267
		height_default = Mathf.Min(Screen.height/18,30f);
		
		
		//Debug.Log ("Screen width: "+ Screen.width);
		//Debug.Log ("Screen height: "+ Screen.height);
		
		if(GameManager.P1.Fighter != null && GameManager.P2.Fighter != null)
		{
			if(P1_portrait==null)
			{
				P1_portrait =  Resources.Load("Portraits/"+GameManager.P1.Fighter.name) as Texture2D;
				if (P1_portrait==null) Debug.Log("can't find Resources/"+"Portraits/"+GameManager.P1.Fighter.name);
			}
			if(P2_portrait==null)
			{
				Debug.Log("Portraits/"+GameManager.P2.Fighter.name);
				P2_portrait =  Resources.Load("Portraits/"+GameManager.P2.Fighter.name) as Texture2D;
				if (P2_portrait==null) Debug.Log("can't find Resources/"+"Portraits/"+GameManager.P2.Fighter.name);
			}
			
			max_p1hp = GameManager.P1.Fighter.max_hp;
			max_p2hp = GameManager.P2.Fighter.max_hp;
			
			max_p1meter = GameManager.P1.Fighter.max_meter;
			max_p2meter = GameManager.P2.Fighter.max_meter;
			
			//update both player's hp during fighting time
<<<<<<< HEAD
			cur_p1hp = GameManager.P1.cur_hp;
			cur_p2hp = GameManager.P2.cur_hp;
			
			cur_p1meter = GameManager.P1.cur_meter;
			cur_p2meter = GameManager.P2.cur_meter;
=======
			cur_p1hp = GameManager.P1.Fighter.cur_hp;
			cur_p2hp = GameManager.P2.Fighter.cur_hp;
			
			cur_p1meter = GameManager.P1.Fighter.cur_meter;
			cur_p2meter = GameManager.P2.Fighter.cur_meter;
>>>>>>> fd2511965e41334cb3fce993bcedcd531205f267
			
			length_p1meter = length_default*(cur_p1meter/max_p1meter);
			length_p2meter = length_default*(cur_p2meter/max_p2meter);
			
<<<<<<< HEAD
			length_p1health=length_default*(cur_p1hp/max_p1hp);
			length_p2health=length_default*(cur_p2hp/max_p2hp);
=======
			length_p1health = length_default*(cur_p1hp/max_p1hp);
			length_p2health = length_default*(cur_p2hp/max_p2hp);
		}
	}
	
	/*
	 * 
	Stamina (int playerNumber, float stamina, float 
	maxStamina, float aspect)
	Rounds MaxBoxes (int playernumber, int 
	maxRounds,float aspect)
	Rounds WonBoxes (int playerNumber, int 
	roundsWon,float aspect)
	Portraits (a_fighter currentPlayer,float aspect)
	CharacterName (a_fighter currentPlayer)
	 */
	
	//****************************************
	// TOM GUI FUNCTIONS BEGIN
	
	void drawStaminaBar(int playerNum, float stam, float maxStam, float aspectW, float aspectH, Texture2D texture)
	{
		if (playerNum == 1)
		{
			const int P1_STAM_OFFSET_X 	= 130;
			const int P1_STAM_OFFSET_Y 	= 75;
			float stamBarWidth 			= (texture.width*aspectW) * (stam/maxStam);
			float stamBarHeight 		= (texture.height*aspectH);
			
			GUI.DrawTexture(
				new Rect(
					P1_STAM_OFFSET_X*aspectW,
					P1_STAM_OFFSET_Y*aspectH,
					stamBarWidth,
					stamBarHeight),
				texture,ScaleMode.StretchToFill,true,0);
		}
		if (playerNum == 2)
		{
			const int P1_STAM_OFFSET_X 	= 897;
			const int P1_STAM_OFFSET_Y 	= 75;
			float stamBarWidth 			= (texture.width*aspectW) * (stam/maxStam)*-1;
			float stamBarHeight 		= (texture.height*aspectH);
			
			GUI.DrawTexture(
				new Rect(
					P1_STAM_OFFSET_X*aspectW,
					P1_STAM_OFFSET_Y*aspectH,
					stamBarWidth,
					stamBarHeight),
				texture,ScaleMode.StretchToFill,true,0);
>>>>>>> fd2511965e41334cb3fce993bcedcd531205f267
		}
	}
	
	void drawHealthBar(int playerNum, float health, float maxHealth, float aspectW, float aspectH, Texture2D texture)
	{
		if (playerNum == 1)
		{
			const int P1_HEALTHBAR_OFFSET_X = 130;
			const int P1_HEALTHBAR_OFFSET_Y = 37;
			float healthBarWidth 			= (texture.width*aspectW) * (health/maxHealth);
			float healthBarHeight 			= (texture.height*aspectH);
			
			GUI.DrawTexture(
				new Rect(
					P1_HEALTHBAR_OFFSET_X*aspectW,
					P1_HEALTHBAR_OFFSET_Y*aspectH,
					healthBarWidth,
					healthBarHeight),
				texture,ScaleMode.StretchToFill,true,0);
		}
		
		if (playerNum == 2)
		{
<<<<<<< HEAD
			// this is the rectangle
			Rect myrect = new Rect(0,0, Screen.width, Screen.height);
			// this is the box
			GUI.Box(myrect,mainBorderTexture);
			
			//draw empty bars
			GUI.Box(new Rect(p1_GUIstartX,p1_GUIstartY,length_default,height_default),"");
			GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY,length_default,height_default),"");
			GUI.Box(new Rect(p1_GUIstartX,p1_GUIstartY+meterPosY,length_default,height_default),"");
			GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY+meterPosY,length_default,height_default),"");
			
			//draw health bars and meter bars over
			int healthBarX =  (int)( ((float)Screen.width/(float)INIT_X) * (float)healthBarXoffSet);
			int healthBarY = (int)(((float)Screen.height/(float)INIT_Y) * (float)healthBarYoffSet);
			int healthBarHeight = (int)(((float)Screen.height/(float)INIT_Y) * HEALTH_BAR_HEIGHT);
			Debug.Log(healthBarX );
			GUI.Box(new Rect(healthBarX,healthBarY,healthBar.width,healthBar.height),healthBar);
			GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY,length_p2health,height_default),"",health_style);
			GUI.Box(new Rect(p1_GUIstartX,p1_GUIstartY+meterPosY,length_p1meter,height_default),"",meter_style);
			GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY+meterPosY,length_p2meter,height_default),"",meter_style);
			
			
		
=======
			const int P2_HEALTHBAR_OFFSET_X = 573;
			const int P2_HEALTHBAR_OFFSET_Y = 37;
			const int P2_HEALTHBAR_INITSIZE = 320;
			float healthBarWidth 			= (texture.width*aspectW) * (health/maxHealth);
			float healthBarHeight 			= (texture.height*aspectH);
>>>>>>> fd2511965e41334cb3fce993bcedcd531205f267
			
			GUI.DrawTexture(
				new Rect(
					(P2_HEALTHBAR_OFFSET_X+P2_HEALTHBAR_INITSIZE) *aspectW ,
					P2_HEALTHBAR_OFFSET_Y*aspectH,
					-healthBarWidth,
					healthBarHeight),
				texture,ScaleMode.StretchToFill,true,0);
		}
		
	}
	
	float drawDmgBar(int playerNum, float currentDmgBarVal, float lerpValue, float health, float maxHealth, float aspectW, float aspectH, Texture2D texture)
	{
		float newDmgBarVal = Mathf.Lerp(currentDmgBarVal,health,lerpValue);
		drawHealthBar(playerNum,newDmgBarVal,maxHealth,aspectW,aspectH,texture);
		return newDmgBarVal;
	}
	
	void drawUIOverlay(float aspectH,Texture2D texture)
	{
		GUI.DrawTexture(new Rect(0, 0, Screen.width , aspectH * texture.height),texture,ScaleMode.StretchToFill,true,0);
	}
	
	void drawPortrait(int playerNum, float aspectH, float aspectW, Texture2D texture)
	{
		if (playerNum==1)
		{
			const int P1_PORTRAIT_OFFSET_X = 44;
			const int P1_PORTRAIT_OFFSET_Y = 26;
			float portraitWidth 			= (85*aspectW);
			float portraitHeight 			= (103*aspectH);
			
			GUI.DrawTexture(
				new Rect(
					(P1_PORTRAIT_OFFSET_X) *aspectW ,
					P1_PORTRAIT_OFFSET_Y*aspectH,
					portraitWidth,
					portraitHeight),
				texture,ScaleMode.StretchToFill,true,0);
			
		}
		
		if (playerNum==2)
		{
			const int P1_PORTRAIT_OFFSET_X = 900;
			const int P1_PORTRAIT_OFFSET_Y = 30;
			float portraitWidth 			= (85*aspectW);
			float portraitHeight 			= (103*aspectH);
			
			GUI.DrawTexture(
				new Rect(
					(P1_PORTRAIT_OFFSET_X) *aspectW ,
					P1_PORTRAIT_OFFSET_Y*aspectH,
					portraitWidth,
					portraitHeight),
				texture,ScaleMode.StretchToFill,true,0);
			
		}
		
	}
	
	//****************************************	
	// TOM GUI FUNCTIONS END
	
	
    void OnGUI() {
		
		

		
		//Hieu add
		PickFighter();
		
		if(GameManager.P1.Fighter != null && GameManager.P2.Fighter != null)
		{
			
			//THOMAS NEW GUI - sept 2013
		
			float aspectW = Screen.width/1024.0f;
			float aspectH = Screen.height/768.0f;
			
			dmgBarHealth_P1 = drawDmgBar(1,dmgBarHealth_P1,dmgRedBarSpeed,cur_p1hp,max_p1hp,aspectW,aspectH,UI_healthRed);
			dmgBarHealth_P2 = drawDmgBar(2,dmgBarHealth_P2,dmgRedBarSpeed,cur_p2hp,max_p2hp,aspectW,aspectH,UI_healthRed);
			drawHealthBar(1,cur_p1hp,max_p1hp,aspectW,aspectH,UI_healthGreen);
			drawHealthBar(2,cur_p2hp,max_p2hp,aspectW,aspectH,UI_healthGreen);
			drawStaminaBar(1,cur_p1meter,max_p1meter,aspectW,aspectH,UI_staminaBlue);
			drawStaminaBar(2,cur_p2meter,max_p2meter,aspectW,aspectH,UI_staminaBlue);
			
			drawPortrait(1,aspectH,aspectW,P1_portrait);
			drawPortrait(2,aspectH,aspectW,P2_portrait);
			
			drawUIOverlay(aspectH,UI_base);
		
			//end THOMAS NEW GUI
			
			
			
			if (GameManager.P1.Fighter.cur_hp <= 0 || GameManager.P2.Fighter.cur_hp <= 0){
				if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 50, 200, 100), "Restart")){
					GameManager.Restart();
					created = false;
					p1Pick = false;
					p2Pick = false;
				}
			}
			
			this.hitboxOn = GUI.Toggle(new Rect(Screen.width * 0.05f, Screen.height * 0.25f, 130, 20), hitboxOn, "Show HitBoxes");
			this.hurtboxOn = GUI.Toggle(new Rect(Screen.width * 0.05f, Screen.height * 0.25f + 20, 130, 20), hurtboxOn, "Show HurtBoxes");
			this.controlsOn = GUI.Toggle(new Rect(Screen.width * 0.05f, Screen.height * 0.25f + 40, 130, 20), controlsOn, "Show Controls");
			

			
			
			//draw empty bars
			//GUI.Box(new Rect(p1_GUIstartX,p1_GUIstartY,length_default,height_default),"");
			//GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY,length_default,height_default),"");
			
			//GUI.Box(new Rect(p1_GUIstartX,p1_GUIstartY+meterPosY,length_default,height_default),"");
			//GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY+meterPosY,length_default,height_default),"");
			
			//draw health bars and meter bars over
			//GUI.Box(new Rect(p1_GUIstartX,p1_GUIstartY,length_p1health,height_default),"",health_style);
			//GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY,length_p2health,height_default),"",health_style);
			
			//GUI.Box(new Rect(p1_GUIstartX,p1_GUIstartY+meterPosY,length_p1meter,height_default),"",meter_style);
			//GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY+meterPosY,length_p2meter,height_default),"",meter_style);

			
			
			if (this.controlsOn){
				GUI.DrawTexture( new Rect( 0, 0, Screen.width, Screen.height ), this.controls, ScaleMode.ScaleToFit, true, 0 );
			}
		}
		/*
		else{
			if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2, 100, 30), "Idle")){
				//GameManager.P1.Dispatch("idle");
			}
			if (GUI.Button(new Rect(Screen.width/2 + 100, Screen.height/2, 100, 30), "Walk Forward")){
				//GameManager.P1.Dispatch("walkForward");
			}
		}
		*/
    }
	
	//Hieu add
	void PickFighter()
	{
		if (!created){
			if(!p1Pick){
				GUI.Box(new Rect(Screen.width/2,Screen.height*1/4,100,30),"Player 1 turn");
				//add more fighter selection for P1 here
				P1_Pick("Heavy",Screen.width/4,Screen.height/2);
		        P1_Pick("Amaterasu",Screen.width*3/4, Screen.height/2);
			}
			if(p2Pick){
				GUI.Box(new Rect(Screen.width/2,Screen.height*1/4,100,30),"Player 2 turn");
				//add more fighter selection for P2 here
			  	P2_Pick("Heavy",Screen.width/4,Screen.height/2);
		        P2_Pick("Amaterasu",Screen.width*3/4, Screen.height/2);
			}
		}
	}
	
	void P1_Pick(string fighterName, float positionX, float positionY, float width=100, float height=30)
	{
		if (GUI.Button(new Rect(positionX, positionY, width, height), fighterName)){
			GameManager.CreateFighter("Fighter_"+fighterName,1);
			p1Pick = true;
			p2Pick = true;
		}
	}
	
	void P2_Pick(string fighterName, float positionX, float positionY, float width=100, float height=30)
	{
		if (GUI.Button(new Rect(positionX, positionY, width, height), fighterName)){
			GameManager.CreateFighter("Fighter_"+fighterName,2);
			p2Pick = true;
			created = true;
		}
	}
}