using UnityEngine;

namespace Asteroids.Combat
{

    public class Shooter : MonoBehaviour
    {

        [SerializeField]
        Weapon currentWeapon;
        [SerializeField] Transform weaponPlatform;

        Coroutine shootingCoroutine;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeWeapon(Weapon newWeapon)
        {
            currentWeapon = newWeapon;
        }

        public void StartShooting(Transform instigator)
        {
            shootingCoroutine = StartCoroutine(currentWeapon.FireContinously(transform, instigator));
        }
        public void StopShooting()
        {
            StopCoroutine(shootingCoroutine);
        }
    }

}
