using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_DeathEnter:FSMAction
	{
		public override void execute(FSMContext c, object o){
			A_Fighter myFighter = (A_Fighter)o;
			if(myFighter.playerNumber ==1)
			{
				GameManager.P2.roundsWon+=1;
			}
			else
			{
				GameManager.P1.roundsWon+=1;
			}
		}
		
	}
}

