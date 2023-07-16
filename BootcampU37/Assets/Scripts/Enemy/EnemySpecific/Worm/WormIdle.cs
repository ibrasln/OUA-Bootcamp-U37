using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy {
	public class WormIdle : IdleState
	{
		private E_Worm enemy;
		public WormIdle(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData,E_Worm enemy) : base(etity, stateMachine, animBoolName, stateData)
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
			Debug.Log(isPlayerInMaxAgroRange);
			if (isPlayerInMinAgroRange)
			{
				stateMachine.ChangeState(enemy.attackState);
			}
			else if (isPlayerInMaxAgroRange)
			{
				stateMachine.ChangeState(enemy.playerDetectedState);
			}
			if (isIdleTimeOver)
			{
				stateMachine.ChangeState(enemy.moveState);
			}
		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();
		}
	}
}
