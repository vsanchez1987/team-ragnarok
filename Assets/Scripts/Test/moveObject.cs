using UnityEngine;
using System.Collections;

public class moveObject : MonoBehaviour {
	public float x,y,z = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v = new Vector3(x,y,z);
		transform.Translate(v * Time.deltaTime);
	}
}
