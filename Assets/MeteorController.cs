using Asteroids.Movement;
using UnityEngine;

namespace Asteroids.Control
{


    public class MeteorController : MonoBehaviour
    {
        Mover myMover;


        [SerializeField] float thrust;
        [SerializeField] float rotation;


        private void Awake()
        {
            myMover = GetComponent<Mover>();
        }
        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 6);
        }

        // Update is called once per frame
        void Update()
        {
            myMover.Move(rotation, thrust);
        }


    }
}
