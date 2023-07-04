using UnityEngine;

namespace Boss
{
    public class BossEntity : MonoBehaviour
    {
        public FiniteStateMachine stateMachine;

        public Animator Anim { get; private set; }
        public Core Core { get; private set; }

        private float currentHealth;

        protected bool isDead;

        public virtual void Awake()
        {
            Core = GetComponentInChildren<Core>();
            Anim = GetComponent<Animator>();

            stateMachine = new FiniteStateMachine();
            //currentHealth = bossData.maxHealth;
        }

        private void Update()
        {
            Core.LogicUpdate();
            stateMachine.CurrentState.LogicUpdate();

            Anim.SetFloat("yVelocity", Core.Movement.CurrentVelocity.y);
        }

        public virtual void FixedUpdate()
        {
            stateMachine.CurrentState.PhysicsUpdate();
        }

        //public virtual bool CheckPlayerInMinAgroRange()
        //{
        //    return Physics2D.Raycast(playerCheck.position, transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);
        //}

        //public virtual bool CheckPlayerInMaxAgroRange()
        //{
        //    return Physics2D.Raycast(playerCheck.position, transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
        //}

        //public virtual bool CheckPlayerInCloseRangeAction()
        //{
        //    return Physics2D.Raycast(playerCheck.position, transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
        //}
    }
}
