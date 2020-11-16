using System.Collections;
using UnityEngine;

namespace Asteroids.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Make New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {

        [SerializeField] float rateOfFire = 60f;
        [SerializeField] Projectile projectile = null;
        [SerializeField] float weaponDamage = 10f;


        const string weaponName = "Weapon";


        public void Fire(Transform weaponPlatform, Transform instigator)
        {
            Projectile projectileInstance = Instantiate(projectile, weaponPlatform.position, weaponPlatform.rotation);
            projectileInstance.SetupProjectile(weaponDamage);
        }

        public IEnumerator FireContinously(Transform weaponPlatform, Transform instigator)
        {
            while (true)
            {
                Projectile projectileInstance = Instantiate(projectile, weaponPlatform.position, weaponPlatform.rotation);
                projectileInstance.SetupProjectile(weaponDamage);
                yield return new WaitForSeconds(60 / rateOfFire);
            }
        }


    }
}
