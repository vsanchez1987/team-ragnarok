using UnityEngine;
using System.Collections;
using FightGame;
public class hitBoxTest_PlayerAttackList_HBM : MonoBehaviour {

	HitBox testHB,testHB2,testHB3;
	public string loadedHitBox = "";
	public bool showBoxes = true;
	public bool alwaysShowHitBoxes = false;
	
	void Start () {	}
	
	void loadHitBox()
	{
		if(GameManager.P1!=null)
		{
			testHB = GameManager.P1.GetHitBox(A_Fighter.HB_FIST_L);
			testHB2 = GameManager.P1.GetHitBox(A_Fighter.HB_FIST_R);
			testHB3 = GameManager.P1.GetHitBox(A_Fighter.HB_GLOBAL01);
		}
	}
	
	void sendHBM()
	{
		if(testHB!=null)
		{
			//this should be in "attack(A_attack)" For "A_Fighter"
			//foreach(hbm in attack instructions) send message to appropriate hitbox
			
			HitBoxInstruction testMsg = GameManager.P1.attacklist["test"].attackInstructions[0];	
        	testHB.sendInstruction(testMsg);
			
			HitBoxInstruction testMsg2 = GameManager.P1.attacklist["test"].attackInstructions[1];
        	testHB2.sendInstruction(testMsg2);
			
			HitBoxInstruction testMsg3 = GameManager.P1.attacklist["test"].attackInstructions[2];
        	testHB3.sendInstruction(testMsg3);
		}
	}
	
    void OnGUI()
	{
    	if (GUI.Button(new Rect(10, 70, 200, 50), "LoadHitBox"))
		{
        	loadHitBox();
		}
    	if (GUI.Button(new Rect(10, 150, 200, 50), "SendHBMessage"))
		{
			sendHBM();
		}
		
    	if (GUI.Button(new Rect(10, 250, 200, 50), "CreateFighter"))
		{
			GameManager.CreateFighter("Fighter_Basic");
		}
	}
	
	
	void Update () {
		
		if (GameManager.P1!=null)
		{
			
			GameManager.P1.ShowHitBoxes(showBoxes);
			GameManager.P1.ShowHitBoxesAlwaysOn(alwaysShowHitBoxes);
			GameManager.P1.UpdateHitBoxes();
			
		}
		
		if (testHB!=null)
		{
			
			loadedHitBox = testHB.GOB.name;
		}
		
	}
}