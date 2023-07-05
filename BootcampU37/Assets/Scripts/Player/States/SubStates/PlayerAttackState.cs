namespace Player
{
    public class PlayerAttackState : PlayerAbilityState
    {
        private int attackCounter;

        public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void AnimationStartMovementTrigger()
        {
            core.Movement.SetVelocityX(playerData.attackMovementSpeed * core.Movement.FacingDirection);
        }

        public override void AnimationStopMovementTrigger()
        {
            core.Movement.SetVelocityZero();
        }

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();
            isAbilityDone = true;
        }

        public override void Enter()
        {
            base.Enter();
            
            core.Movement.SetVelocityZero();

            if (attackCounter >= playerData.attackAmount)
            {
                attackCounter = 0;
            }

        }

        public override void Exit()
        {
            base.Exit();
            attackCounter++;
            player.Anim.SetInteger("attackCounter", attackCounter);
        }
    }
}
