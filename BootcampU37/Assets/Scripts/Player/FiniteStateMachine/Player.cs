using UnityEngine;

namespace Platformer.Player
{
    public class Player : MonoBehaviour
    {
        #region STATES
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerCrouchState CrouchState { get; private set; }
        public PlayerSlideState SlideState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerDashState DashState { get; private set; }
        public PlayerWallSlideState WallSlideState { get; private set; }
        public PlayerLedgeGrabState LedgeGrabState { get; private set; }
        public PlayerLadderClimbState LadderClimbState { get; private set; }
        public PlayerAttackState AttackState { get; private set; }
        public PlayerDashAttackState DashAttackState { get; private set; }
        #endregion

        #region COMPONENTS
        public Core Core { get; private set; } 
        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public Animator Anim { get; private set; }
        public Rigidbody2D RB { get; private set; }

        public PlayerDataSO playerData;
        #endregion

        #region UNITY CALLBACK FUNCTIONS
        private void Awake()
        {
            Core = GetComponentInChildren<Core>();
            StateMachine = new();
            
            InputHandler = GetComponent<PlayerInputHandler>();
            Anim = GetComponent<Animator>();
            RB = GetComponent<Rigidbody2D>();

            IdleState = new(this, StateMachine, playerData, "idle");
            MoveState = new(this, StateMachine, playerData, "move");
            CrouchState = new(this, StateMachine, playerData, "crouch");
            SlideState = new(this, StateMachine, playerData, "slide");
            JumpState = new(this, StateMachine, playerData, "inAir");
            InAirState = new(this, StateMachine, playerData, "inAir");
            DashState = new(this, StateMachine, playerData, "dash");
            WallSlideState = new(this, StateMachine, playerData, "wallSlide");
            LedgeGrabState = new(this, StateMachine, playerData, "ledgeGrab");
            LadderClimbState = new(this, StateMachine, playerData, "ladderClimb");
            AttackState = new(this, StateMachine, playerData, "attack");
            DashAttackState = new(this, StateMachine, playerData, "dashAttack");
        }

        private void Start()
        {
            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }
        #endregion

        #region SET FUNCTIONS
        public void SetGravityScale(int scale)
        {
            RB.gravityScale = scale;
        }
        public void ResetGravityScale()
        {
            RB.gravityScale = 4;
        }
        #endregion

        #region ANIMATION TRIGGERS
        public void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
        public void AnimaionStartMovementTrigger() => StateMachine.CurrentState.AnimationStartMovementTrigger();
        public void AnimationStopMovementTrigger() => StateMachine.CurrentState.AnimationStopMovementTrigger();
        #endregion
    }
}
