<<<<<<< HEAD:Assets/Scripts/Model/FSM/Actions/Gothit/Action_TakeDamageEnter.cs
using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_TakeDamageEnter:FSMAction
	{
		public override void execute(FSMContext c, Object o){
			
			/*
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			fighter.gothit = false;
			//"mega_punch" animation just for testing
			fighter.gobj.animation.CrossFade("mega_punch");
			*/
		}
	}
}

=======
using System;
using System.Collections.Generic;
using FightGame;
using FSM;

namespace FSM
{
	public class Action_TakeDamageEnter:FSMAction
	{
		public override void execute(FSMContext c, Object o){
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			fighter.gothit = false;
			//"mega_punch" animation just for testing
			fighter.gobj.animation.CrossFade("mega_punch");
		}
	}
}

>>>>>>> c6fd01af228a86dde53613725fb6a675bcc014f2:Assets/Scripts/Model/FSM/Actions/takeDamage/Action_TakeDamageEnter.cs
