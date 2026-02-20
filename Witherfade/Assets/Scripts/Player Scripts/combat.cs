using UnityEditor;
using UnityEngine;

public class combat : MonoBehaviour, damageInterface
{
    [Range(1, 10)]public int maxHealth;
    [Range(1, 10)]public int shootDamage;
    [Range(1, 50)]public int shootDist;
    [Range(0, 2)]public float shootRate;
    public GameObject model;
    [SerializeField] LayerMask ignoreLayer;

    float shootTimer;
    public int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, 
            Camera.main.transform.forward * shootDist, Color.red);
        shootTimer += Time.deltaTime;
        Attack();

        if (Input.GetKeyDown(KeyCode.M))
        {
            TakeDamage(100);
        }

    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1") && shootTimer > shootRate)
        {
            shootTimer = 0;
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, shootDist, ~ignoreLayer))
            {
                Debug.Log("HIT! Victim: " + hit.collider.name);
                damageInterface victim = hit.collider.GetComponent<damageInterface>();
                if (victim != null)
                {
                    victim.TakeDamage(shootDamage);
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UIManager.instance.UpdateHealthBar();
        if (health <= 0)
        {
            health = 0;
            gameManager.instance.statePause();
            UIManager.instance.openDiedMenu();
        }
    }

    public void Equip(Weapon weapon)
    {
        shootDamage = weapon.weaponDmg; // Set Damage to Weapon Damage
        shootDist = weapon.weaponRange; // Set Range to Weapon Range
        shootRate = weapon.attackRate; // Set Rate to Weapon Rate

        // Make visual of weapon appear in hand (will change in Alpha).
        model.GetComponent<MeshFilter>().sharedMesh = weapon.model.GetComponent<MeshFilter>().sharedMesh; 
        model.GetComponent<MeshRenderer>().sharedMaterial = weapon.model.GetComponent<MeshRenderer>().sharedMaterial;

    }

    public void Use(Consumable consumable)
    {
        if (health + consumable.HPGain >= maxHealth) // If the sum of HP and Gain were to exceed or meet Max HP, set HP to Max HP
        {
            health = maxHealth;
        } 
        else // Else, add Gain to HP
        {
            health += consumable.HPGain;
        }

        UIManager.instance.UpdateHealthBar(); // Update the Health Bar
    }
}
