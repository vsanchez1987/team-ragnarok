using UnityEngine;
using System.Collections;
using FightGame;
public class hitBoxTest : MonoBehaviour {
	
	HitBox testHB;
	public string hbName = "HitBox";
	
	public float vx,vy,vz = 0;
	public float radius = 1;
	public bool collisionEnabled = false;
	public bool setLoc = false;
	public Vector3 locationToSet = Vector3.zero;
	// Use this for initialization
	void Start () {
		testHB = new HitBox(hbName);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v = new Vector3(vx,vy,vz);
		testHB.setCollisionEnable(collisionEnabled);
		testHB.setVelocity(v);
		testHB.setRadius(radius);
		testHB.UpdatePosition();
		
		if (testHB.getCollisionEnabled())
			Debug.Log(testHB.CheckCollision());
		
		if (setLoc)
			testHB.setLocation(locationToSet);
	}
	
}
