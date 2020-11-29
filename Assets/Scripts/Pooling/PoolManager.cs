using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroids.Pooling
{
    public class PoolManager : MonoBehaviour
    {
        Dictionary<int, List<GameObject>> poolDictionary = new Dictionary<int, List<GameObject>>();
        static PoolManager _instance;
        List<Transform> _parents;

        public static PoolManager instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<PoolManager>();
                }
                return _instance;
            }
        }

        public void CreatePool(GameObject prefab, int poolSize)
        {
            int poolKey = prefab.GetInstanceID();
            if (_parents == null)
                _parents = new List<Transform>();

            if (!poolDictionary.ContainsKey(poolKey))
            {
                poolDictionary.Add(poolKey, new List<GameObject>());

                for (int i = 0; i < poolSize; i++)
                {
                    GameObject newObject = Instantiate(prefab, GetParentForPool(prefab));
                    poolDictionary[poolKey].Add(newObject);
                    newObject.SetActive(false);
                }
            }
        }

        public GameObject Spawn(GameObject prefab)
        {
            int poolKey = prefab.GetInstanceID();

            if (!poolDictionary.ContainsKey(poolKey)) return null;
            List<GameObject> pool = poolDictionary[poolKey];

            var pooledObject = pool.FirstOrDefault(x => !x.gameObject.activeInHierarchy);

            if (pooledObject == null)
            {
                pooledObject = Instantiate(prefab, GetParentForPool(prefab));
                poolDictionary[poolKey].Add(pooledObject);
            }

            pooledObject.SetActive(true);
            return pooledObject;
        }

        private Transform GetParentForPool(GameObject prefab)
        {
            Transform parent = _parents.FirstOrDefault(x => x.name == prefab.name);
            if (parent == null)
                parent = CreateParentForPool(prefab);
            return parent;
        }

        private Transform CreateParentForPool(GameObject prefab)
        {
            Transform parent = new GameObject().transform;
            parent.name = prefab.name;
            parent.SetParent(this.transform);
            _parents.Add(parent);
            return parent;
        }
    }
}
