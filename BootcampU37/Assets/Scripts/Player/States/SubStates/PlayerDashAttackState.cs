using UnityEngine;

namespace Platformer.Player
{
    using Manager;

    public class PlayerDashAttackState : PlayerAbilityState
    {
        private Vector2 lastAIPos;
        public PlayerDashAttackState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();

            isAbilityDone = true;
        }

        public override void AnimationStartMovementTrigger()
        {
            base.AnimationStartMovementTrigger();
            player.SetVelocityX(playerData.dashAttackMovementSpeed * player.FacingDirection);
        }

        public override void AnimationStopMovementTrigger()
        {
            base.AnimationStopMovementTrigger();
            player.SetVelocityZero();
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
            if (!onGround || isTouchingWall)
            {
                isAbilityDone = true;
            }
            else
            {
                CheckIfShouldPlaceAfterImage();
            }
        }
        private void CheckIfShouldPlaceAfterImage()
        {
            if (Mathf.Abs(player.transform.position.x - lastAIPos.x) >= playerData.distanceBetweenAfterImages)
                PlaceAfterImage();
        }

        private void PlaceAfterImage()
        {
            ObjectPoolManager.instance.GetObjectFromPool("AfterImage");
            lastAIPos = player.transform.position;
        }
    }
}
