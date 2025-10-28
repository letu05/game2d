using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 25;
    public GameObject fxPrefab;
    public float TimeToDestroy = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, TimeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            IcanTakeDamage enemyTakeDamage = collision.GetComponent<IcanTakeDamage>();
            Instantiate(fxPrefab, transform.position, Quaternion.identity);
            if (enemyTakeDamage != null)
            {
                enemyTakeDamage.TakeDamage(damage, Vector2.zero, gameObject);

            }
            Destroy(gameObject);
        }
    }
}
