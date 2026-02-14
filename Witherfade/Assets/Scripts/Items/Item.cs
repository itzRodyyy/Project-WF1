using UnityEngine;

public class ItemPickup : MonoBehaviour, interactInterface
{
    [SerializeField] ItemType type;
    [Header("== Consumable Stats ==")]
    [SerializeField] int HPGain;
    [Header("== Weapon Stats ==")]
    [SerializeField] int weaponDmg;
    [SerializeField] int weaponRange;
    [SerializeField] float attackRate;

    public void onInteract()
    {
        if (type == ItemType.Weapon)
        {
            gameManager.instance.playerCombat.shootDamage = weaponDmg;
            gameManager.instance.playerCombat.shootDist = weaponRange;
            gameManager.instance.playerCombat.shootRate = attackRate;
        }
        else
        {
            if (gameManager.instance.playerCombat.health + HPGain >= gameManager.instance.playerCombat.maxHealth)
                gameManager.instance.playerCombat.health = gameManager.instance.playerCombat.maxHealth;
            else
                gameManager.instance.playerCombat.health += HPGain;

            UIManager.instance.UpdateHealthBar();
        }

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
