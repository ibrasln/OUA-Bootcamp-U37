using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy {
	public class ArcherPlayerDetectedState : PlayerDetectedState
	{
		private E1_Archer enemy;
		public ArcherPlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedData stateData,E1_Archer enemy) : base(etity, stateMachine, animBoolName, stateData)
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
			enemy.SetVelocity(3.8f);
		}

		public override void Exit()
		{
			base.Exit();
		}

		public override void LogicUpdate()
		{
			base.LogicUpdate();
			if (!isPlayerInMaxAgroRange)
			{
				stateMachine.ChangeState(enemy.moveState);
			}
			if (isPlayerInMinAgroRange)
			{
				stateMachine.ChangeState(enemy.attackState);
			}
		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();
		}
	}
}