using UnityEngine;
using System.Collections;

public class TW_UI : MonoBehaviour {

/*-----------------------------------------------------------------*/
	public Texture2D UI_base;
	public Texture2D UI_healthGreen;
	public Texture2D UI_healthGreenp2;
	public Texture2D UI_healthRed;
	public float life = 100;
	public float lifeP2 = 100;
	public float redBarMoveTime = 0.1f;
	public float redBarCurrentWidth,redBarCurrentWidthp2;
	public GUIStyle rightButtonStyle;
	float lifeMax = 100;
	
	//for testing
	public int x,y,w,h;
	
	void OnGUI()
	{	
		
		GUI.depth = 2;
		
		float texToScreenRatioH = (Screen.height/768.0f); // textures created for 768 height screen
		float texToScreenRatioW = (Screen.width/1024.0f); // textures created for 1024 width screen
		int textOffSetH =  (int)(256 * texToScreenRatioH) ; //compensate for 1024 texture when design was for 768
		
		
		
		//p1 dmg bar
		redBarCurrentWidth = Mathf.Lerp(redBarCurrentWidth,UI_healthGreen.width * texToScreenRatioW * life/lifeMax,redBarMoveTime);
		GUI.DrawTexture(
			new Rect(
				130*texToScreenRatioW,
				37*texToScreenRatioH,
				redBarCurrentWidth,
				UI_healthGreen.height * texToScreenRatioH),UI_healthRed,ScaleMode.StretchToFill,true,0);
		
		
		
		
		//p1 health bar
		GUI.DrawTexture(
			new Rect(
				130*texToScreenRatioW,
				37*texToScreenRatioH,
				UI_healthGreen.width * texToScreenRatioW * life/lifeMax,
				UI_healthGreen.height * texToScreenRatioH),UI_healthGreen,ScaleMode.StretchToFill,true,0);
		
		
/*---------------------------------------------------------------------------------------------------------------------*/
		
		
		float p2BarOffset = 573*texToScreenRatioW;
		float barWidth = 320*texToScreenRatioW;
		float initWidth = 512*texToScreenRatioW;
		Debug.Log(p2BarOffset + ((512-320) *texToScreenRatioW)*   redBarCurrentWidthp2/initWidth  );
		
		
		
		
		//p2 dmg bar
		redBarCurrentWidthp2 = Mathf.Lerp(redBarCurrentWidthp2,UI_healthGreenp2.width * texToScreenRatioW * lifeP2/lifeMax,redBarMoveTime);
		GUI.DrawTexture(
			new Rect(
				Screen.width - 130*texToScreenRatioW ,
				37*texToScreenRatioH,
				-redBarCurrentWidthp2,
				UI_healthGreen.height * texToScreenRatioH),UI_healthRed,ScaleMode.StretchToFill,true,0);
		
		
		
		
		//p2 health bar
		
		float bar = (p2BarOffset + barWidth + (lifeP2/lifeMax)*-barWidth);
		GUI.DrawTexture(
			new Rect(
				(p2BarOffset + barWidth + (lifeP2/lifeMax)*-barWidth),
				37*texToScreenRatioH,
				UI_healthGreenp2.width * texToScreenRatioW * lifeP2/lifeMax,
				UI_healthGreenp2.height * texToScreenRatioH),UI_healthGreenp2,ScaleMode.StretchToFill,true,0);
		
		
		
		
		//ui overlay
		GUI.DrawTexture(new Rect(0, 0, Screen.width , Screen.height + textOffSetH),UI_base,ScaleMode.StretchToFill,true,0);
		
	}
	
	
	
	
	
	// Use this for initialization
	void Start ()
	{
		//init dmg bar width
		redBarCurrentWidth = redBarCurrentWidthp2 = UI_healthGreen.width * Screen.width/1024.0f * life/lifeMax;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
