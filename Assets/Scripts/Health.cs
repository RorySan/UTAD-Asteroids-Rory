using UnityEngine;

namespace Asteroids.Attributes
{

    public class Health : MonoBehaviour
    {
        [SerializeField]
        float health;


        public void TakeDamage(float damage)
        {
            health -= damage;

            if (health <= 0)
            {
                //((onDie.Invoke()))
                Die();
            }
        }

        private void Die()
        {
            // animator trigger die

            Destroy(gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
