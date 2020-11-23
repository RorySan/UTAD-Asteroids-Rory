using System;
using UnityEngine;


namespace Asteroids.Stats
{
    public class Score : MonoBehaviour
    {

        [SerializeField] int score;

        public event Action OnScoreIncreased;

        public void IncreaseScore(int points)
        {
            score += points;
            OnScoreIncreased();
        }

        public int GetScore()
        {
            return score;
        }
    }
}
