using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;
    public Transform content;
    public GameObject playerRowPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            Refresh();
            UIManager.instance.openPlayerInventory();
        }
    }

    public void Refresh()
    {
        
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in inventory.items)
        {
            GameObject row = Instantiate(playerRowPrefab, content);
            row.GetComponent<PlayerRow>().Setup(item);
        }
        
    }

}
