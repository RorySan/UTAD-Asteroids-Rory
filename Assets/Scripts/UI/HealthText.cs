using Asteroids.Combat;
using TMPro;
using UnityEngine;

namespace Asteroids.UI
{
    public class HealthText : MonoBehaviour
    {
        Health health;
        TextMeshProUGUI text;

        private void Start()
        {
            // para múltiples jugadores o jugadores de IA, cambiaremos score y text a listas
            // por ahora sólo vamos a gestionar un jugador.
            health = GameObject.FindWithTag("Player").GetComponent<Health>();
            text = GetComponent<TextMeshProUGUI>();
            UpdateHealth();
        }

        public void UpdateHealth()
        {
            text.text = health.GetHealth().ToString();
        }





    }
}
