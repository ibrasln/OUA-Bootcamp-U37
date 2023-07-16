using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
	public class E_Worm : Entity
	{
		public WormAttackState attackState { get; private set; }
		public WormIdle idleState { get; private set; }
		public WormMoveState moveState{ get; private set; }
		public WormPlayerDetecktedState playerDetectedState{ get; private set; }

		[SerializeField]
		private D_AttackState attackStateData;
		[SerializeField]
		private D_IdleState idleStateData;
		[SerializeField]
		private D_MoveState moveStateData;
		[SerializeField]
		private D_PlayerDetectedData playerDetectedData;
		public override void Awake()
		{
			base.Awake();
			attackState = new WormAttackState(this, stateMachine, "attack", attackStateData, this);
			idleState = new WormIdle(this, stateMachine, "idle", idleStateData, this);
			moveState = new WormMoveState(this, stateMachine, "move", moveStateData, this);
			playerDetectedState = new WormPlayerDetecktedState(this, stateMachine, "playerDetected", playerDetectedData, this);
			stateMachine.Initialize(moveState);
		}

	}
}