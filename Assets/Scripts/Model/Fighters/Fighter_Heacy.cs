using UnityEngine;
using System.Collections;
using FightGame;
using FSM;

namespace FightGame
{
	public class Fighter_Heacy : A_Fighter
	{
		public Fighter_Heacy (GameObject gobj, int playerNumber)
			:base (playerNumber,gobj)
		{
			this.gobj = gobj;
			this.status = new Status_None();
			this.name = "Heacy";
			
			this.attacklist.Add("back",new Attack_MegatonPunch(this)); //Tom add to show Hue 
			//this.attacklist.Add("up","Flee"); 					//Tom Comment out
			//this.attacklist.Add("down","Fire Carpet");
			//this.attacklist.Add("forward","Bunker Buster");
			//this.attacklist.Add("none","Door Knocker");
			
			//this.uniquelist.Add("back","1 2 3 Fire");
			//this.uniquelist.Add("up","Heat Seeker");
			//this.uniquelist.Add("down","Rail Gun");
			//this.uniquelist.Add("forward","Napalm Flame Thrower");
			
			
			State S_idle = new State("idle", new Action_IdleEnter(), new Action_IdleUpdate(), new Action_IdleExit());
			State S_walkForward = new State("walkForward", new Action_WalkForwardEnter(), new Action_WalkForwardUpdate(), new Action_WalkForwardExit());
			State S_attack = new State("attack",new Action_AttackEnter(), new Action_AttackUpdate(), new Action_AttackExit());
			State S_unique = new State("unique",new Action_UniqueEnter(), new Action_UniqueUpdate(), new Action_UniqueExit());
			
			Transition T_idle = new Transition(S_idle, new Action_None());
			Transition T_walkForward = new Transition(S_walkForward, new Action_None());
			Transition T_attack = new Transition(S_attack, new Action_None());
			Transition T_unique = new Transition(S_unique,new Action_None());
			
			S_idle.addTransition(T_walkForward, "walkForward");
			S_idle.addTransition(T_attack,"attack");
			S_idle.addTransition(T_unique,"unique");
			
			S_walkForward.addTransition(T_idle, "idle");
			//S_walkForward.addTransition(T_attack,"attack");
			
			S_attack.addTransition(T_idle,"idle");
			//S_attack.addTransition(T_walkForward,"walkForward");
			
			S_unique.addTransition(T_idle,"idle");
			this.moveGraph = new FSMContext(S_idle, new Action_None());
			
		}
		
		

	}
}

