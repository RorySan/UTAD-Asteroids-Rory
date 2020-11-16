using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{

    [SerializeField]
    float speed;
    float damage;
    Vector3 targetDirection;

    [SerializeField]
    bool isHoming;

    [SerializeField]
    GameObject hitEffect;

    [SerializeField]
    float maxLifeTime;

    [SerializeField]
    float lifeAfterImpact;

    [SerializeField]
    UnityEvent onHit;



    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(0, 0, 90));
        Destroy(gameObject, maxLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(targetDirection * speed * Time.deltaTime);
    }



    public void SetTargetDirection(Vector3 targetDirection, float damage)
    {
        this.damage = damage;
        this.targetDirection = targetDirection;
    }
}
