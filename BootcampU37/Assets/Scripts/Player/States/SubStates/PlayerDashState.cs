using UnityEngine;

namespace Platformer.Player
{
    using Manager;

    public class PlayerDashState : PlayerAbilityState
    {
        private float lastDashTime;
        private Vector2 lastAIPos;

        public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
            player.InputHandler.UseDashInput();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (attackInput && onGround)
            {
                isAbilityDone = true;
                lastDashTime = Time.time;
                stateMachine.ChangeState(player.DashAttackState);
            }
            else if (Time.time >= startTime + playerData.dashTime || isTouchingWall)
            {
                isAbilityDone = true;
                lastDashTime = Time.time;
            }
            else
            {
                player.SetVelocityX(playerData.dashSpeed * player.FacingDirection);
                player.SetVelocityY(0f);
                CheckIfShouldPlaceAfterImage();
            }
            
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
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

        public bool CanDash()
        {
            return Time.time >= lastDashTime + playerData.dashCooldown;
        }
    }
}
