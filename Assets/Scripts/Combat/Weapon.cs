using UnityEngine;

namespace Asteroids.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Make New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {

        [SerializeField] float rateOfFire = 1f;
        [SerializeField] Projectile projectile = null;
        [SerializeField] float weaponDamage = 10f;


        const string weaponName = "Weapon";


        public void Fire(Transform weapon)
        {
            Projectile projectileInstance = Instantiate(projectile, weapon.position, Quaternion.identity);
            projectileInstance.SetTargetDirection(weapon.right, weaponDamage);
        }


    }

}
