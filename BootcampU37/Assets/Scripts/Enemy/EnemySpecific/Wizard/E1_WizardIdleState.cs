using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
	public class E1_WizardIdleState : IdleState
	{
		private E1_Wizard enemy;
		private bool isPlayerInMaxAgroRange;
		public E1_WizardIdleState(Entity etity, FiniteStateMachine stateMachine, string animBoolName,D_IdleState stateData, E1_Wizard enemy) : base(etity, stateMachine, animBoolName,stateData)
		{
			this.enemy = enemy;
		}

		public override void DoChecks()
		{
			base.DoChecks();
			isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
		}

		public override void Enter()
		{
			base.Enter();
		}

		public override void Exit()
		{
			base.Exit();
		}

		public override void LogicUpdate()
		{
			base.LogicUpdate();
			if (isPlayerInMaxAgroRange)
			{
				stateMachine.ChangeState(enemy.playerDetectedState);
			}
		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();
		}
	}
}
