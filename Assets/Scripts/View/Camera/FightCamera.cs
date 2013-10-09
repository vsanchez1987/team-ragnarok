using UnityEngine;
using System.Collections.Generic;
using System;
using FightGame;

namespace FightGame
{
	public class FightCamera
	{
		public Camera camera;
		public float maxDistance;
		public float leftBoundary;
		public float rightBoundary;
		public float yPositionOffset;
		public float yTargetOffset;
		
		private Player p1;
		private Player p2;
		private Vector3 p1Position;
		private Vector3 p2Position;
		private Vector3 centerPosition;
		
		private float cameraX;
		private float cameraY;
		private float cameraZ;
		
		private float minZDistance;
		private float maxZDistance;
		
		public FightCamera ( Player p1, Player p2 )
		{
			this.camera = Camera.main;
			CameraInput input = this.camera.GetComponent<CameraInput>();
			this.maxDistance = input.maxDistance;
			this.minZDistance = input.minZDistance;
			this.maxZDistance = input.maxZDistance;
			this.leftBoundary = input.leftBoundary;
			this.rightBoundary = input.rightBoundary;
			this.yPositionOffset = input.yPositionOffset;
			this.yTargetOffset = input.yTargetOffset;
			this.p1 = p1;
			this.p2 = p2;
		}
		
		public void Update(){
			//this.p1Position = (p1.Fighter != null) ? this.p1.Fighter.gobj.transform.position : GameObject.Find("LocatorP1").transform.position;
			//this.p2Position = (p2.Fighter != null) ? this.p2.Fighter.gobj.transform.position : GameObject.Find("LocatorP2").transform.position;
			this.p1Position = (p1.Fighter != null) ? this.p1.Fighter.gobj.transform.position : this.camera.transform.position;
			this.p2Position = (p2.Fighter != null) ? this.p2.Fighter.gobj.transform.position : this.camera.transform.position;
			this.centerPosition = Vector3.Lerp(this.centerPosition, p1Position + ((p2Position - p1Position) * 0.5f), Time.deltaTime * 5.0f);
			float yOffset = (Mathf.Abs(Mathf.Clamp(this.cameraZ, maxZDistance, minZDistance) - minZDistance)) * 0.5f + this.yPositionOffset;
			
			if(GameManager.P1.Fighter.PlayingSpecialAttack() || GameManager.P2.Fighter.PlayingSpecialAttack()){
				//adjust camera here for dramatic effect....
			}
			
			this.cameraX = Mathf.Clamp(this.centerPosition.x, this.leftBoundary + 5.0f, this.rightBoundary - 5.0f);
			this.cameraY = (p1Position.y - p2Position.y)/2.0f + yOffset;
			this.cameraZ = Mathf.Clamp(-(p1Position - p2Position).magnitude - 5.0f, maxZDistance, minZDistance);
			
			Vector3 cameraPosition = new Vector3( this.cameraX, this.cameraY, this.cameraZ);
			this.camera.transform.LookAt(new Vector3(this.cameraX, this.centerPosition.y + this.yTargetOffset, 0.0f));
			
			if (cameraPosition.x > GameManager.LeftBoundary && cameraPosition.x < GameManager.RightBoundary){
				this.camera.transform.position = Vector3.Lerp(this.camera.transform.position, cameraPosition, Time.deltaTime * 3.0f);
			}
		}
	}
}