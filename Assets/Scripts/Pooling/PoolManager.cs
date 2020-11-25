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

            if (poolDictionary.ContainsKey(poolKey))
            {
                List<GameObject> pool = poolDictionary[poolKey];

                for (int i = 0; i < pool.Count; i++)
                {
                    if (!pool[i].gameObject.activeInHierarchy)
                    {
                        pool[i].SetActive(true);
                        return pool[i];
                    }
                }

                GameObject newObject = Instantiate(prefab, GetParentForPool(prefab));
                poolDictionary[poolKey].Add(newObject);

                return newObject;
            }
            return null;
        }

        private Transform GetParentForPool(GameObject prefab)
        {
            Transform parent;
            try
            {
                parent = _parents.Where(x => x.name == prefab.name).ToList()[0];
                return parent;
            }
            catch
            {
                Debug.Log("Creating new prefab for pool");
            }

            parent = new GameObject().transform;
            parent.name = prefab.name;
            parent.SetParent(this.transform);
            _parents.Add(parent);
            return parent;
        }
    }
}
