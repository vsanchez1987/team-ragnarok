using UnityEngine;
using System.Collections.Generic;
using System;
using FightGame;

namespace FightGame
{
	public class FightCamera
	{
		public Camera camera;
		public Player p1;
		public Player p2;
		public Vector3 p1Position;
		public Vector3 p2Position;
		
		public FightCamera ( Player p1, Player p2 )
		{
			this.camera = Camera.main;
			this.p1 = p1;
			this.p2 = p2;
		}
		
		public void Update(){
			this.p1Position = (p1.Fighter != null) ? this.p1.Fighter.gobj.transform.position : camera.transform.position;
			this.p2Position = (p2.Fighter != null) ? this.p2.Fighter.gobj.transform.position : camera.transform.position;
			
			this.camera.transform.position = new Vector3( 
				(this.p1Position.x + this.p2Position.x)/2.0f, 
				camera.transform.position.y, 
				camera.transform.position.z );
		}
	}
}

