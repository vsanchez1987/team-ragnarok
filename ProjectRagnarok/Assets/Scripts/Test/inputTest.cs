using UnityEngine;
using System.Collections;
using FightGame;

public class inputTest : MonoBehaviour {

    public string printMsg = "";
    void OnGUI() {
		
		if(GameManager.P1!=null)
		{
			//pcontroller direction
			printMsg = "controller direction: " + GameManager.P1.controllerDirection +"\n" +
						"forward vector: " + GameManager.P1.ForwardVector +"\n ";
			
			//button press
			printMsg+="buttons pressed: " + "\n";
			if (GameManager.P1.attackPressed)
			{
				printMsg += "regular attack";
				if (GameManager.P1.canAttack())
				{
					//attack
					GameManager.P1.lastAttackTimer = 0;
					printMsg += "attacked"+"\n";
				}
			}
			if (GameManager.P1.uniquePressed)
			{
				if (GameManager.P1.canAttack())
				{
					GameManager.P1.lastAttackTimer = 0;
					printMsg += "attacked"+"\n";
				}
				printMsg += "unique attack";
			}
			if (GameManager.P1.specialPressed)
			{
				//GameManager.P1.canSpecial()
				if (GameManager.P1.canAttack())
				{
					//GameManager.P1.lastSpecialTimer = 0;
					GameManager.P1.lastAttackTimer = 0;
					printMsg += "special attacked"+"\n";
				}
				printMsg += "special attack";
			}
			if (GameManager.P1.blockPressed)
			{
				//GameManager.P1.canBlock()
				if (GameManager.P1.canAttack())
				{
					//GameManager.P1.lastBlockTimer = 0;
					printMsg += "blocked";
				}
				printMsg += "block";
			}
			printMsg+="\n";
			
			// timer display
			printMsg += "Time since last atk:";
			printMsg += (float)((int)(GameManager.P1.lastAttackTimer*100))/100.0f +"\n";
					//the casting is a manual way to make double precision decimal
			
			//can attack
			if (GameManager.P1.canAttack())
			{
				printMsg += "ready to attack"+"\n";
			}
			else
			{
				printMsg += "can't attack yet"+"\n";
			}
			
			//print msg in a text area
	        GUI.TextArea(new Rect(10, 10, 200, 100), printMsg, 200);
			
			//swap forward vector button
		  	if (GUI.Button(new Rect(10, 110, 150, 30), "Switch ForwardVector"))
			{
	            GameManager.P1.switchForwardVector();
			}
			
			
			
		}
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
