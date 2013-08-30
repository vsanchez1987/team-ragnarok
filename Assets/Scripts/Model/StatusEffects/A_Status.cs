using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightGame;

namespace FightGame{
	public abstract class A_Status {
		public string name;
		public string particleName;
		private A_Fighter owner;
		
		public A_Status(string name, A_Fighter owner, string particleName){
			this.name = name;
			this.owner = owner;
			this.particleName = particleName;
		}
		
		public abstract void Init();
		public abstract void Execute();
	}
}