using UnityEngine;
using UnityEngine.UI;
public class Scriptablemanager : MonoBehaviour
{   
    public Item[] item;
    public Image Image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(item[Random.Range(0,2)].prefab,transform.position,Quaternion.identity);
        Debug.Log(item[Random.Range(0, 2)]);
        Image.sprite= item[Random.Range(0, 2)].icon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
