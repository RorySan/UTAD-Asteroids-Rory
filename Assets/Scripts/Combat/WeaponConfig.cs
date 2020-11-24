using UnityEngine;

namespace Asteroids.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Make New Weapon", order = 0)]
    public class WeaponConfig : ScriptableObject
    {

        [SerializeField] float rateOfFire = 60;
        [SerializeField] Projectile projectile = null;
        [SerializeField] float weaponDamage = 10f;
        // podríamos implementar una variable rango, basada en velocidad del proyectil
        // y el tiempo de vida, para que unas armas tengan más alcance que otras.
        [SerializeField] float projectileSpeed = 10f;
        [SerializeField] AudioClip fireSound;
        [SerializeField] int poolSize = 4;


        const string weaponName = "Weapon";

        //public void Fire(Transform weaponPlatform, GameObject instigator)
        //{
        //    Projectile projectileInstance = Instantiate(projectile, weaponPlatform.position, weaponPlatform.rotation);
        //    projectileInstance.SetupProjectile(weaponDamage, instigator);

        //}

        public AudioClip GetFireSound()
        {
            return fireSound;
        }

        public GameObject GetProjectileObject()
        {
            return projectile.gameObject;
        }

        public float GetProjectileSpeed()
        {
            return projectileSpeed;
        }

        public float GetRateOfFire()
        {
            return rateOfFire;
        }

        public int GetPoolSize()
        {
            return poolSize;
        }

        public float GetWeaponDamage()
        {
            return weaponDamage;
        }


    }
}
