using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy {
	public class ArcherPlayerDetectedState : PlayerDetectedState
	{
		private E1_Archer enemy;
		public ArcherPlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedData stateData,E1_Archer enemy) : base(etity, stateMachine, animBoolName, stateData)
		{
			this.enemy = enemy;
		}
	}
}