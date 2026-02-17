using TMPro;
using UnityEngine;

public class ContainerRow : MonoBehaviour
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
        gameManager.instance.playerInventory.inventory.AddItem(item);
        gameManager.instance.container.inventory.RemoveItem(item);

        gameManager.instance.playerInventory.Refresh();
        gameManager.instance.container.Refresh();
    }
}
