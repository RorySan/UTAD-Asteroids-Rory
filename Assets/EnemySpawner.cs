using Asteroids.Core;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    bool spawn = true;

    LevelController levelController;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 3f;

    [SerializeField] Enemy[] enemyList;



    // Start is called before the first frame update
    IEnumerator Start()
    {
        levelController = FindObjectOfType<LevelController>();
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
        var rand = Random.Range(-13, 11.5f);
        var spawnPosition = new Vector2(rand, transform.position.y);
        Enemy newEnemy = Instantiate(enemy, spawnPosition, transform.rotation);


    }


    public void StopSpawning()
    {
        spawn = false;
    }
}
