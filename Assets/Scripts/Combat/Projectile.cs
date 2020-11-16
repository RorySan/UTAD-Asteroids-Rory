using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{

    [SerializeField]
    float speed;
    float damage;
    Vector3 targetVector = Vector3.right;



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
        Destroy(gameObject, maxLifeTime);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(targetVector * speed * Time.deltaTime);
    }

    public void SetupProjectile(float damage)
    {
        this.damage = damage;
    }
}
