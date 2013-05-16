using UnityEngine;
using System.Collections;
using FightGame;
public class hitBoxTest_player : MonoBehaviour {

	HitBox testHB;
	public string hitBoxToLoad = "";
	public string loadedHitBox = "";
	public float vx,vy,vz = 0;
	public float radius = 1;
	public bool collisionEnabled = false;
	public bool setLoc = false;
	public bool showBoxes = true;
	public Vector3 locationToSet = Vector3.zero;
	
	void Start () {
	
	}
	
	void loadHitBox(string hbName)
	{
		if(GameManager.P1!=null)
		{
			if(GameManager.P1.hitBoxes!=null)
			{
				testHB=GameManager.P1.getHitBox(hbName);
			}
		}
	}
	
    void OnGUI()
	{
    	if (GUI.Button(new Rect(10, 70, 200, 50), "LoadHitBox"))
		{
        	loadHitBox(hitBoxToLoad);
		}
	}
	
	
	void Update () {
		
		if (GameManager.P1!=null)
		{
			GameManager.P1.ShowHitBoxes(showBoxes);
		}
		
		if (testHB!=null)
		{
			loadedHitBox = testHB.GOB.name;
			Vector3 v = new Vector3(vx,vy,vz);
			testHB.setCollisionEnable(collisionEnabled);
			testHB.setVelocity(v);
			testHB.setRadius(radius);
			testHB.updatePosition();
			
			
			if (testHB.getCollisionEnabled())
				Debug.Log(testHB.checkCollision());
			
			if (setLoc)
				testHB.setLocation(locationToSet);
		}
		
	}
}
