using UnityEngine;

namespace Platformer.Player
{
    public class PlayerInAirState : PlayerState
    {
        #region Inputs
        private int xInput;
        private int yInput;
        private bool jumpInput;
        private bool dashInput;
        #endregion

        #region Checks
        private bool onGround;
        private bool isTouchingWall;
        private bool isFeetTouchingWall;
        private bool canGrab;
        private bool isTouchingLadder;
        #endregion

        #region Other Variables
        private bool coyoteTime;
        #endregion

        public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
            onGround = player.CheckOnGround();
            isTouchingWall = player.CheckIsTouchingWall();
            isFeetTouchingWall = player.CheckIsFeetTouchingWall();
            canGrab = player.CheckCanGrab();
            isTouchingLadder = player.CheckIsTouchingLadder();
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

            CheckCoyoteTime();

            player.Anim.SetFloat("yVelocity", player.CurrentVelocity.y);
            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;
            jumpInput = player.InputHandler.JumpInput;
            dashInput = player.InputHandler.DashInput;

            if (onGround && player.CurrentVelocity.y < .1f)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if (jumpInput && player.JumpState.CanJump())
            {   
                stateMachine.ChangeState(player.JumpState);
            }
            else if (dashInput && player.DashState.CanDash())
            {
                stateMachine.ChangeState(player.DashState);
            }
            else if (isTouchingLadder && yInput == 1)
            {
                stateMachine.ChangeState(player.LadderClimbState);
            }
            else if (canGrab)
            {
                stateMachine.ChangeState(player.LedgeGrabState);
            }
            else if (isFeetTouchingWall && isTouchingWall && (player.CurrentVelocity.y < .1f))
            {
                stateMachine.ChangeState(player.WallSlideState);
            }
            else
            {
                player.CheckIfShouldFlip(xInput);
                player.SetVelocityX(playerData.moveSpeedInAir * xInput);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        private void CheckCoyoteTime()
        {
            if (coyoteTime && Time.time >= startTime + playerData.coyoteTime)
            {
                coyoteTime = false;
                player.JumpState.DecreaseJumpAmountLeft();
            }
        }

        public void StartCoyoteTime() => coyoteTime = true;
    }
}
