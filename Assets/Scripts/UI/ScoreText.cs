using TMPro;
using UnityEngine;

namespace Asteroids.UI
{
    public class ScoreText : MonoBehaviour
    {

        //Score score;
        TextMeshProUGUI text;


        private void Start()
        {
            // para múltiples jugadores o jugadores de IA, usaríamos colecciones.
            // por ahora sólo vamos a gestionar un jugador.
            //score = FindObjectOfType<Score>();
            text = GetComponent<TextMeshProUGUI>();
            UpdateScore(0);
            //score.OnScoreIncreased += UpdateScore;
        }

        public void UpdateScore(int score)
        {
            text.text = score.ToString();

        }

        private void OnDisable()
        {
            //score.OnScoreIncreased -= UpdateScore;
        }



    }
}
