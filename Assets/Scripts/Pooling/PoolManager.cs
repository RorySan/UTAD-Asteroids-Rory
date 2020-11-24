﻿using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Pooling
{
    public class PoolManager : MonoBehaviour
    {
        Dictionary<int, List<GameObject>> poolDictionary = new Dictionary<int, List<GameObject>>();

        static PoolManager _instance;

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

            if (!poolDictionary.ContainsKey(poolKey))
            {
                poolDictionary.Add(poolKey, new List<GameObject>());
                var parent = new GameObject();
                parent.name = prefab.name;
                parent.transform.SetParent(this.transform);

                for (int i = 0; i < poolSize; i++)
                {
                    GameObject newObject = Instantiate(prefab, parent.transform);
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
                        return pool[i];
                    }
                }

                GameObject newObject = Instantiate(prefab);
                poolDictionary[poolKey].Add(newObject);
                return newObject;
            }
            return null;
        }
    }
}
