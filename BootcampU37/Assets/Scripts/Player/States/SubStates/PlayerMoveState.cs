namespace Platformer.Player
{
    public class PlayerMoveState : PlayerGroundedState
    {
        public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
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

            player.SetVelocityX(playerData.moveSpeed * xInput);
            player.CheckIfShouldFlip(xInput);

            if (xInput == 0)
                stateMachine.ChangeState(player.IdleState);
            else if (yInput == -1 && player.SlideState.CanSlide())
                stateMachine.ChangeState(player.SlideState);
            else if (dashInput && player.DashState.CanDash())
                stateMachine.ChangeState(player.DashState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
