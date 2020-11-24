using Asteroids.Combat;
using Asteroids.Movement;
using UnityEngine;

namespace Asteroids.Control
{
    public class AIController : MonoBehaviour
    {

        GameObject player;
        Shooter AIShooter;
        Health AIHealth;
        Mover AIMover;

        [SerializeField] float aggroDistance = 8f;
        [SerializeField] float rotationSpeed = 3f;

        public int interpolationFramesCount = 45; // Number of frames to completely interpolate between the 2 positions
        int elapsedFrames = 0;

        private void Awake()
        {
            player = GameObject.FindWithTag("Player");
            AIShooter = GetComponent<Shooter>();
            AIHealth = GetComponent<Health>();
            AIMover = GetComponent<Mover>();
        }

        void Update()
        {
            if (AIHealth.IsDead()) return;
            if (IsAggrevated())
                AttackBehaviour();
        }

        private void AttackBehaviour()
        {
            FaceTarget();
            if (Vector3.Distance(transform.position, player.transform.position) < 5)
                AIMover.Move(0, -0.7f);
            else
                AIMover.Move(0, 0.7f);

            AIShooter.Shoot();
            Slide();
        }

        private void FaceTarget()
        {
            Vector3 vectorToTarget = player.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5);
        }

        private bool IsAggrevated()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            return distanceToPlayer <= aggroDistance;
        }

        private void Slide()
        {
            Debug.Log("vector to target: " + (player.transform.position - transform.position));
            var vector = player.transform.position - transform.position;
            if (vector.y < 0)
                transform.Translate(-transform.up * Time.deltaTime * 2);
            else
                transform.Translate(transform.up * Time.deltaTime * 2);
        }
    }

}
