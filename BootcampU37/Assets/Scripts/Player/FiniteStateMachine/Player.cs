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
        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public Animator Anim { get; private set; }
        public Rigidbody2D RB { get; private set; }

        public PlayerDataSO playerData;
        #endregion

        #region OTHER VARIABLES
        public Vector2 CurrentVelocity { get; private set; }
        public int FacingDirection { get; private set; }
        
        private Vector2 workspace;
        #endregion

        #region CHECK VARIABLES
        [SerializeField] private Transform groundCheckPosition;
        [SerializeField] private Transform wallCheckPosition;
        [SerializeField] private Transform ladderCheckPosition;
        [SerializeField] private Transform ledgeCheckPosition;
        [SerializeField] private Transform feetWallCheckPosition;
        [SerializeField] private Transform ceilingCheckPosition;
        #endregion

        #region UNITY CALLBACK FUNCTIONS
        private void Awake()
        {
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
            FacingDirection = 1;
        }

        private void Update()
        {
            CurrentVelocity = RB.velocity;
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }
        #endregion

        #region SET FUNCTIONS
        public void SetVelocityX(float xVelocity)
        {
            workspace.Set(xVelocity, RB.velocity.y);
            RB.velocity = workspace;
        }

        public void SetVelocityY(float yVelocity)
        {
            workspace.Set(RB.velocity.x, yVelocity);
            RB.velocity = workspace;
        }

        public void SetVelocityZero()
        {
            workspace.Set(0f, 0f);
            RB.velocity = workspace;
        }

        public void SetGravityScale(int scale)
        {
            RB.gravityScale = scale;
        }
        public void ResetGravityScale()
        {
            RB.gravityScale = 4;
        }
        #endregion

        #region CHECK FUNCTIONS
        public bool CheckOnGround()
        {
            return Physics2D.OverlapCircle(groundCheckPosition.position, playerData.groundCheckRadius, playerData.whatIsGround);
        }

        public bool CheckIsTouchingWall()
        {
            return Physics2D.Raycast(wallCheckPosition.position, Vector2.right * FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
        }

        public bool CheckIsFeetTouchingWall()
        {
            return Physics2D.Raycast(feetWallCheckPosition.position, Vector2.right * FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
        }

        private bool CheckIsLedgeDetected()
        {
            return !Physics2D.Raycast(ledgeCheckPosition.position, Vector2.right * FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
        }

        public bool CheckCanGrab()
        {
            return CheckIsTouchingWall() && CheckIsLedgeDetected();
        }

        public bool CheckIsTouchingLadder()
        {
            return Physics2D.OverlapCircle(ladderCheckPosition.position, playerData.ladderCheckRadius, playerData.whatIsLadder);
        }

        public bool CheckIsTouchingCeiling()
        {
            return true; //TODO: DONT FORGET TO COMPLETE IT
        }

        public void CheckIfShouldFlip(int xInput)
        {
            if (xInput != 0 && xInput != FacingDirection)
                Flip();
        }
        #endregion

        #region OTHER FUNCTIONS
        private void Flip()
        {
            FacingDirection *= -1;
            transform.Rotate(0.0f, 180.0f, 0f);
        }

        public Vector2 DetermineCornerPosition()
        {
            RaycastHit2D xHit = Physics2D.Raycast(wallCheckPosition.position, Vector2.right * FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
            float xDist = xHit.distance;
            workspace.Set((xDist + .05f) * FacingDirection, 0f);

            RaycastHit2D yHit = Physics2D.Raycast(ledgeCheckPosition.position + (Vector3)workspace, Vector2.down, ledgeCheckPosition.position.y - wallCheckPosition.position.y, playerData.whatIsGround);
            float yDist = yHit.distance;
            workspace.Set(wallCheckPosition.position.x + (xDist * FacingDirection), ledgeCheckPosition.position.y - yDist);

            return workspace;
        }

        #endregion

        #region ANIMATION TRIGGERS
        public void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
        public void AnimaionStartMovementTrigger() => StateMachine.CurrentState.AnimationStartMovementTrigger();
        public void AnimationStopMovementTrigger() => StateMachine.CurrentState.AnimationStopMovementTrigger();
        #endregion

        #region Gizmos
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(groundCheckPosition.position, playerData.groundCheckRadius);
            Gizmos.DrawRay(wallCheckPosition.position, FacingDirection * playerData.wallCheckDistance * Vector2.right);
            Gizmos.DrawRay(feetWallCheckPosition.position, FacingDirection * playerData.wallCheckDistance * Vector2.right);
            Gizmos.DrawRay(ledgeCheckPosition.position, FacingDirection * playerData.wallCheckDistance * Vector2.right);
            Gizmos.DrawWireSphere(ladderCheckPosition.position, playerData.ladderCheckRadius);
        }
        #endregion
    }
}
