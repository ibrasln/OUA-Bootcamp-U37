using UnityEngine;

namespace Player
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
            onGround = core.CollisionSenses.Ground;
            isTouchingWall = core.CollisionSenses.WallFront;
            //isFeetTouchingWall = core.CollisionSenses.CheckIsFeetTouchingWall();
            //canGrab = core.CollisionSenses.CheckCanGrab();
            isTouchingLadder = core.CollisionSenses.Ladder;
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

            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;
            jumpInput = player.InputHandler.JumpInput;
            dashInput = player.InputHandler.DashInput;

            if (onGround && core.Movement.CurrentVelocity.y < .1f)
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
            //else if (canGrab)
            //{
            //    stateMachine.ChangeState(player.LedgeGrabState);
            //}
            //else if (isFeetTouchingWall && isTouchingWall && (core.Movement.CurrentVelocity.y < .1f))
            //{
            //    stateMachine.ChangeState(player.WallSlideState);
            //}
            else
            {
                core.Movement.CheckIfShouldFlip(xInput);
                core.Movement.SetVelocityX(playerData.moveSpeedInAir * xInput);
                player.Anim.SetFloat("yVelocity", core.Movement.CurrentVelocity.y);
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
