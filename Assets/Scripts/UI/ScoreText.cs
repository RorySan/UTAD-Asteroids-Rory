using Asteroids.Stats;
using TMPro;
using UnityEngine;

namespace Asteroids.UI
{
    public class ScoreText : MonoBehaviour
    {

        Score score;
        TextMeshProUGUI text;


        private void Start()
        {
            // para múltiples jugadores o jugadores de IA, cambiaremos score y text a listas
            // por ahora sólo vamos a gestionar un jugador.
            score = FindObjectOfType<Score>();
            text = GetComponent<TextMeshProUGUI>();
            UpdateScore();
            score.OnScoreIncreased += UpdateScore;
        }

        private void UpdateScore()
        {
            text.text = score.GetScore().ToString();
        }

        private void OnDisable()
        {
            score.OnScoreIncreased -= UpdateScore;
        }



    }
}
