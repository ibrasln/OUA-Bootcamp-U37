 
namespace Player
{
    public class PlayerAbilityState : PlayerState
    {
        protected bool attackInput;

        protected bool isAbilityDone;

        protected bool onGround;
        protected bool isTouchingWall;

        public PlayerAbilityState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
            onGround = core.CollisionSenses.Ground;
            isTouchingWall = core.CollisionSenses.WallCheck;
        }

        public override void Enter()
        {
            base.Enter();
            isAbilityDone = false;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            attackInput = player.InputHandler.AttackInput;

            if (isAbilityDone)
            {
                if (onGround && core.Movement.CurrentVelocity.y < .1f)
                {
                    stateMachine.ChangeState(player.IdleState);
                }
                else
                {
                    stateMachine.ChangeState(player.InAirState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
