using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public GameObject prefab;
    public string itemName;
    public Sprite icon;
    public int id;
}
