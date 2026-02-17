using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/UI/Item")]
public class Item : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public Weapon weapon;
    public Consumable consumable;
    public GameObject dropPrefab;
}
