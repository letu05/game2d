using UnityEngine;
[AddComponentMenu("Enemy/EnemyAl")]

public class EnemyAl : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public Transform Target;
    private Vector3 nextPosition;
    public float minDistance = 0.5f;
    private Rigidbody2D rb;
    private int isIDIdie;
    private Animator aim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Target = pointA;
        aim = GetComponentInChildren<Animator>();
        isIDIdie = Animator.StringToHash("isDie");
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }
    private void Patrol()
    {
        if(aim.GetCurrentAnimatorStateInfo(0).IsName("Isdie")){
            rb.linearVelocity = Vector2.zero;
            return;
        }
        // Tính khoảng cách đến target
        float distanceToTarget = Vector2.Distance(transform.position, Target.position);
        
        // Kiểm tra nếu đã đến gần điểm đích
        if(distanceToTarget < minDistance){
            aim.SetTrigger("Isdie");
            // Chuyển sang điểm tiếp theo
            if (Target == pointA){
                Target = pointB;
            } else {
                Target = pointA;
            }
            
            // Lật sprite khi đổi hướng
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        
        // Di chuyển enemy
        Vector2 direction = (Target.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }
    private void OnDrawGizmos(){
        if(pointA != null && pointB != null) {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(pointA.position, pointB.position);
        };
        }
}
