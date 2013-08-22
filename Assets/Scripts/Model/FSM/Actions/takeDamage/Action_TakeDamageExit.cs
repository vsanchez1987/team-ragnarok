<<<<<<< HEAD:Assets/Scripts/Model/FSM/Actions/Gothit/Action_TakeDamageExit.cs
using System;
using System.Collections.Generic;
using FightGame;
using FSM;
using UnityEngine;

namespace FSM
{
	public class Action_TakeDamageExit:FSMAction
	{
		public override void execute(FSMContext c, object o){
			A_Fighter fighter;
			fighter = (A_Fighter)o;
			GameObject gobj = fighter.gobj;
			
			gobj.animation.Stop();
			fighter.hurtLocation = Location.NONE;
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
	public class Action_TakeDamageExit:FSMAction
	{
		public override void execute(FSMContext c, object o){
		}
	}
}

>>>>>>> c6fd01af228a86dde53613725fb6a675bcc014f2:Assets/Scripts/Model/FSM/Actions/takeDamage/Action_TakeDamageExit.cs
