using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame{
	public class MoveCommand : Command
	{
		public const int NONE			= 0;
		public const int FORWARD 		= 1;
		public const int FORWARD_DOWN 	= 2;
		public const int FORWARD_UP 	= 3;
		public const int BACK			= 4;
		public const int BACK_DOWN		= 5;
		public const int BACK_UP		= 6;
		public const int UP				= 7;
		public const int DOWN			= 8;
	}
}

