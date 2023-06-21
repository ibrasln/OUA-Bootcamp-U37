using UnityEngine;

namespace Platformer.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/Player Data")]
    public class PlayerDataSO : ScriptableObject
    {
        [Header("MOVEMENT")]
        public float moveSpeed = 10f;
        public float moveSpeedInAir = 7.5f;

        [Space(6)]
        [Header("JUMP")]
        public float jumpPower = 10f;
        public int jumpAmount = 2;

        [Space(6)]
        [Header("IN AIR")]
        public float coyoteTime = .2f;

        [Space(6)]
        [Header("SLIDE")]
        public float slideSpeed = 20f;
        public float slideCooldown = 1f;
        public float slideTime = .3f;

        [Space(6)]
        [Header("DASH")]
        public float dashSpeed = 25f;
        public float dashCooldown = 1f;
        public float dashTime = .3f;
        
        [Space(6)]
        [Header("GROUND")]
        public float groundCheckRadius = .3f;
        public LayerMask whatIsGround;

        [Space(6)]
        [Header("WALL")]
        public float wallCheckDistance = .5f;

        [Space(6)]
        [Header("LEDGE GRAB")]
        public Vector2 startOffset;

        [Space(6)]
        [Header("LADDER")]
        public float ladderCheckRadius = .5f;
        public float ladderClimbSpeed = 7f;
        public LayerMask whatIsLadder;

        [Space(6)]
        [Header("WALL SLIDE")]
        public float wallSlideSpeed = -5f;

        [Space(6)]
        [Header("AFTER IMAGE")]
        public GameObject afterImagePrefab;
        public float distanceBetweenAfterImages = 1f;

        [Space(6)]
        [Header("ATTACK")]
        public int attackAmount = 2;
        public float attackMovementSpeed = 2.5f;
        public float dashAttackMovementSpeed = 10f;
    }
}
