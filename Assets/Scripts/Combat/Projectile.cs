
using UnityEngine;
using UnityEngine.Events;

namespace Asteroids.Combat
{

    public class Projectile : MonoBehaviour
    {

        [SerializeField] GameObject instigator;
        float speed;
        float damage;

        Vector3 targetVector = Vector3.right;

        [SerializeField] bool isHoming;
        [SerializeField] float maxLifeTime;
        [SerializeField] float lifeAfterImpact;// tiempo activo para efectos especiales
        [SerializeField] GameObject hitEffect;// efectos especiales        
        [SerializeField] UnityEvent onHit;

        private void OnEnable()
        {
            GetComponentInChildren<MeshRenderer>().enabled = true;
            Invoke(nameof(DisableImmediately), maxLifeTime);
        }

        private void OnDisable()
        {
            // evita comportamientos extraños (ie: desactivarse por maxLifeTime después de Impactar)
            CancelInvoke();
        }

        private void DisableImmediately()
        {
            gameObject.SetActive(false);
        }
        private void DisableProjectile()
        {
            GetComponentInChildren<MeshRenderer>().enabled = false;
            // mirar hacerlo con coroutine.
            Invoke(nameof(DisableImmediately), 0.5f);
        }

        void Update()
        {
            transform.Translate(targetVector * speed * Time.deltaTime);
        }

        public void SetupProjectile(float damage, float speed, GameObject instigator)
        {
            this.damage = damage;
            this.instigator = instigator;
            this.speed = speed;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(instigator.name + " has hit: " + collision.name);
            onHit.Invoke();
            //var isCombatTarget = collision.GetComponent<CombatTarget>();
            //if (!isCombatTarget) return;
            var hasHealth = collision.GetComponent<Health>();
            if (hasHealth && !hasHealth.IsDead())
                hasHealth.TakeDamage(instigator, damage);
            DisableProjectile();
        }

    }

}
