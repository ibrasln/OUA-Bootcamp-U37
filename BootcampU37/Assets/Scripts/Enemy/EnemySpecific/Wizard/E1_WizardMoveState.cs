using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
	public class E1_WizardMoveState : MoveState
	{
		private E1_Wizard enemy;
		public E1_WizardMoveState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData,E1_Wizard enemy) : base(etity, stateMachine, animBoolName, stateData)
		{
			this.enemy = enemy;
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
			if (isPlayerInMinAgroRange)
			{
				/*Debug.Log("detected");
				stateMachine.ChangeState(enemy.playerDetectedState);*/
			}
			else if (isDetectingWall || !isDetectingLedge)
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