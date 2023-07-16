using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy {
	public class WormPlayerDetecktedState : PlayerDetectedState
	{
		private E_Worm enemy;
		public WormPlayerDetecktedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedData stateData,E_Worm enemy) : base(etity, stateMachine, animBoolName, stateData)
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
