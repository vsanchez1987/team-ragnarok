using UnityEngine;
using System.Collections;

public class TitleParticle : MonoBehaviour {
	ParticleSystem p;
	// Use this for initialization
	void Start () {
		p =this.GetComponent<ParticleSystem>();
		p.emissionRate = 0;
		p.renderer.enabled = false;
		p.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > 4.5f && Time.time< 9.95f)
		{
			if(p.isStopped)
			{
			p.Play();
			p.emissionRate = 10.0f;
			p.renderer.enabled = true;
			}
		}
	
		else if(Time.time >9.95f)
		{
			if(p.isPlaying)
			{
			p.Stop();
			}
		}
	}
}
