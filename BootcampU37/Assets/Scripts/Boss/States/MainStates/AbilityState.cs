namespace Boss
{
    public class AbilityState : State
    {

        protected bool isAbilityDone;

        public AbilityState(BossEntity entity, FiniteStateMachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
        {
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
        }
    }
}
