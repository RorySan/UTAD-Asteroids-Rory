using System;
using UnityEngine;

namespace Asteroids.Combat
{

    public class Shooter : MonoBehaviour
    {

        [SerializeField]
        WeaponConfig currentWeapon;
        [SerializeField] WeaponPlatform weaponPlatform;
        // timebetweenshots hay que moverlo a weapon platform si queremos tener varias.
        [SerializeField] float timeBetweenShots;
        float timeSinceLastShot = Mathf.Infinity;

        public event Action OnWeaponEquipped;

        Coroutine shootingCoroutine;


        // Start is called before the first frame update
        void Start()
        {
            EquipWeapon(currentWeapon);
        }

        // Update is called once per frame
        void Update()
        {
            timeSinceLastShot += Time.deltaTime;
        }

        public void EquipWeapon(WeaponConfig newWeapon)
        {
            currentWeapon = newWeapon;
            weaponPlatform.LoadWeapon(newWeapon);
            timeBetweenShots = newWeapon.GetRateOfFire();
            if (OnWeaponEquipped != null)
                OnWeaponEquipped();
        }

        public void Shoot()
        {
            if (timeSinceLastShot <= 60 / timeBetweenShots) return;
            weaponPlatform.Fire(gameObject);
            timeSinceLastShot = 0;
        }

        public WeaponConfig GetCurrentWeapon()
        {
            return currentWeapon;
        }
    }

}
