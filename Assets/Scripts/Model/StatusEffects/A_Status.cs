using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame{
	public abstract class A_Status {
		public string name;
		public string particleName;
		private A_Fighter attackOwner;
		
		public A_Status(string name, A_Fighter attackOwner, string particleName){
			this.name = name;
			this.attackOwner = attackOwner;
			this.particleName = particleName;
		}
		
		public abstract void Init();
		public abstract void Execute();
	}
}