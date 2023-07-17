using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
	public class E1_WizardAttackState : AttackState
	{
		private E1_Wizard enemy;
		public E1_WizardAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_AttackState stateData,E1_Wizard enemy) : base(etity, stateMachine, animBoolName, stateData)
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
		}

		public override void Exit()
		{
			base.Exit();
		}

		public override void LogicUpdate()
		{
			base.LogicUpdate();
			if (!isPlayerInMinAgroRange)
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
