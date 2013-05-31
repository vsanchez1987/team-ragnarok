using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]

public class Saving : MonoBehaviour {
	public int health;
	public string name;
	
	public Saving()
	{
		health = 0;
		name = "";
	}
	
	// deserialized constructor
	
	public Saving(SerializationInfo info, StreamingContext ctxt)
	{
		// get the values from info and assign them to the appropriate properties
		
		health = (int)info.GetValue("Health", typeof(int));
		name = (string)info.GetValue("Name", typeof(string));
		
	}
	
	// Serialization funciton.
	public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
	{
		// You can use any name/value pair, as long as you read them with the same names
		
		info.AddValue("Health", health);
		info.AddValue("Name", name);
	}
	
	public class Example :MonoBehaviour
	{
		int health = 100;
		string name = "Odin";
		
		public void save()
		{

			Saving MyVariables = new Saving();
			MyVariables.health = health;
			MyVariables.name = name;
			Stream stream = File.Open("MyVariables.randomfileextension", FileMode.Create);
			BinaryFormatter bformatter = new BinaryFormatter();
			Debug.Log("saving Variables");
			bformatter.Serialize(stream, MyVariables);
			stream.Close();
			
		}
		
		public void Load()
		{
			Saving myVariables = new Saving();
			Stream stream = File.Open("MyVariables.fileExtension", FileMode.Open);
			BinaryFormatter bformatter = new BinaryFormatter();
			UnityEngine.Debug.Log("Loading variables");
			MyVariables = (Saving)bformatter.Deserialize(stream);
			Debug.Log(MyVariables.name);
			Debug.Log(MyVariables.health);
			stream.Close();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown("s"))
		{
			Save();
		}
		if (Input.GetKeyDown("1"))
		{
			Load();
		}
	
	}
}
