using UnityEngine;
[AddComponentMenu("Player/Player")]

public class Player : MonoBehaviour, IcanTakeDamage
{
    public int MaxHealth = 100;
    private int currentHealth;
    private bool isDead = false;
    private Animator aim;
    private int isDeadID;
    //private float timeDelay = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = MaxHealth;
        aim = GetComponentInChildren<Animator>();
        isDeadID = Animator.StringToHash("isDead");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damageAmount,Vector2 hitPoint, GameObject hitDirection){
        if(isDead) return;
        currentHealth -= damageAmount;
        if(currentHealth <= 0){
            isDead = true;
            DeadPlayer();
        }
    }
    private void DeadPlayer()
    {
        aim.SetTrigger(isDeadID);
    }
    public bool GetIsDead()
    {
        return isDead;
    }
}
