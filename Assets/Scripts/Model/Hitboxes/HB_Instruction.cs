using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using FightGame;

public class HB_Instruction
{
	public List<HB_KeyFrame> onOffTimes;
	public A_Fighter owner;
	public string jointName;//pass "projectile" if projectile
	public float damage;
	public float radius;
	public Mechanic attackMechanic;
	public ParticleSystem particleSystem;
	
	public HB_Instruction(A_Fighter owner, List<HB_KeyFrame> onOffTimes, string jointName, float damage, float radius, Mechanic attackMechanic = null, ParticleSystem p = null)
	{
		this.owner = owner;
		this.onOffTimes = onOffTimes;
		this.jointName = jointName;
		this.damage = damage;
		this. radius = radius;
		this.attackMechanic = attackMechanic;
		this.particleSystem = particleSystem;
	}
	
}
