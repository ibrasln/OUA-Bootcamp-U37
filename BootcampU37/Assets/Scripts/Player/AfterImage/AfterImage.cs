using UnityEngine;

namespace Platformer.Player
{
    public class AfterImage : MonoBehaviour
    {
        private SpriteRenderer sr;
        private Transform player;
        private SpriteRenderer playerSR;

        private float timeActivated;
        private float alpha;
        [SerializeField] private float activeTime;
        [SerializeField] private float alphaSet;
        [SerializeField] private float alphaDecay;

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
            playerSR = player.GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            transform.SetPositionAndRotation(player.position, player.rotation);
            timeActivated = Time.time;
            alpha = alphaSet;
            sr.sprite = playerSR.sprite;
        }

        private void Update()
        {
            alpha -= alphaDecay * Time.deltaTime;
            sr.color = new(1, 1, 1, alpha);
            
            if (Time.time >= timeActivated + activeTime)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
