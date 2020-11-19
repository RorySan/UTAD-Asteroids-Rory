using UnityEngine;
using UnityEngine.Events;

namespace Asteroids.Combat
{

    public class Health : MonoBehaviour
    {
        [SerializeField] float maxHealthPoints;
        [SerializeField] float healthPoints;
        [SerializeField] TakeDamageEvent takeDamage;
        [SerializeField] UnityEvent onDie;



        [System.Serializable]
        public class TakeDamageEvent : UnityEvent<float>
        {
        }


        public void TakeDamage(GameObject instigator, float damage)
        {
            Debug.Log(gameObject.name + "took " + damage + " damage");
            healthPoints = healthPoints - damage;
            takeDamage.Invoke(damage);

            if (healthPoints <= 0)
            {
                onDie.Invoke();
                Die();
            }
        }

        public float GetHealth()
        {
            return healthPoints;
        }

        private void Die()
        {
            // animator trigger die
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 1);
        }

    }
}
