namespace Platformer.Player
{
    public class PlayerWallSlideState : PlayerTouchingWallState
    {
        private bool isFeetTouchingWall;

        public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
            isFeetTouchingWall = player.CheckIsFeetTouchingWall();
        }

        public override void Enter()
        {
            base.Enter();
            player.SetVelocityX(0f);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (onGround && player.CurrentVelocity.y < .1f)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if (jumpInput && player.JumpState.CanJump() && xInput == -player.FacingDirection)
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else if (!isFeetTouchingWall && player.CurrentVelocity.y < .1f)
            {
                stateMachine.ChangeState(player.InAirState);
            }
            else
            {
                player.SetVelocityY(playerData.wallSlideSpeed);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
