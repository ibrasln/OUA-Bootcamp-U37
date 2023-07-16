using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy {
	public class ArcherMoveState : MoveState
	{
		private E1_Archer enemy;

		public ArcherMoveState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData,E1_Archer enemy) : base(etity, stateMachine, animBoolName, stateData)
		{
			this.enemy = enemy;
		}
		public override void Enter()
		{
			base.Enter();
			entity.SetVelocity(stateData.movementSpeed);
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
			else if (isPlayerInMaxAgroRange)
			{
				stateMachine.ChangeState(enemy.playerDetectedState);
			}
			if (isDetectingWall || !isDetectingLedge)
			{
				enemy.idleState.SetFlipAfterIdle(true);
				stateMachine.ChangeState(enemy.idleState);
			}

		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();

		}
	}
}
