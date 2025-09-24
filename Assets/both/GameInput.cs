using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key was passed");
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            Debug.Log("Horizontal axis value: " + Input.GetAxis("Horizontal"));
        }
    }
}
