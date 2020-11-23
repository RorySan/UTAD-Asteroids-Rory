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


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
