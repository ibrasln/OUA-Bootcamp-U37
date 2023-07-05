namespace Player
{
    public class PlayerJumpState : PlayerAbilityState
    {
        private int jumpAmountLeft;

        public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
            jumpAmountLeft = playerData.jumpAmount;
        }

        public override void Enter()
        {
            base.Enter();
            player.InputHandler.UseJumpInput();
            core.Movement.SetVelocityY(playerData.jumpPower);
            jumpAmountLeft--;
            isAbilityDone = true;
        }

        public bool CanJump()
        {
            return (jumpAmountLeft > 0);
        }

        public void DecreaseJumpAmountLeft() => jumpAmountLeft--;
        public void ResetJumpAmountLeft() => jumpAmountLeft = playerData.jumpAmount;
    }
}
