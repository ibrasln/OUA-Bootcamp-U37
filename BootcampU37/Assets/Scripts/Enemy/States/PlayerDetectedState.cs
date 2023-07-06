using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
	public class PlayerDetectedState : State
	{
		protected bool isPlayerInMinAgroRange;
		protected bool isPlayerInMaxAgroRange;
		public D_PlayerDetectedData stateData;
		public PlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName,D_PlayerDetectedData stateData) : base(etity, stateMachine, animBoolName)
		{
			this.stateData = stateData;
		}

		public override void Enter()
		{
			base.Enter();
			entity.SetVelocity(0f);

		}

		public override void Exit()
		{
			base.Exit();
		}

		public override void LogicUpdate()
		{
			base.LogicUpdate();
		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();
		}

		public override void DoChecks()
		{
			base.DoChecks();
			isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
			isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
		}
	}
}