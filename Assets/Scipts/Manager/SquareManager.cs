using UnityEngine;

public class SquareManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Colliding with " + collision.gameObject.name);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision ended with " + collision.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered with " + other.gameObject.name);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Trigger staying with " + other.gameObject.name);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger exited with " + other.gameObject.name);
    }
}
