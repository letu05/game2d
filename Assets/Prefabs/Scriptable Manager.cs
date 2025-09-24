using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class ScriptableManager : MonoBehaviour
{
    public Item item;
    public UnityEngine.UI.Image image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(item.prefab, transform.position, Quaternion.identity);
        Debug.Log(item.itemName);
        image.sprite = item.icon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
