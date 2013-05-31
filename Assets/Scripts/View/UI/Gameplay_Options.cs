using UnityEngine;
using System.Collections;

public class Gameplay_Options : MonoBehaviour 
{
	private float volume = 1.0f;
	
	public float hSliderValue = 0.0F;
	
	private float sliderHght;
	public float sliderWdth;
	
	public float labelHght;
	public float labelWdth;
	
	public float sliderX = 0.0f;
	public float sliderY = 0.0f;
	
	public float labelX = 0.0f;
	public float labelY = 0.0f;

	void OnGUI()
	{
		
		GUILayout.Box("Volume");
		volume = GUILayout.HorizontalSlider(volume, 0.0f, 1.0f);
		AudioListener.volume = volume;
		
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Application.LoadLevel("options");
		}
		//hSliderValue = GUI.HorizontalSlider(new Rect(sliderX, sliderY, sliderWdth, sliderHght), hSliderValue, 0.0F, 10.0F);
		//GUI.Label(new Rect(labelX, labelY, labelWdth, labelHght), "Volume" + hSliderValue);
	}
	
}
