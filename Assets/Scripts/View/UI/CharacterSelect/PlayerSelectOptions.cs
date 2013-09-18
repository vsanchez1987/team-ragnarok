using UnityEngine;
using System.Collections;

public class PlayerSelectOptions : MonoBehaviour {
	
	public string p1Name;
	public string p2Name;
	public string levelSelect;
	
	void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
