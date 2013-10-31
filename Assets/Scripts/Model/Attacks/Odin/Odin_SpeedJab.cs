using UnityEngine;
using System.Collections;
using FightGame;


//regular melee - none
namespace FightGame{
	public class Odin_SpeedJab : Attack_Melee {
		public Odin_SpeedJab(string animationName, A_Fighter attackOwner, float animationSpeed = 1.0f) : base(animationName, animationSpeed, attackOwner){
		
			this.AddInstruction(new JointHitBoxInstruction(
				"r_wrist_jnt", 		//joint
				attackOwner, 		//fighter
				2.0f, 				//radius
				5.0f, 				//damage
				0.2f, 				//start time 
				3.0f, 				//end time
				Vector3.zero, 		//offset
				Vector3.zero 		//movement
				));	
		}
	}
}	
