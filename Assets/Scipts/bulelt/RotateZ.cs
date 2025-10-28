using UnityEngine;

public class RotateZ : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public bool useLocalRotation = true;

    void Update()
    {
        float delta = rotationSpeed * Time.deltaTime;
        if (useLocalRotation)
        {
            transform.Rotate(0f, 0f, delta, Space.Self);
        }
        else
        {
            transform.Rotate(Vector3.forward, delta, Space.World);
        }
    }
}
