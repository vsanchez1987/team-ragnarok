using UnityEngine;
using System.Collections;
using FightGame;

public class UI_Script : MonoBehaviour
{	
	private bool created = false;
	GameObject player;
	float length_default, height_default;
	public float	length_p1health,
					length_p2health,
					max_p1hp,
					max_p2hp,
					cur_p1hp,
					cur_p2hp;
	public GUIStyle health_style;
	
	
	public float 	p1_CorX, p1_CorY,
					p2_CorX, p2_CorY;
	
	public float	p1_GUIstartX,
					p1_GUIstartY,
					p2_GUIstartX,
					p2_GUIstartY;
				
	
	void Start ()
	{
		p1_GUIstartX = 25f;
		p1_GUIstartY = 25f;
	
		//init both player hp
		//max_p1hp = GameManager.P1.max_hp;
		//max_p2hp = GameManager.P2.max_hp;
		//since p1 and p2 are not instantiate at the beginning
		//For testing purpose, we will hard code max hp here.
		max_p1hp = 100f;
		max_p2hp = 100f;
		//cur_p1hp = GameManager.P1.cur_hp;
		//cur_p2hp = GameManager.P2.cur_hp;
		
	}

	void Update ()
	{
		p2_GUIstartX = (Screen.width/2)*2 - (length_default + p1_GUIstartX);
		p2_GUIstartY = p1_GUIstartY;
		
		length_default = Screen.width/4;
		height_default = Mathf.Min(Screen.height/18,30f);
		
		
		//Debug.Log ("Screen width: "+ Screen.width);
		//Debug.Log ("Screen height: "+ Screen.height);
		
		if(GameManager.P1!=null && GameManager.P2!=null)
		{
			//update both player's hp during fighting time
			cur_p1hp = GameManager.P1.Fighter.cur_hp;
			cur_p2hp = GameManager.P2.Fighter.cur_hp;
			length_p1health=length_default*(cur_p1hp/max_p1hp);
			length_p2health=length_default*(cur_p2hp/max_p2hp);
		}
		
	}
	
    void OnGUI() {
		if (!created){
	        if (GUI.Button(new Rect(Screen.width/2, Screen.height/2, 50, 30), "Start")){
				GameManager.CreateFighter("Fighter_Heavy",1);
				GameManager.CreateFighter("Fighter_Heavy",2);
	            created = true;
			}
			/*
			if (GUI.Button(new Rect(Screen.width/3, Screen.height/2, 50, 30), "Heacy")){
				GameManager.CreateFighter("Fighter_Heacy");
	            created = true;a
			}
			*/
		}
		
		if(GameManager.P1!=null && GameManager.P2!=null)
		{
			GUI.Box(new Rect(p1_GUIstartX,p1_GUIstartY,length_p1health,height_default),"",health_style);
			GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY,length_p2health,height_default),"",health_style);
			
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
}