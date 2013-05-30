using UnityEngine;
using System.Collections;
using FightGame;
using FSM;

namespace FightGame
{
	public class Fighter_Basic : A_Fighter
	{
		public Fighter_Basic (GameObject gobj, int playerNumber)
			:base (playerNumber,gobj)
		{
			this.gobj = gobj;
			this.status = new Status_None();
			this.name = "Fighter_Basic";
			
			attacklist.Add("test",new Attack_Melee(this,0,0,0)); //tom add for hitbox test, remove later
			
			State S_idle = new State("idle", new Action_IdleEnter(), new Action_IdleUpdate(), new Action_IdleExit());
			State S_walkForward = new State("walkForward", new Action_WalkForwardEnter(), new Action_WalkForwardUpdate(), new Action_WalkForwardExit());
			
			Transition T_idle = new Transition(S_idle, new Action_None());
			Transition T_walkForward = new Transition(S_walkForward, new Action_None());
			
			S_idle.addTransition(T_walkForward, "walkForward");
			S_walkForward.addTransition(T_idle, "idle");
			
			this.moveGraph = new FSMContext(S_idle, new Action_None());
			
		}
		

	}
}

