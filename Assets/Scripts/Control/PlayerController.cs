using Asteroids.Movement;
using UnityEngine;

namespace Asteroids.Control
{

    public class PlayerController : MonoBehaviour
    {
        Mover myMover;

        private void Awake()
        {
            myMover = GetComponent<Mover>();
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

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
