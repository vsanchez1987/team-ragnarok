using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame{
	public class ActionCommand : Command
	{
		public const int NONE				= 0;
		public const int BLOCK				= 1;
		
		public const int REGULAR			= 2;
		public const int REGULAR_FORWARD	= 3;
		public const int REGULAR_BACK		= 4;
		public const int REGULAR_UP			= 5;
		public const int REGULAR_DOWN		= 6;
		
		public const int UNIQUE				= 7;
		public const int UNIQUE_FORWARD		= 8;
		public const int UNIQUE_BACK		= 9;
		public const int UNIQUE_UP			= 10;
		public const int UNIQUE_DOWN		= 11;
		
		public const int SPECIAL			= 12;
		public const int SPECIAL_FORWARD	= 13;
		public const int SPECIAL_BACK		= 14;
		public const int SPECIAL_UP			= 15;
		public const int SPECIAL_DOWN		= 16;
		
		public ActionCommand () : base()
		{
		}
	}
}

