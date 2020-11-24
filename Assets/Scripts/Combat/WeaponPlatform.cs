using Asteroids.Pooling;
using UnityEngine;

namespace Asteroids.Combat
{
    public class WeaponPlatform : MonoBehaviour
    {

        [SerializeField] GameObject projectilePrefab;
        [SerializeField] WeaponConfig weaponConfig;
        [SerializeField] AudioClip fireSound;
        [SerializeField] AudioSource audioSource;

        public void Fire(GameObject instigator)
        {
            var projectile = PoolManager.instance.Spawn(projectilePrefab);
            projectile.GetComponent<Projectile>().SetupProjectile(weaponConfig.GetWeaponDamage(), weaponConfig.GetProjectileSpeed(), instigator);
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
            projectile.SetActive(true);
            audioSource.PlayOneShot(fireSound);
        }

        public void LoadWeapon(WeaponConfig weaponConfig)
        {
            this.weaponConfig = weaponConfig;
            projectilePrefab = weaponConfig.GetProjectileObject();
            fireSound = weaponConfig.GetFireSound();
            PoolManager.instance.CreatePool(projectilePrefab, weaponConfig.GetPoolSize());
        }
    }
}
