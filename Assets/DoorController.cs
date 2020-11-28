using Asteroids.Combat;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Health[] Enemies;
    int keyEnemies = 0;

    private void Start()
    {
        foreach (Health enemy in Enemies)
        {
            enemy.onDie.AddListener(OpenDoor);
            keyEnemies++;
        }
    }
    public void OpenDoor()
    {
        bool areAllEnemiesDead = --keyEnemies > 0;
        if (areAllEnemiesDead) return;
        Destroy(gameObject);
    }
}
