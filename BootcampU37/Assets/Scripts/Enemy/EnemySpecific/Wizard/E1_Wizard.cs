using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
	public class E1_Wizard : Entity
	{
		public E1_WizardIdleState idleState { get; private set; }
		public E1_WizardPlayerDetectedState playerDetectedState { get; private set; }
		public E1_WizardAttackState attackState { get; private set; }

		[SerializeField]
		private D_IdleState idleStateData;
		[SerializeField]
		private D_PlayerDetectedData playerDetecetedStateData;
		[SerializeField]
		private D_AttackState attaackStateData;

		public override void Awake()
		{
			base.Awake();
			idleState = new E1_WizardIdleState(this, stateMachine, "idle", idleStateData, this);
			playerDetectedState = new E1_WizardPlayerDetectedState(this, stateMachine, "playerDetected", playerDetecetedStateData, this);
			attackState = new E1_WizardAttackState(this, stateMachine, "attack", attaackStateData, this);
			stateMachine.Initialize(idleState);
		}
	}
	
	
}
