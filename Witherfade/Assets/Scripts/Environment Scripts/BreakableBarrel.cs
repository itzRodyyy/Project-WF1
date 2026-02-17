using UnityEngine;

public class BreakableBarrel : MonoBehaviour, damageInterface

{
    [SerializeField] int HP;
    [SerializeField] Inventory inventory;
    [SerializeField] float dropRadius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            DropItems();
            Destroy(gameObject);
        }
    }

    public void DropItems()
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            var item = inventory.items[i];

            Vector3 dropPosition = transform.position +
                new Vector3(Random.Range(-dropRadius, dropRadius),
                            Random.Range(-dropRadius, dropRadius),
                            0);

            Instantiate(item.dropPrefab, dropPosition, Quaternion.identity);
        }

        inventory.items.Clear();
    }
}
