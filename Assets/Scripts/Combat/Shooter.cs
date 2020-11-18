using UnityEngine;

namespace Asteroids.Combat
{

    public class Shooter : MonoBehaviour
    {

        [SerializeField]
        WeaponConfig currentWeapon;
        [SerializeField] Transform weaponPlatform;
        [SerializeField] float timeBetweenShots;
        float timeSinceLastShot = Mathf.Infinity;

        Coroutine shootingCoroutine;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            timeSinceLastShot += Time.deltaTime;
        }

        public void ChangeWeapon(WeaponConfig newWeapon)
        {
            currentWeapon = newWeapon;
        }

        public void Shoot()
        {
            if (timeSinceLastShot <= 60 / currentWeapon.GetRateOfFire()) return;
            currentWeapon.Fire(weaponPlatform, gameObject);
            timeSinceLastShot = 0;
        }
    }

}
