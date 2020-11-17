using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] float bounceForce = 150;
    Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision: " + collision.contacts[0].normal * bounceForce);
        _rigidbody.AddForce(collision.contacts[0].normal * bounceForce);
    }

}
