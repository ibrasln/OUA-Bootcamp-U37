using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EntityData", menuName = "Scriptable Objects/Entity Data")]
    public class D_Entity : ScriptableObject
    {
        public float wallCheckDistance = 0.3f;
        public float ledgeCheckDistance = 0.4f;

        public float maxAgroDistance = 1.3f;
        public float minAgroDistance = 0.3f;

        public LayerMask whatIsGround;
        public LayerMask whatIsPlayer;
        public LayerMask whatIsWall;
    }
}
