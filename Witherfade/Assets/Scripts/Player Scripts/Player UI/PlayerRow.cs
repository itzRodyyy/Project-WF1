using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRow : MonoBehaviour
{
    public TMP_Text itemName;

    Item item;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Item _item)
    {
        item = _item;
        itemName.text = item.itemName;

    }

    public void Use()
    {
        if (item.itemType == ItemType.Weapon)
        {
            gameManager.instance.playerCombat.Equip(item.weapon);
        }
        else if (item.itemType == ItemType.Consumable)
        {
            gameManager.instance.playerCombat.Use(item.consumable);
        }
    }
}
