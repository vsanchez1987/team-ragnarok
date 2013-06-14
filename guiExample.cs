using UnityEngine;
using System.Collections;

public class guiExample : MonoBehaviour {
	
	public string PlayerName;
	public string PlayerType;
	public string PlayerOrigin;
	public string stringToEdit;
	
	
	// Use this for initialization
	void Awake() {
		
		// These call the saved data from a local text file
		
		PlayerName = PlayerPrefs.GetString("PLAYERNAME");
		PlayerType = PlayerPrefs.GetString("PLAYERTYPE");
		PlayerOrigin = PlayerPrefs.GetString("PLAYERORIGIN");
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(PlayerName != null)
		{
			//PlayerPrefs.SetString("PLAYERNAME", PlayerName);
			Debug.Log("Player NAME has value");
		}
		
		if(PlayerType != null)
		{
			//PlayerPrefs.SetString("PLAYERTYPE", PlayerType);
			Debug.Log("Player TYPE has value");
		}
		
		if(PlayerOrigin != null)
		{
			//PlayerPrefs.SetString("PLAYERORIGIN", PlayerOrigin);
			Debug.Log("Player ORIGIN has value");
		}
	
	}
	
	void OnGUI()
	{
		// This is the players name
		GUI.Label(new Rect (0,0,100,100),"Player: ");
		GUI.Label(new Rect (45,0, 100,100),PlayerName);
		// Players type
		GUI.Label(new Rect (0,20,100,100),"Player: ");
		GUI.Label(new Rect (45,20, 100,100),PlayerType);
		// Players Origin
		GUI.Label(new Rect (0,40,100,100),"Player: ");
		GUI.Label(new Rect (45,40, 100,100),PlayerOrigin);
		
		PlayerName = GUI.TextField(new Rect(50, 50, 200, 20), PlayerName, 25);
		
		PlayerType = GUI.TextField(new Rect(50, 80, 200, 20), PlayerType, 25);
		
		PlayerOrigin = GUI.TextField(new Rect(50, 110, 200, 20), PlayerOrigin, 25);
		
		
		if(GUI.Button(new Rect(100,100, 100, 100), "button 2"))
		{
			Debug.Log("All Values have been saved");
			
			PlayerPrefs.SetString("PLAYERNAME", PlayerName);
			PlayerPrefs.SetString("PLAYERTYPE", PlayerType);
			PlayerPrefs.SetString("PLAYERORIGIN", PlayerOrigin);
			
			GUI.Label(new Rect (45,0, 100,100),PlayerName);	
		}
			
	}
}
