using UnityEngine;

namespace Platformer.Player
{
    public class PlayerGroundedState : PlayerState
    {
        #region Inputs
        protected int xInput;
        protected int yInput;
        protected bool jumpInput;
        protected bool dashInput;
        protected bool attackInput;
        #endregion

        #region Checks
        protected bool onGround;
        protected bool isTouchingWall;
        protected bool isTouchingLadder;
        #endregion

        public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
            onGround = core.CollisionSenses.Ground;
            isTouchingWall = core.CollisionSenses.WallFront;
            //isTouchingLadder = player.CheckIsTouchingLadder();
        }

        public override void Enter()
        {
            base.Enter();
            player.JumpState.ResetJumpAmountLeft();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Debug.Log("Player Grounded State");

            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;
            jumpInput = player.InputHandler.JumpInput;
            dashInput = player.InputHandler.DashInput;
            attackInput = player.InputHandler.AttackInput;

            if (attackInput)
            {
                stateMachine.ChangeState(player.AttackState);
            }
            else if (jumpInput && player.JumpState.CanJump())
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else if (isTouchingLadder && yInput == 1)
            {
                stateMachine.ChangeState(player.LadderClimbState);
            }
            else if (!onGround)
            {
                player.InAirState.StartCoyoteTime();
                stateMachine.ChangeState(player.InAirState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
