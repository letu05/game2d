using UnityEngine;
using System.Collections;
[AddComponentMenu("Player/PlayerAttack")]

public class PlayerAttack : MonoBehaviour
{
    public float radius = 0.5f;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float nextAttackTime = 0.2f;
    public float timeDelay = 0.5f;
    public LayerMask enemyLayer;
    public int damageToGive = 10;
    private Animator animator;
    private int isAttackAnimationId;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        isAttackAnimationId = Animator.StringToHash("isAttack");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger(isAttackAnimationId);
            GetKeyR();
        }
    }
    private bool GetKeyR(){
        if(Time.time >= nextAttackTime){
            nextAttackTime = Time.time + timeDelay;
            StartCoroutine(Attack());
            return true;
        }
        return false;
        }
    

IEnumerator Attack(){
    
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        for(int i = 0; i < hitEnemies.Length; i++){
            hitEnemies[i].GetComponent<IcanTakeDamage>().TakeDamage(damageToGive, attackPoint.position, gameObject);
        }
        yield return new WaitForSeconds(0.1f);
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}