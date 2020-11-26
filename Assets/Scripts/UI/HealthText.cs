using Asteroids.Combat;
using TMPro;
using UnityEngine;

namespace Asteroids.UI
{
    public class HealthText : MonoBehaviour
    {
        Health health;
        TextMeshProUGUI text;

        private void Awake()
        {
            // para múltiples jugadores o jugadores de IA usaremos colecciones.
            // por ahora sólo vamos a gestionar un jugador.
            health = GameObject.FindWithTag("Player").GetComponent<Health>();
            text = GetComponent<TextMeshProUGUI>();

        }

        private void Start()
        {
            UpdateHealth();
        }

        public void UpdateHealth()
        {
            text.text = Mathf.Max(health.GetHealth(), 0).ToString();
        }

        private void OnDisable()
        {

        }
    }
}
