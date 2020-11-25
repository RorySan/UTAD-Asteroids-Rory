using UnityEngine;


namespace Asteroids.Core
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] int score;

        public int GetScore()
        {
            return score;
        }

        public void ScorePoints(int points)
        {
            score += points;
        }

        void Start()
        {

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

        void Update()
        {

        }
    }
}
