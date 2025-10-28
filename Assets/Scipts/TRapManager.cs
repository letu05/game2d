using UnityEngine;

public class TRapManager : MonoBehaviour
{
    public int damage = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            IcanTakeDamage playertakedamage = collision.GetComponent<IcanTakeDamage>();
            if(playertakedamage != null)
            {
                playertakedamage.TakeDamage(damage,Vector2.zero,gameObject);
            }
        }
    }
}
