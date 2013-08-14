using UnityEngine;
using System.Collections.Generic;
using System;
using FightGame;
using FSM;

namespace FightGame{
	public class GameModel {
		public Player p1;
		public Player p2;
		public Player[] players;

	    // make sure the constructor is private, so it can only be instantiated here
	    public GameModel() {
			this.p1 = new Player(1);
			this.p2 = new Player(2);
			this.players = new Player[] { p1, p2 };
	    }
	}
}