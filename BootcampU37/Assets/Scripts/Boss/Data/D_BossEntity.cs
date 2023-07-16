using UnityEngine;

namespace Boss
{
    [CreateAssetMenu(fileName = "BossEntityData", menuName = "Scriptable Objects/Boss Entity Data")]
    public class D_BossEntity : ScriptableObject
    {
        public float wallCheckDistance = 0.3f;
        public float ledgeCheckDistance = 0.4f;
        public float maxAgroDistance = 4f;
        public float minAgroDistance = 0.3f;
        public float closeRangeActionDistance = 1f;

        public LayerMask whatIsGround;
        public LayerMask whatIsPlayer;
    }
}
