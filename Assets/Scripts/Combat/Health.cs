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
        [SerializeField] public UnityEvent onDie;
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
                Debug.Log(gameObject.name + "is dead");
                onDie.Invoke();
                GiveReward(instigator);
                Die();
            }
        }

        private void GiveReward(GameObject instigator)
        {
            var instigatorScore = instigator.GetComponent<ScoreKeeper>();
            if (!instigatorScore) return;
            instigatorScore.IncreaseScore(GetComponent<Enemy>().GetPoints());
        }

        public float GetHealth()
        {
            return healthPoints;
        }

        private void Die()
        {
            isDead = true;
            // animator trigger die si añadimos animaciones
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Invoke(nameof(DisableImmediately), 0.5f); // tiempo para fx;
        }

        private void OnEnable()
        {
            ResetGameobject();
        }

        private void ResetGameobject()
        {
            GetComponentInChildren<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            healthPoints = maxHealthPoints;
            isDead = false;
        }

        private void DisableImmediately()
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            CancelInvoke();
        }

        public bool IsDead()
        {
            return isDead;
        }

    }
}
