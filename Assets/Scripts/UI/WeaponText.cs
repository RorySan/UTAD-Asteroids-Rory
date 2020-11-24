using Asteroids.Combat;
using TMPro;
using UnityEngine;

public class WeaponText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Shooter shooter;

    private void Awake()
    {
        shooter = GameObject.FindWithTag("Player").GetComponent<Shooter>();
        text = GetComponent<TextMeshProUGUI>();
        shooter.OnWeaponEquipped += UpdateWeaponText;
    }
    private void Start()
    {

    }

    private void UpdateWeaponText()
    {
        text.text = shooter.GetCurrentWeapon().name;
    }

    private void OnDisable()
    {
        shooter.OnWeaponEquipped += UpdateWeaponText;
    }


}
