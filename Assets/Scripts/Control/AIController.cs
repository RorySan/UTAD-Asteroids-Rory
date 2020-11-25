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

        [SerializeField] float aggroDistance = 9f;
        [SerializeField] float backoffDistance = 4f;
        [SerializeField] float facingSpeed = 8f;
        [SerializeField] float slideSpeed = 1f;
        [SerializeField] float thrust = 1f;
        [SerializeField] float rotation = 3f;


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

            if (HasAggro())
                AttackBehaviour();
        }

        private void AttackBehaviour()
        {
            //FaceTarget();
            transform.LookAt(player.transform.position);
            transform.Rotate(0, -90, 0);

            //transform.rotation = Quaternion.Euler(new Vector3(0, 0, player.transform.rotation.z));
            if (DistanceToPlayer() < backoffDistance)
                AIMover.Move(thrust, -rotation);

            else// (DistanceToPlayer() < 3)
                AIMover.Move(-thrust, rotation);
            //Slide();
            AIShooter.Shoot();
        }

        private void MovementBehaviour()
        {

        }

        private void FaceTarget()
        {
            Vector3 vectorToTarget = player.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * facingSpeed);
        }
        private float DistanceToPlayer()
        {
            return Vector3.Distance(transform.position, player.transform.position);
        }

        private bool HasAggro()
        {
            return DistanceToPlayer() <= aggroDistance;
        }

        private void Slide()
        {
            //Debug.Log("vector to target: " + (player.transform.position - transform.position));
            var vector = player.transform.position - transform.position;
            if (vector.y < 0)
                transform.Translate(-transform.up * Time.deltaTime * 2);
            else
                transform.Translate(transform.up * Time.deltaTime * 2);
        }
    }

}
