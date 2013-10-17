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
		//Hieu add for camera movement when playing special attack
		private Vector3 focusPosition;
		private Vector3 movePosition;
		private Vector3 distanceTargettoCamera;
		private bool 	zoomCamera;
		private float   zoomTime;
		private float   localTime;
		private float	dir; //direction depend on which player 
		//
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
			this.localTime = 0f;
			this.zoomCamera = true;
			this.zoomTime = 0f;
		}
		
		public void Update(){
			//this.p1Position = (p1.Fighter != null) ? this.p1.Fighter.gobj.transform.position : GameObject.Find("LocatorP1").transform.position;
			//this.p2Position = (p2.Fighter != null) ? this.p2.Fighter.gobj.transform.position : GameObject.Find("LocatorP2").transform.position;
			this.p1Position = (p1.Fighter != null) ? this.p1.Fighter.gobj.transform.position : this.camera.transform.position;
			this.p2Position = (p2.Fighter != null) ? this.p2.Fighter.gobj.transform.position : this.camera.transform.position;
			this.centerPosition = Vector3.Lerp(this.centerPosition, p1Position + ((p2Position - p1Position) * 0.5f), Time.deltaTime * 5.0f);
			float yOffset = (Mathf.Abs(Mathf.Clamp(this.cameraZ, maxZDistance, minZDistance) - minZDistance)) * 0.5f + this.yPositionOffset;
			
			//Hieu add
			setFocusTarget(p1.Fighter,p2.Fighter);
			
			if( (GameManager.P1.Fighter.PlayingSpecialAttack() || GameManager.P2.Fighter.PlayingSpecialAttack())
				&& zoomCamera)	{
				//condition: if either p1 or p2 play special and zoomCamera is true
					//adjust camera here for dramatic effect....
					
					AdjustCameraFocus();
					this.camera.transform.LookAt(focusPosition);
			}
			else{
				resetZoomCamera();
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
		
		void setFocusTarget(A_Fighter fighter1, A_Fighter fighter2){
			/*
			 * This function set the target on which camera will focus
			 * The function also set the distance, how far from camera to the focus target
			 * and also set zoomTime, which is how long the zoom effect will occur
			 * all the attribute is set under fighter prefab.
			 * Since each fighter has different height, so it's more flexible if we put the
			 * attribute under each player prefab.
			*/
			if(fighter1.PlayingSpecialAttack() && !fighter2.PlayingSpecialAttack()){
				dir = fighter1.GlobalForwardVector.x;
				focusPosition = fighter1.cameraTarget.transform.position;
				movePosition = fighter1.cameraTarget.transform.position;
				distanceTargettoCamera = fighter1.disTargettoCamera;
				zoomTime = fighter1.zoomTime;
			}
			else if(fighter2.PlayingSpecialAttack() && !fighter1.PlayingSpecialAttack()){
				dir = fighter2.GlobalForwardVector.x;
				focusPosition = fighter2.cameraTarget.transform.position;
				movePosition = fighter2.cameraTarget.transform.position;
				distanceTargettoCamera = fighter2.disTargettoCamera;
				zoomTime = fighter2.zoomTime;
			}
		}
		
		void AdjustCameraFocus(){
			//this function do the calculation, and escape zoom effect when timer reach
			movePosition.x += dir*distanceTargettoCamera.x;
			movePosition.y += distanceTargettoCamera.y;
			movePosition.z += distanceTargettoCamera.z;
			this.camera.transform.position = movePosition;
			localTime+= Time.deltaTime;
			if(localTime >= zoomTime){
				zoomCamera = false;
				localTime =0;
			}
		}
		void resetZoomCamera(){
			//this function reset the bool trigger when none special is play.
			if( !(GameManager.P1.Fighter.PlayingSpecialAttack() || GameManager.P2.Fighter.PlayingSpecialAttack()))
			{
				zoomCamera = true;
			}
		}
		
	}
}