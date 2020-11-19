
using UnityEngine;
using UnityEngine.Events;

namespace Asteroids.Combat
{

    public class Projectile : MonoBehaviour
    {

        [SerializeField] GameObject instigator;
        [SerializeField] float speed;
        float damage;
        Vector3 targetVector = Vector3.right;



        [SerializeField] bool isHoming;

        [SerializeField] GameObject hitEffect;

        [SerializeField] float maxLifeTime;

        [SerializeField] float lifeAfterImpact;

        [SerializeField] UnityEvent onHit;



        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, maxLifeTime);
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(targetVector * speed * Time.deltaTime);
        }

        public void SetupProjectile(float damage, GameObject instigator)
        {
            this.damage = damage;
            this.instigator = instigator;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var isCombatTarget = collision.GetComponent<CombatTarget>();
            if (!isCombatTarget) return;
            onHit.Invoke();
            collision.GetComponent<Health>().TakeDamage(instigator, damage);
            DestroyProjectile();
        }

        private void DestroyProjectile()
        {
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            Destroy(gameObject, 1);
        }
    }

}
