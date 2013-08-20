using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Projectile
	{
		public GameObject 	gobj;
		public A_Fighter	owner;
		public string		projectileName;
		
		public Projectile(string ProjectileName, A_Fighter owner){
			this.gobj = gobj;
			this.owner = owner;
		}
	}
}