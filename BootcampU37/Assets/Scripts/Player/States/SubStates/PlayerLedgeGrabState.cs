using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerLedgeGrabState : PlayerTouchingWallState
    {
        private Vector2 startPos;
        private Vector2 cornerPos;
        private Vector2 workspace;

        public PlayerLedgeGrabState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void AnimationFinishTrigger()
        {
            base.AnimationFinishTrigger();
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
            core.Movement.SetVelocityZero();
            player.SetGravityScale(0); // change it to core.Movement.SetGravityScale(0);
            
            cornerPos = DetermineCornerPosition();
            startPos.Set(cornerPos.x - (core.Movement.FacingDirection * playerData.startOffset.x), cornerPos.y - playerData.startOffset.y);

            player.transform.position = startPos;

        }

        public override void Exit()
        {
            base.Exit();
            player.ResetGravityScale();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (yInput == -1)
            {
                stateMachine.ChangeState(player.WallSlideState);
            }
            else if (xInput == -core.Movement.FacingDirection)
            {
                stateMachine.ChangeState(player.InAirState);
            }     
        }

        public Vector2 DetermineCornerPosition()
        {
            RaycastHit2D xHit = Physics2D.Raycast(core.CollisionSenses.WallCheck.position, Vector2.right * core.Movement.FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
            float xDist = xHit.distance;
            workspace.Set((xDist + .05f) * core.Movement.FacingDirection, 0f);

            RaycastHit2D yHit = Physics2D.Raycast(core.CollisionSenses.LedgeCheckHorizontal.position + (Vector3)workspace, Vector2.down, core.CollisionSenses.LedgeCheckHorizontal.position.y - core.CollisionSenses.WallCheck.position.y, core.CollisionSenses.WhatIsGround);
            float yDist = yHit.distance;
            workspace.Set(core.CollisionSenses.WallCheck.position.x + (xDist * core.Movement.FacingDirection), core.CollisionSenses.LedgeCheckHorizontal.position.y - yDist);

            return workspace;
        }
    }
}
