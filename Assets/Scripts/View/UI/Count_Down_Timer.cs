using UnityEngine;
using System.Collections;
using FightGame;



public class Count_Down_Timer : MonoBehaviour {
	
	//public GUISkin myskin;
	//public int maxTime = 120;
	public int xTimeOffset = 50;
	public int yTimeOffset = 25;
	public float yposition = -271.7f;
	public float xposition = -13.19f;
	
	/* ---------------------------------*/
	// count down the time
	private float timeRemaining = 5.0f;
	public bool timeElapsed = false;
	//int timerFontSize= 14;
	
	void decreaseTimeRemaining()
	{
		timeRemaining --;
	}

	void OnGUI()
	{
		GUI.depth = 1;
		
//		iTween.ScaleTo(new Rect(Screen.width/2,Screen.height/2,20,10),Vector3(-1,1,0),2);

		GUIStyle fontSize = new GUIStyle();
		fontSize.fontSize = 80;
		
		GUIStyle textSize = new GUIStyle();
		textSize.fontSize = 50;
		
		
		GUI.Box(
			new Rect(
					Screen.width/2 + xposition,
					Screen.height/2 + yposition,
					xTimeOffset,
					yTimeOffset),
					timeRemaining.ToString(),fontSize);  // ,timeRemaining.ToString()	
		
		if (timeRemaining == 0) {
			
					CancelInvoke("decreaseTimeRemaining");
					Debug.Log("player with higher life WINS");
					
					GUI.Label(new Rect(Screen.width/4,Screen.height/2,5,5),"Player with more Health wins",textSize);			
			
		}
	}
	
	
	
	// Use this for initialization
	void Start () {
	
		InvokeRepeating("decreaseTimeRemaining",2,1.5f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
}
