using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
	public class AttackState : State
	{
		public D_AttackState stateData;
		public AttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName,D_AttackState stateData) : base(etity, stateMachine, animBoolName)
		{
			this.stateData = stateData;
		}
	}

}