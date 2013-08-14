using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FightGame
{
	public class Player
	{
		public  GamePad			controls;
		private int				playerNumber;
		private A_Fighter		fighter;
		
		public Player (int playerNumber)
		{
			this.controls     	= new GamePad(this);
			this.playerNumber 	= playerNumber;
			this.fighter 		= null;
		}
		
		public void DoAttackCommand( AttackCommand attackCommand ){
			if (this.fighter != null){
				Debug.Log("Attack Command: " + attackCommand.ToString());
				this.fighter.DoAttackCommand( attackCommand );
			}
		}
		
		public void DoMoveCommand( MoveCommand moveCommand ){
			if (this.fighter != null){
				Debug.Log("Move Command: " + moveCommand.ToString());
				this.fighter.DoMoveCommand( moveCommand );
			}
		}
		
		public void Update(){
			if (this.fighter != null){
				this.fighter.Update();
			}
		}
		/*
		public List<HitBoxCollisionInfo> HitBoxCollisions{
			get { return this.fighter.HitBoxCollisions; }
		}
		*/
		public bool GotHit{
			get { return this.fighter.gothit; }
			set { this.fighter.gothit = value; }
		}
		
		public int PlayerNumber{
			get { return this.playerNumber; }
		}
		
		public A_Fighter Fighter{
			get { return this.fighter; }
		}
		
		public void InstantiateFighter(string fighter, Vector3 position, Quaternion rotation){
			GameObject character = GameObject.Instantiate( Resources.Load("Fighters/" + fighter, typeof(GameObject)),
				position, rotation ) as GameObject;
			Vector3 localScale = this.playerNumber == 1 ? character.transform.localScale : 
				new Vector3(-character.transform.localScale.x, character.transform.localScale.y, character.transform.localScale.z);
			
			character.transform.localScale = localScale;
			
			switch (fighter){
			case "Fighter_Odin":
				this.fighter = new Fighter_Odin(character, this.playerNumber);
				break;
			case "Fighter_Heavy":
				this.fighter = new Fighter_Heavy(character, this.playerNumber);
				break;
			default:
				break;
			}
		}
		
		public void SelectFighter( A_Fighter fighter ){
			
		}
	}
}