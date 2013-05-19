using UnityEngine;
using System.Collections;
using FightGame;
using FSM;

namespace FightGame
{
	public class Fighter_Odin : A_Fighter
	{
		public Fighter_Odin (GameObject gobj, int playerNumber, string hAxis, string vAxis, string atkBtn, string unqBtn, string specialBtn, string blockBtn)
			:base (playerNumber,hAxis,vAxis,atkBtn,unqBtn,specialBtn, blockBtn, gobj)
		{
			this.gobj = gobj;
			this.status = new Status_None();
			this.name = "Odin";
			
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

