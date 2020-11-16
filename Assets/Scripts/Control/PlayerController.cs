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
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myShooter.StartShooting(transform);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                myShooter.StopShooting();
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
