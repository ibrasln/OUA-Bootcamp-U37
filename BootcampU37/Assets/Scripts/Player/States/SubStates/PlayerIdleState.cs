using UnityEngine;

namespace Player
{
    public class PlayerIdleState : PlayerGroundedState
    {
        public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
            player.SetVelocityZero();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            Debug.Log("Player Idle State");

            if (xInput != 0)
                stateMachine.ChangeState(player.MoveState);
            else if (yInput == -1)
                stateMachine.ChangeState(player.CrouchState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
