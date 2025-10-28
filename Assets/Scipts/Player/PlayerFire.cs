using UnityEngine;
[AddComponentMenu("Player/PlayerFire")]
public class PlayerFire : MonoBehaviour
{
    [Header ("Bullet Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    private PlayerController playerController;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (playerController.FaceRight())
        {
            rb.linearVelocity = Vector2.right * bulletSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.left * bulletSpeed;
        }
        
    }
}
