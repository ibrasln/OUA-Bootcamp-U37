namespace Platformer.Player
{
    public class PlayerAttackState : PlayerAbilityState
    {
        private int attackCounter;

        public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void AnimationStartMovementTrigger()
        {
            player.SetVelocityX(playerData.attackMovementSpeed * player.FacingDirection);
        }

        public override void AnimationStopMovementTrigger()
        {
            player.SetVelocityZero();
        }

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();
            isAbilityDone = true;
        }

        public override void Enter()
        {
            base.Enter();
            
            player.SetVelocityZero();

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
