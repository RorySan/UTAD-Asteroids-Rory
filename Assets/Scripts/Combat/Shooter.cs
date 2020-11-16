using UnityEngine;

namespace Asteroids.Combat
{

    public class Shooter : MonoBehaviour
    {

        [SerializeField]
        Weapon currentWeapon;
        [SerializeField] Transform weaponPlatform;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Shoot()
        {
            currentWeapon.Fire(weaponPlatform);
        }
    }

}
