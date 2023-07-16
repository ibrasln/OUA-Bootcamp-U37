using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
	public class ArcherAttackState : AttackState
	{
		private E1_Archer enemy;
		private bool isPlayerInMinAgroRange;
		public ArcherAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_AttackState stateData,E1_Archer enemy) : base(etity, stateMachine, animBoolName, stateData)
		{
			this.enemy = enemy;
		}

		public override void DoChecks()
		{
			base.DoChecks();
			isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
		}

		public override void Enter()
		{
			base.Enter();
			enemy.SetVelocity(0);
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