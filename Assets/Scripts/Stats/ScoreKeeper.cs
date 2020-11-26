using UnityEngine;
using UnityEngine.Events;

namespace Asteroids.Stats
{
    public class ScoreKeeper : MonoBehaviour
    {
        [SerializeField] int score;

        [SerializeField] ScoreChangedEvent OnScoreChange;

        [System.Serializable]
        public class ScoreChangedEvent : UnityEvent<int>
        {
        }

        public void IncreaseScore(int points)
        {
            score += points;
            OnScoreChange.Invoke(score);
        }
    }
}
