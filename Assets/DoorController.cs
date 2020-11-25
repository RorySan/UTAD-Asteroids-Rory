using UnityEngine;

public class DoorController : MonoBehaviour
{

    [SerializeField]

    public void OpenDoor()
    {
        Destroy(gameObject);
    }
}
