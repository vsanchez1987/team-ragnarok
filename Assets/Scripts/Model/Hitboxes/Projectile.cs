using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame
{
	public class Projectile
	{
		public GameObject 	gobj;
		public A_Fighter	attackOwner;
		public string		projectileName;
		
		public Projectile(string ProjectileName, A_Fighter attackOwner){
			this.gobj = gobj;
			this.attackOwner = attackOwner;
		}
	}
}