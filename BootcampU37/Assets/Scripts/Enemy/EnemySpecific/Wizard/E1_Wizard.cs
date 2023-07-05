using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
	public class E1_Wizard : Entity
	{
		public E1_WizardIdleState idleState { get; private set; }
		public E1_WizardMoveState moveState { get; private set; }

		[SerializeField]
		private D_IdleState idleStateData;
		[SerializeField]
		private D_MoveState moveStateData;

		public override void Awake()
		{
			base.Awake();
			moveState = new E1_WizardMoveState(this, stateMachine, "move", moveStateData, this);
			idleState = new E1_WizardIdleState(this, stateMachine, "idle", idleStateData, this);
			stateMachine.Initialize(moveState);
		}
	}
	
	
}
