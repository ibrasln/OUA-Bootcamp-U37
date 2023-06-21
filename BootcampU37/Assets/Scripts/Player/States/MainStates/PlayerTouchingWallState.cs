using UnityEngine;

namespace Platformer.Player
{
    public class PlayerTouchingWallState : PlayerState
    {
        protected bool onGround;
        protected bool isTouchingWall;
        protected bool jumpInput;
        protected int xInput;
        protected int yInput;

        public PlayerTouchingWallState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();
        }

        public override void DoChecks()
        {
            base.DoChecks();
            onGround = player.CheckOnGround();
            isTouchingWall = player.CheckIsTouchingWall();
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

            jumpInput = player.InputHandler.JumpInput;
            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
