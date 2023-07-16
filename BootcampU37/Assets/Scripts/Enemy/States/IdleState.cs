using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
	public class IdleState : State
	{
		protected D_IdleState stateData;
		protected bool flipAfterIdle;
		protected float idleTime;
		protected bool isIdleTimeOver;
		protected bool isPlayerInMinAgroRange;
		protected bool isPlayerInMaxAgroRange;

		public IdleState(Entity etity, FiniteStateMachine stateMachine, string animBoolName,D_IdleState stateData) : base(etity, stateMachine, animBoolName)
		{
			this.stateData = stateData;
		}
		public override void DoChecks()
		{
			base.DoChecks();
			isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
			isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
		}

		public override void Enter()
		{
			base.Enter();
			entity.SetVelocity(0);
			isIdleTimeOver = false;
			SetRandomIdleTime();


		}

		public override void Exit()
		{
			base.Exit();
			if (flipAfterIdle)
			{
				entity.Flip();
			}
		}

		public override void LogicUpdate()
		{
			base.LogicUpdate();
			if (Time.time > startTime + idleTime)
			{
				isIdleTimeOver = true;
			}
		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();
		}
		public void SetFlipAfterIdle(bool flip)
		{
			flipAfterIdle = flip;
		}
		private void SetRandomIdleTime()
		{
			idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
		}
	}
}