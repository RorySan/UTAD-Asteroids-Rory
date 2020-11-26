
using UnityEngine;

namespace Asteroids.Combat
{
    public class Impacter : MonoBehaviour
    {
        [SerializeField] float impactDamage = 500;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var health = collision.gameObject.GetComponent<Health>();

            if (!health || health.IsDead()) return;
            health.TakeDamage(gameObject, impactDamage);
        }
    }
}
