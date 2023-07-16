namespace Boss
{
    public class MoveState : GroundedState
    {
        public MoveState(BossEntity entity, FiniteStateMachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
        {
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
        }
    }
}