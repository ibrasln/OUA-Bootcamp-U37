using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
	public class AttackState : State
	{
		public D_AttackState stateData;
		protected bool isPlayerInMinAgroRange;
		protected bool isPlayerInMaxAgroRange;
		public AttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName,D_AttackState stateData) : base(etity, stateMachine, animBoolName)
		{
			this.stateData = stateData;
		}

		public override void DoChecks()
		{
			base.DoChecks();
			isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
			isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
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
		}

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();
		}
	}

}