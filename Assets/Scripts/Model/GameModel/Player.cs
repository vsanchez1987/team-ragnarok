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
			this.controls     	= new GamePad(playerNumber);
			this.playerNumber 	= playerNumber;
			this.fighter 		= null;
		}
		
		public void DoAttackCommand( AttackCommand attackCommand ){
			if (this.fighter != null){
				//this.fighter.DoMoveCommand( attackCommand );
			}
		}
		
		public void DoMoveCommand( MoveCommand moveCommand ){
			if (this.fighter != null){
				//this.fighter.DoMoveCommand( moveCommand );
			}
		}
		
		public void Update(){
			if (this.fighter != null){
				this.fighter.Update();
			}
		}
	}
}

