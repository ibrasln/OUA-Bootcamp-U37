using UnityEngine;

namespace Platformer.Player
{
    public class PlayerState 
    {
        protected Player player;
        protected PlayerStateMachine stateMachine;
        protected PlayerDataSO playerData;
        protected float startTime;
        protected bool isAnimationFinished;
        private readonly string animBoolName;

        public PlayerState (Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName)
        {
            this.player = player;
            this.stateMachine = stateMachine;
            this.playerData = playerData;
            this.animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            player.Anim.SetBool(animBoolName, true);
            startTime = Time.time;
            isAnimationFinished = false;
            DoChecks();
        }

        public virtual void Exit()
        {
            player.Anim.SetBool(animBoolName, false);
        }

        public virtual void LogicUpdate()
        {
            Debug.Log("Player State");
        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {

        }

        public virtual void AnimationFinishTrigger() => isAnimationFinished = false;
        public virtual void AnimationStartMovementTrigger()
        {

        }

        public virtual void AnimationStopMovementTrigger()
        {

        }
    }
}
