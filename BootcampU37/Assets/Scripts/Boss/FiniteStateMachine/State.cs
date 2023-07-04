using UnityEngine;

namespace Boss
{
    public class State
    {
        protected FiniteStateMachine stateMachine;
        protected BossEntity bossEntity;
        protected Core core;

        public float StartTime { get; protected set; }

        protected string animBoolName;

        public State(BossEntity entity, FiniteStateMachine stateMachine, string animBoolName)
        {
            this.bossEntity = entity;
            this.stateMachine = stateMachine;
            this.animBoolName = animBoolName;
            core = bossEntity.Core;
        }

        public virtual void Enter()
        {
            StartTime = Time.time;
            bossEntity.Anim.SetBool(animBoolName, true);
            DoChecks();
        }

        public virtual void Exit()
        {
            bossEntity.Anim.SetBool(animBoolName, false);
        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {

        }
    }
}
