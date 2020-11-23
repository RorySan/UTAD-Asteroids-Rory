using UnityEngine;

namespace Asteroids.Core
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] int points;

        public int GetPoints()
        {
            return points;
        }

    }

}
