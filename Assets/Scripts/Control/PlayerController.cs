using Asteroids.Combat;
using Asteroids.Movement;
using UnityEngine;

namespace Asteroids.Control
{
    public class PlayerController : MonoBehaviour
    {
        Mover myMover;
        Shooter myShooter;

        private void Awake()
        {
            myMover = GetComponent<Mover>();
            myShooter = GetComponent<Shooter>();
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                myShooter.Shoot();
            }
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            float rotation = Input.GetAxis("Rotation");
            float thrust = Input.GetAxis("Thrust");
            myMover.Move(rotation, thrust);
        }
    }

}
