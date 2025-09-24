using UnityEngine;
using System;
using System.Collections;
[AddComponentMenu("tule/PlayerController")]
public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public LayerMask groundLayer;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float radius = 0.2f;
    private Rigidbody2D rb;
    [SerializeField]
    private bool facingRight = true;
    private Animator aims;
    private int isWalkId;
    private int isJumpId;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aims = GetComponentInChildren<Animator>();
        isWalkId = Animator.StringToHash("IsWalk");
        isJumpId = Animator.StringToHash("IsJum");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            StartCoroutine(Jum());
        }
    }
    IEnumerator Jum()
    {
        aims.SetTrigger(isJumpId);

        yield return new WaitForSeconds(0.1f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        {
            rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
        }
        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            Flip();
        }
        if (Math.Abs(rb.linearVelocity.x) > 0.1f)
        {
            aims.SetBool(isWalkId, true);
        }
        else
        {
            aims.SetBool(isWalkId, false);
        }
    }
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, radius, groundLayer);
    }
    public bool FaceRight()
    {
        return facingRight;
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }
}