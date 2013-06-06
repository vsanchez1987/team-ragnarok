using UnityEngine;
using System.Collections;
using FightGame;
using FSM;

namespace FightGame
{
	public class Fighter_Odin : A_Fighter
	{
		public Fighter_Odin (GameObject gobj, int playerNumber)
			:base (playerNumber,gobj)
		{
			this.gobj = gobj;
			this.status = new Status_None();
			this.name = "Odin";
			
			//Tom comment out
			//this.attacklist.Add("back","Sweeping Spear");
			//this.attacklist.Add("up","Scorpion Uppercut");
			//this.attacklist.Add("down","Speed Jab");
			//this.attacklist.Add("forward","Thrust");
			//this.attacklist.Add("none","Shield Swipe");
			
			//this.uniquelist.Add("back","Raven Soul Steal");
			//this.uniquelist.Add("up","Raven Storm");
			//this.uniquelist.Add("down","Teleport");
			//this.uniquelist.Add("forward","Ravens Fury");
			
			//Formula to add more attack to attack list:
			//this.attacklist.Add( "1" if regular attack + direction "back,forward,up,down",create new cs file) 
			//					   "2" if unique attack  + direction "back,forward,up,down",
			this.attacklist.Add("1back",new Sweeping_Spear(this,0,0,0)); 
			

			State S_idle = new State("idle", new Action_IdleEnter(), new Action_IdleUpdate(), new Action_IdleExit());
			State S_walkForward = new State("walkForward", new Action_WalkForwardEnter(), new Action_WalkForwardUpdate(), new Action_WalkForwardExit());
			State S_attack = new State("attack",new Action_AttackEnter(), new Action_AttackUpdate(), new Action_AttackExit());
			//State S_unique = new State("unique",new Action_UniqueEnter(), new Action_UniqueUpdate(), new Action_UniqueExit());
			
			Transition T_idle = new Transition(S_idle, new Action_None());
			Transition T_walkForward = new Transition(S_walkForward, new Action_None());
			Transition T_attack = new Transition(S_attack, new Action_None());
			//Transition T_unique = new Transition(S_unique,new Action_None());
			
			S_idle.addTransition(T_walkForward, "walkForward");
			S_idle.addTransition(T_attack,"attack");
			//S_idle.addTransition(T_unique,"unique");
			S_idle.addTransition(T_idle,"idle");
			
			S_walkForward.addTransition(T_idle, "idle");
			S_walkForward.addTransition(T_walkForward,"walkForward");
			
			S_attack.addTransition(T_idle,"idle");
			//S_attack.addTransition(T_walkForward,"walkForward");
			
			//S_unique.addTransition(T_idle,"idle");
			this.moveGraph = new FSMContext(S_idle, new Action_None());
			
		}
		
		

	}
}

