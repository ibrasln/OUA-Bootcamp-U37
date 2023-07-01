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
            onGround = core.CollisionSenses.Ground;
            //isTouchingLadder = player.CheckIsTouchingLadder();
        }

        public override void Enter()
        {
            base.Enter();
            core.Movement.SetVelocityZero();
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

            player.Anim.SetFloat("yVelocity", core.Movement.CurrentVelocity.y);

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
                core.Movement.SetVelocityX(0);
                core.Movement.SetVelocityY(playerData.ladderClimbSpeed * yInput);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
