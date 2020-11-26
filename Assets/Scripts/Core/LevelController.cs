using Asteroids.Combat;
using Asteroids.SceneManagement;
using UnityEngine;


namespace Asteroids.Core
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] int score;
        [SerializeField] SceneLoader sceneLoader;
        Health playerHealth;

        private void Awake()
        {
            sceneLoader = FindObjectOfType<SceneLoader>();
        }

        public int GetScore()
        {
            return score;
        }

        public void OnPlayerDeath()
        {

            StopSpawners();
            sceneLoader.LoadGameOver();
        }

        public void ScorePoints(int points)
        {
            score += points;
        }

        public void ResetGame()
        {

        }

        public void StopSpawners()
        {
            Debug.Log("Stopping spawners");
            EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();
            foreach (EnemySpawner spawner in spawners)
            {
                spawner.StopSpawning();
            }
        }

    }
}
