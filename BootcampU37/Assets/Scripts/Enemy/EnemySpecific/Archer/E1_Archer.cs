using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy {
	public class E1_Archer :Entity
	{
		public ArcherIdleState idleState { get; private set; }
		public ArcherMoveState moveState { get; private set; }
		public ArcherAttackState attackState { get; private set; }
		public ArcherPlayerDetectedState playerDetectedState { get; private set; }
		[SerializeField]
		private D_IdleState idleStateData;
		[SerializeField]
		private D_PlayerDetectedData playerDetecetedStateData;
		[SerializeField]
		private D_AttackState attackStateData;
		[SerializeField]
		private D_MoveState moveStateData;

		public override void Awake()
		{
			base.Awake();
			idleState = new	ArcherIdleState(this, stateMachine, "idle", idleStateData, this);
			playerDetectedState = new ArcherPlayerDetectedState(this, stateMachine, "playerDetected", playerDetecetedStateData, this);
			attackState = new ArcherAttackState(this, stateMachine, "attack", attackStateData, this);
			moveState = new ArcherMoveState(this, stateMachine, "move", moveStateData, this);
			stateMachine.Initialize(moveState);
		}
	}
}
