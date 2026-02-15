using UnityEngine;

public class ItemPickup : MonoBehaviour, interactInterface
{
    [SerializeField] ItemType type;
    [SerializeField] Item item;

    public void onInteract()
    {
        gameManager.instance.playerInventory.inventory.AddItem(item);

        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum ItemType
{
    Consumable,
    Weapon
}
