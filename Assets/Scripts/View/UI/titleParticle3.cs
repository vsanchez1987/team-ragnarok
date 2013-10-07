using UnityEngine;
using System.Collections;

public class titleParticle3 : MonoBehaviour {
	ParticleSystem p;
	// Use this for initialization
	void Start () {
	p =this.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		p.startSize = Mathf.Lerp(2,0,Time.time);
		//p.startSize = Mathf.Lerp(1000,0,Time.time/1.0f);
	}
}
