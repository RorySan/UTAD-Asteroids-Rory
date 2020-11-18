using UnityEngine;

namespace Asteroids.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Make New Weapon", order = 0)]
    public class WeaponConfig : ScriptableObject
    {

        [SerializeField] float rateOfFire = 60;
        [SerializeField] bool canShoot = true;
        [SerializeField] Projectile projectile = null;
        [SerializeField] float weaponDamage = 10f;
        [SerializeField] float nextShot;


        private void OnEnable()
        {
            nextShot = Time.deltaTime;
        }
        const string weaponName = "Weapon";



        public void Fire(Transform weaponPlatform, GameObject instigator)
        {
            Projectile projectileInstance = Instantiate(projectile, weaponPlatform.position, weaponPlatform.rotation);
            projectileInstance.SetupProjectile(weaponDamage, instigator);


        }

        public float GetRateOfFire()
        {
            return rateOfFire;
        }


    }
}
