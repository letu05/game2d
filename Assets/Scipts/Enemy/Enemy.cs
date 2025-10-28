using UnityEngine;

public class Enemy : MonoBehaviour, IcanTakeDamage
{
    [Header("Enemy Settings")]
    public float health = 100f;
    public float currentHealth;
    private bool isDead = false;
    private Rigidbody2D rb;
    private float timeDestroy = 0.2f;
    private float nextAttackTime;
    public int damagePlayer = 20;
    private EnemyAl enemyAl;
    public void TakeDamage(int damageAmount, Vector2 hitPoint, GameObject hitDirection)
    {
        if (isDead) return;
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            isDead = true;
            Die();
        }
    }
    private void Die()
    {
        rb.linearVelocity = Vector2.zero;
        // Handle enemy death (e.g., play animation, drop loot, etc.)
        enemyAl.enabled = false;
        Destroy(gameObject, timeDestroy);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        currentHealth = health;
        rb = GetComponent<Rigidbody2D>();
        enemyAl = GetComponent<EnemyAl>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Player>().GetIsDead() == false)
            {
                collision.GetComponent<Player>().TakeDamage(20, transform.position, gameObject);
                if (Time.time >= nextAttackTime)
                {
                    nextAttackTime = Time.time + 1f;
                    IcanTakeDamage damageable = collision.GetComponent<IcanTakeDamage>();
                    if (damageable != null)
                    {
                        damageable.TakeDamage(damagePlayer, Vector2.right, gameObject);
                    }
                }
            }
        }
    }
}
