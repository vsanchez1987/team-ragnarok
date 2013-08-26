using UnityEngine;
using System.Collections;
using FightGame;

public class UI_Script : MonoBehaviour
{	
	private bool created = false;
	private float length_default, height_default;
	
	public float	length_p1health,
					length_p2health;
	
	public GUIStyle health_style;

	public float 	p1_CorX, p1_CorY,
					p2_CorX, p2_CorY;
	
	public float	p1_GUIstartX,
					p1_GUIstartY,
					p2_GUIstartX,
					p2_GUIstartY;
	
	public bool 	hitboxOn, hurtboxOn;
	
	void Start ()
	{
		p1_GUIstartX = 25f;
		p1_GUIstartY = 25f;
		hitboxOn = false;
		hurtboxOn = false;
	
		//init both player hp
		//max_p1hp = GameManager.P1.max_hp;
		//max_p2hp = GameManager.P2.max_hp;
		//since p1 and p2 are not instantiate at the beginning
		//For testing purpose, we will hard code max hp here.
	}

	void Update ()
	{
		p2_GUIstartX = (Screen.width/2)*2 - (length_default + p1_GUIstartX);
		p2_GUIstartY = p1_GUIstartY;
		
		length_default = Screen.width/4;
		height_default = Mathf.Min(Screen.height/18,30f);
		
		
		//Debug.Log ("Screen width: "+ Screen.width);
		//Debug.Log ("Screen height: "+ Screen.height);
		
		if(GameManager.P1.Fighter != null && GameManager.P2.Fighter != null)
		{
			//update both player's hp during fighting time
			float cur_p1hp = GameManager.P1.Fighter.cur_hp;
			float cur_p2hp = GameManager.P2.Fighter.cur_hp;
			float max_p1hp = GameManager.P1.Fighter.max_hp;
			float max_p2hp = GameManager.P2.Fighter.max_hp;
			
			this.length_p1health=length_default*(cur_p1hp/max_p1hp);
			this.length_p2health=length_default*(cur_p2hp/max_p2hp);
		}
		
	}
	
    void OnGUI() {
		if (!created){
	        if (GUI.Button(new Rect(Screen.width/2, Screen.height/2, 50, 30), "Start")){
				GameManager.CreateFighter("Fighter_Heavy",1);
				GameManager.CreateFighter("Fighter_Heavy",2);
	            created = true;
			}
		}
		
		if(GameManager.P1.Fighter != null && GameManager.P2.Fighter != null)
		{
			GUI.Box(new Rect(p1_GUIstartX,p1_GUIstartY,length_p1health,height_default),"",health_style);
			GUI.Box(new Rect(p2_GUIstartX,p2_GUIstartY,length_p2health,height_default),"",health_style);
			
			this.hitboxOn = GUI.Toggle(new Rect(20, 60, 130, 20), hitboxOn, "Show HitBoxes");
			this.hurtboxOn = GUI.Toggle(new Rect(20, 80, 130, 20), hurtboxOn, "Show HurtBoxes");
		}
    }
}