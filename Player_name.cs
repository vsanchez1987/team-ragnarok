using UnityEngine;
using System.Collections;

/*public class Name:MonoBehaviour
{
	string first;
	string last;
	
	public Name (string First, string Last)	
	{
		First = first;
		Last = last;
	}
}*/

public class PlayerInfo
{
	public void Health()
	{
		PlayerPrefs.SetInt("Player_Health", 100);
	}
	public void Name()
	{
		PlayerPrefs.SetString("Player_Name", "Odin");
	}
}

public class Player_name : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		PlayerInfo player = new PlayerInfo();
		
		print(PlayerPrefs.GetInt("Player_Health"));
		print(PlayerPrefs.GetString("Player_Name"));
		
		
		
		//Debug.Log("player info {0}", player.Health);
		
		//Debug.Log("player name: {0}, player Health: {1}", player.Name, player.Health);
		
	
	
	}
}
