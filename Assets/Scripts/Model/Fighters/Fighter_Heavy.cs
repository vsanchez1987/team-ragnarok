using UnityEngine;
using System.Collections;
using FightGame;
using FSM;

namespace FightGame
{
	public class Fighter_Heavy : A_Fighter
	{
		public Fighter_Heavy (GameObject gobj, int playerNumber)
			:base (playerNumber,gobj)
		{
			this.gobj = gobj;
			this.status = new Status_None();
			this.name = "heavy";
			this.movespeed = 6;
								
			//this.attacklist.Add("1back",new Attack_SweepingSpear(this,0,0,0)); 
			this.attacklist.Add("RegAttack_none",new Attack_MegatonPunch(this,0,0,0));						
			this.attacklist.Add("UniqueAttack_none",new Attack_Punch01(this,0,0,0));
			this.attacklist.Add("RegAttack_forward",new Attack_Punch02(this,0,0,0));
			this.attacklist.Add("RegAttack_back",new Attack_Shot01(this,0,0,0));
			this.attacklist.Add("RegAttack_up",new Attack_Shot02(this,0,0,0));
			this.attacklist.Add("RegAttack_down",new Attack_Shot03(this,0,0,0));
			this.attacklist.Add("UniqueAttack_forward",new Attack_Shot04(this,0,0,0));
			this.attacklist.Add("UniqueAttack_back",new Attack_napalm_flame_thrower(this,0,0,0));
			
			//this.attacklist.Add("1none",new Attack_MegatonPunch(this,0,0,0));
			//this.attacklist.Add("1none",new Attack_MegatonPunch(this,0,0,0));												
			
		}
		
		

	}
}

