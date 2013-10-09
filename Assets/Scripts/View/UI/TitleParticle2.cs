using UnityEngine;
using System.Collections;

public class TitleParticle2 : MonoBehaviour {
	ParticleSystem p;
	// Use this for initialization
	void Start () {
		p =this.GetComponent<ParticleSystem>();
		//p.emissionRate = 0;
		//p.renderer.enabled = false;
		//p.Play();
		
	}

	
	// Update is called once per frame
	void Update () 
	{
		p.startColor = new Color(1.0f,1.0f,1.0f,Mathf.Lerp(0,1.0f,Time.time/10.0f));
	}
}
