using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
	public class ArcherIdleState : IdleState
	{
		private E1_Archer enemy;
		private bool isPlayerInMaxAgroRange;

		public ArcherIdleState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData,E1_Archer enemy) : base(etity, stateMachine, animBoolName, stateData)
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
			Debug.Log(isPlayerInMaxAgroRange);
			if (isPlayerInMaxAgroRange)
			{
				Debug.Log("detected oldu");
				stateMachine.ChangeState(enemy.playerDetectedState);
			}
			if (isIdleTimeOver)
			{
				Debug.Log("move oldu");
				stateMachine.ChangeState(enemy.moveState);
			}
		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();
		}
	}
}
