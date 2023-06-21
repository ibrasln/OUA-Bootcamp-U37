using UnityEngine;

namespace Platformer.Player
{
    public class PlayerLadderClimbState : PlayerState
    {

        private bool onGround;
        private bool isTouchingLadder;
        private bool jumpInput;
        private int xInput;
        private int yInput;

        public PlayerLadderClimbState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
            onGround = player.CheckOnGround();
            isTouchingLadder = player.CheckIsTouchingLadder();
        }

        public override void Enter()
        {
            base.Enter();
            player.SetVelocityZero();
            player.SetGravityScale(0);
        }

        public override void Exit()
        {
            base.Exit();
            player.ResetGravityScale();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            xInput = player.InputHandler.NormInputX;
            jumpInput = player.InputHandler.JumpInput;
            yInput = player.InputHandler.NormInputY;

            player.Anim.SetFloat("yVelocity", player.CurrentVelocity.y);

            // TODO: transform the position of player to ladder center

            if (onGround && yInput == -1)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if (xInput != 0 && jumpInput)
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else
            {
                player.SetVelocityX(0);
                player.SetVelocityY(playerData.ladderClimbSpeed * yInput);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
