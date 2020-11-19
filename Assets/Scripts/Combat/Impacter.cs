
using UnityEngine;

namespace Asteroids.Combat
{
    public class Impacter : MonoBehaviour
    {
        [SerializeField] float impactDamage = 500;


        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(gameObject, impactDamage);

        }

    }
}
