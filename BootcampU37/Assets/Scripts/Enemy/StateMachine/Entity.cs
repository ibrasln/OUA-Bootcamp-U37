using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Entity : MonoBehaviour
    {
        public FiniteStateMachine stateMachine;

        public D_Entity entityData;

        public Animator anim { get; private set; }
        public int facingDirection { get; private set; }
        public Rigidbody2D rb { get; private set; }


        //public AnimationToStatemachine atsm { get; private set; }
        public int lastDamageDirection { get; private set; }
        public GameObject aliveGO { get; private set; }

        [SerializeField]
        private Transform wallCheck;
        [SerializeField]
        private Transform ledgeCheck;
        [SerializeField]
        private Transform playerCheck;
        /*[SerializeField]
        private Transform groundCheck;*/

        private float currentHealth;
        private float currentStunResistance;
        private float lastDamageTime;

        private Vector2 velocityWorkSpace;

        protected bool isStunned;
        protected bool isDead;

        public virtual void Awake()
        {
            facingDirection = 1;
            aliveGO = transform.GetChild(0).gameObject;

            rb = aliveGO.GetComponent<Rigidbody2D>();

            //currentHealth = entityData.maxHealth;
            //currentStunResistance = entityData.stunResistance;

            anim = aliveGO.GetComponent<Animator>();
            //atsm = GetComponent<AnimationToStatemachine>();

            stateMachine = new FiniteStateMachine();
        }

        public virtual void Update()
        {
            //Core.LogicUpdate();
            stateMachine.CurrentState.LogicUpdate();

            //anim.SetFloat("yVelocity", Core.Movement.RB.velocity.y);

            //if (Time.time >= lastDamageTime + entityData.stunRecoveryTime)
            //{

            //ResetStunResistance();
            //}
        }

        public virtual void FixedUpdate()
        {
            stateMachine.CurrentState.PhysicsUpdate();

        }

        public virtual void SetVelocity(float velocity)
        {
            velocityWorkSpace.Set(facingDirection * velocity, rb.velocity.y);
            rb.velocity = velocityWorkSpace;
        }

        public virtual void Flip()
        {
            facingDirection *= -1;
            aliveGO.transform.Rotate(0, 180f, 0);
        }
        public virtual bool CheckPlayerInMinAgroRange()
        {
            return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);
        }
        public virtual bool CheckPlayerInMaxAgroRange()
        {
            return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);

        }

        //public virtual bool CheckPlayerInCloseRangeAction()
        //{
        //    return Physics2D.Raycast(playerCheck.position, transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
        //}
        public virtual bool CheckWall()
        {
            return Physics2D.Raycast(wallCheck.position, aliveGO.transform.right, entityData.wallCheckDistance, entityData.whatIsWall);
        }
        public virtual bool CheckLedge()
        {
            return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);
        }
        //public virtual void DamageHop(float velocity)
        //{
        //    velocityWorkSpace.Set(Core.Movement.RB.velocity.x, velocity);
        //    Core.Movement.RB.velocity = velocityWorkSpace;
        //}

        //public virtual void ResetStunResistance()
        //{
        //    isStunned = false;
        //    currentStunResistance = entityData.stunResistance;
        //}

        public virtual void OnDrawGizmos()
        {
            Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
            Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));

            //Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.closeRangeActionDistance), 0.2f);
            //Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.minAgroDistance), 0.2f);
            //Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.maxAgroDistance), 0.2f);
        }
	}
}