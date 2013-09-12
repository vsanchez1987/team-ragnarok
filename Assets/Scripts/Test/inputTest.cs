using UnityEngine;
using System.Collections;
using FightGame;

public class inputTest : MonoBehaviour {
	/*
	public Vector2 locationP1;
	public Vector2 locationP2;
    public string printMsg = "";
	public Vector2 location;
	

    void OnGUI()
	{
		DisplayP1Info();
		DisplayP2Info();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
	
	void DisplayP2Info()
	{
		if(GameManager.P2!=null)
		{
			//pcontroller direction
			printMsg = "controller direction: " + GameManager.P2.Fighter.controllerDirection +"\n" +
						"forward vector: " + GameManager.P2.Fighter.GlobalForwardVector +"\n ";
			
			//button press
			printMsg+="buttons pressed: " + "\n";
			if (GameManager.P2.Fighter.attackPressed)
			{
				printMsg += "regular attack";
				if (GameManager.P2.Fighter.CanAttack())
				{
					//attack
					GameManager.P2.Fighter.lastAttackTimer = 0;
					printMsg += "attacked"+"\n";
				}
			}
			if (GameManager.P2.Fighter.uniquePressed)
			{
				if (GameManager.P2.Fighter.CanAttack())
				{
					GameManager.P2.Fighter.lastAttackTimer = 0;
					printMsg += "attacked"+"\n";
				}
				printMsg += "unique attack";
			}
			if (GameManager.P2.Fighter.specialPressed)
			{
				//GameManager.p1.Fighter.canSpecial()
				if (GameManager.P2.Fighter.CanAttack())
				{
					//GameManager.p1.Fighter.lastSpecialTimer = 0;
					GameManager.P2.Fighter.lastAttackTimer = 0;
					printMsg += "special attacked"+"\n";
				}
				printMsg += "special attack";
			}
			if (GameManager.P2.Fighter.blockPressed)
			{
				//GameManager.p1.Fighter.canBlock()
				if (GameManager.P2.Fighter.CanAttack())
				{
					//GameManager.p1.Fighter.lastBlockTimer = 0;
					printMsg += "blocked";
				}
				printMsg += "block";
			}
			printMsg+="\n";
			
			// timer display
			printMsg += "Time since last atk:";
			printMsg += (float)((int)(GameManager.P2.Fighter.lastAttackTimer*100))/100.0f +"\n";
					//the casting is a manual way to make double precision decimal
			
			//can attack
			if (GameManager.P2.Fighter.CanAttack())
			{
				printMsg += "ready to attack"+"\n";
			}
			else
			{
				printMsg += "can't attack yet"+"\n";
			}
			
			//print msg in a text area
	        GUI.TextArea(new Rect(location.x, location.y, 200, 100), printMsg, 200);
			
			//swap forward vector button
		  	if (GUI.Button(new Rect(location.x, location.y+110, 150, 30), "Switch GlobalForwardVector"))
	        GUI.TextArea(new Rect(locationP2.x, locationP1.y, 200, 100), printMsg, 200);
			
			//swap forward vector button
		  	if (GUI.Button(new Rect(10, locationP2.y+110, 150, 30), "Switch GlobalForwardVector"))
			{
	            GameManager.P2.Fighter.SwitchForwardVector();
			}
			
			
			
		}
	}
	
	void DisplayP1Info()
	{
		if(GameManager.P1!=null)
		{
			//pcontroller direction
			printMsg = "controller direction: " + GameManager.P1.Fighter.controllerDirection +"\n" +
						"forward vector: " + GameManager.P1.Fighter.GlobalForwardVector +"\n ";
			
			//button press
			printMsg+="buttons pressed: " + "\n";
			if (GameManager.P1.Fighter.attackPressed)
			{
				printMsg += "regular attack";
				if (GameManager.P1.Fighter.CanAttack())
				{
					//attack
					GameManager.P1.Fighter.lastAttackTimer = 0;
					printMsg += "attacked"+"\n";
				}
			}
			if (GameManager.P1.Fighter.uniquePressed)
			{
				if (GameManager.P1.Fighter.CanAttack())
				{
					GameManager.P1.Fighter.lastAttackTimer = 0;
					printMsg += "attacked"+"\n";
				}
				printMsg += "unique attack";
			}
			if (GameManager.P1.Fighter.specialPressed)
			{
				//GameManager.P1.Fighter.canSpecial()
				if (GameManager.P1.Fighter.CanAttack())
				{
					//GameManager.P1.Fighter.lastSpecialTimer = 0;
					GameManager.P1.Fighter.lastAttackTimer = 0;
					printMsg += "special attacked"+"\n";
				}
				printMsg += "special attack";
			}
			if (GameManager.P1.Fighter.blockPressed)
			{
				//GameManager.P1.Fighter.canBlock()
				if (GameManager.P1.Fighter.CanAttack())
				{
					//GameManager.P1.Fighter.lastBlockTimer = 0;
					printMsg += "blocked";
				}
				printMsg += "block";
			}
			printMsg+="\n";
			
			// timer display
			printMsg += "Time since last atk:";
			printMsg += (float)((int)(GameManager.P1.Fighter.lastAttackTimer*100))/100.0f +"\n";
					//the casting is a manual way to make double precision decimal
			
			//can attack
			if (GameManager.P1.Fighter.CanAttack())
			{
				printMsg += "ready to attack"+"\n";
			}
			else
			{
				printMsg += "can't attack yet"+"\n";
			}
			
			//print msg in a text area
	        GUI.TextArea(new Rect(location.x, location.y, 200, 100), printMsg, 200);
			
			//swap forward vector button
		  	if (GUI.Button(new Rect(location.x, location.y+110, 150, 30), "Switch GlobalForwardVector"))
	        GUI.TextArea(new Rect(locationP1.x, locationP1.y, 200, 100), printMsg, 200);
			
			//swap forward vector button
		  	if (GUI.Button(new Rect(locationP1.x, locationP1.y+110, 150, 30), "Switch GlobalForwardVector"))
			{
	            GameManager.P1.Fighter.SwitchForwardVector();
			}
		}
	}
	*/
}