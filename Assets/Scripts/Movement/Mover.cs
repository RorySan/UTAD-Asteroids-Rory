using UnityEngine;

namespace Asteroids.Movement
{

    public class Mover : MonoBehaviour
    {

        [SerializeField]
        float thrustForce = 155f;

        [SerializeField]
        float rotationSpeed = 120f;

        Rigidbody2D _rigidbody;
        Vector2 _thrustDirection;


        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Stop()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0;
        }
        public void Move(float rotation, float thrust)
        {
            _thrustDirection = transform.right;
            transform.Rotate(Vector3.forward, -rotation * rotationSpeed * Time.deltaTime);
            _rigidbody.AddForce(thrust * _thrustDirection * thrustForce * Time.deltaTime);
        }

        public void SetThrustForce(float thrust)
        {
            thrustForce = thrust;
        }

        public void SetRotationSpeed(float rotation)
        {
            rotationSpeed = rotation;
        }
    }

}
