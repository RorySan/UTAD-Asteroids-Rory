using Asteroids.Core;
using Asteroids.Stats;
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
        [SerializeField] bool isDead;

        [System.Serializable]
        public class TakeDamageEvent : UnityEvent<float>
        {
        }


        public void TakeDamage(GameObject instigator, float damage)
        {
            if (isDead) return;
            Debug.Log(gameObject.name + " took " + damage + " damage");
            healthPoints -= damage;
            takeDamage.Invoke(damage);

            if (healthPoints <= 0)
            {
                onDie.Invoke();
                GiveReward(instigator);
                Die();
            }
        }

        private void GiveReward(GameObject instigator)
        {
            var score = instigator.GetComponent<Score>();
            if (!score) return;
            score.IncreaseScore(GetComponent<Enemy>().GetPoints());
        }


        public float GetHealth()
        {
            return healthPoints;
        }

        private void Die()
        {
            isDead = true;
            // animator trigger die
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 1);
        }

        public bool IsDead()
        {
            return isDead;
        }

    }
}
