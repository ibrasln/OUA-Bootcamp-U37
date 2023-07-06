using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy {
	public class E1_WizardPlayerDetectedState : PlayerDetectedState
	{
		private E1_Wizard enemy;
		public E1_WizardPlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedData stateData,E1_Wizard enemy) : base(etity, stateMachine, animBoolName, stateData)
		{
			this.enemy = enemy;
		}

		public override void DoChecks()
		{
			base.DoChecks();
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

			if (isPlayerInMinAgroRange)
			{
				stateMachine.ChangeState(enemy.attackState);
			}
			else if (!isPlayerInMaxAgroRange)
			{
				stateMachine.ChangeState(enemy.idleState);
			}

		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();
		}
	}
}