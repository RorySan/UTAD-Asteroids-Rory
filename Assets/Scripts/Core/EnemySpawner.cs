using Asteroids.Pooling;
using System.Collections;
using UnityEngine;

namespace Asteroids.Core
{

    public class EnemySpawner : MonoBehaviour
    {
        bool spawn = true;

        LevelController levelController;
        [SerializeField] float minSpawnDelay = 1f;
        [SerializeField] float maxSpawnDelay = 3f;
        [SerializeField] int poolSize = 30;

        [SerializeField] float spawnAngle;

        [SerializeField] Transform gate1;
        [SerializeField] Transform gate2;

        [SerializeField] Enemy[] enemyList;

        // Start is called before the first frame update
        IEnumerator Start()
        {
            levelController = FindObjectOfType<LevelController>();
            foreach (Enemy enemy in enemyList)
            {
                PoolManager.instance.CreatePool(enemy.gameObject, poolSize);
            }

            while (spawn)
            {
                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                SpawnEnemy();
            }
        }

        void SpawnEnemy()
        {
            int enemyIndex = Random.Range(0, enemyList.Length);
            Enemy enemy = enemyList[enemyIndex];
            Spawn(enemy);
        }

        private void Spawn(Enemy enemy)
        {
            Vector3 position = CalculateRandomPosition();
            Quaternion angle = CalculateRandomAngle();

            //Enemy newEnemy = Instantiate(enemy, position, angle);
            var newEnemy = PoolManager.instance.Spawn(enemy.gameObject);
            newEnemy.transform.position = position;
            newEnemy.transform.rotation = angle;
            newEnemy.SetActive(true);
        }

        private Vector3 CalculateRandomPosition()
        {
            Vector3 spawnRange = gate2.position - gate1.position;
            Vector3 position = gate1.position + Random.value * spawnRange;
            return position;
        }

        private Quaternion CalculateRandomAngle()
        {
            var zAxis = Random.Range(transform.rotation.eulerAngles.z + spawnAngle, transform.rotation.eulerAngles.z - spawnAngle);
            return Quaternion.Euler(new Vector3(0, 0, zAxis));
        }

        public void StopSpawning()
        {
            spawn = false;
        }
    }

}
