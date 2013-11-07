using UnityEngine;
using System.Collections;
using FightGame;


//regular/unique melee - back
namespace FightGame{
	public class Odin_SweepingSpear : Attack_Melee {
		public Odin_SweepingSpear(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner){
			
			this.AddInstruction(new JointHitBoxInstruction(
				"spear_endpoint_gobj", 		//joint
				attackOwner, 		//fighter
				1.0f, 				//radius
				1.0f, 				//damage
				0.2f, 				//start time 
				3.0f, 				//end time
				Vector3.zero, 		//offset
				Vector3.zero 		//movement
				));
			this.AddInstruction(new JointHitBoxInstruction(
				"spear_endpoint_gobj2", 		//joint
				attackOwner, 		//fighter
				1.0f, 				//radius
				1.0f, 				//damage
				0.2f, 				//start time 
				3.0f, 				//end time
				Vector3.zero, 		//offset
				Vector3.zero 		//movement
				));
			this.AddInstruction(new JointHitBoxInstruction(
				"spear_endpoint_gobj3", 		//joint
				attackOwner, 		//fighter
				1.0f, 				//radius
				1.0f, 				//damage
				0.2f, 				//start time 
				3.0f, 				//end time
				Vector3.zero, 		//offset
				Vector3.zero 		//movement
				));
			this.AddInstruction(new JointHitBoxInstruction(
				"spear_endpoint_gobj4", 		//joint
				attackOwner, 		//fighter
				1.0f, 				//radius
				1.0f, 				//damage
				0.2f, 				//start time 
				3.0f, 				//end time
				Vector3.zero, 		//offset
				Vector3.zero 		//movement
				));
		}	
	}
}
