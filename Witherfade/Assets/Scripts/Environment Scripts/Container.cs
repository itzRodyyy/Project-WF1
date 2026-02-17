using TMPro;
using UnityEngine;

public class Container : MonoBehaviour, interactInterface
{
    public Inventory inventory;
    public string containerName;
    public TMP_Text containerInventoryText;

    public GameObject containerRowPrefab;
    public Transform content;
    public void onInteract()
    {
        gameManager.instance.container = this;
        Refresh();
        UIManager.instance.OpenContainerInventory();
        containerInventoryText.text = containerName;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Refresh()
    {

        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in inventory.items)
        {
            GameObject row = Instantiate(containerRowPrefab, content);
            row.GetComponent<ContainerRow>().Setup(item);
        }

    }
}
