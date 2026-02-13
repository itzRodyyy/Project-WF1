using UnityEditor;
using UnityEngine;

public class combat : MonoBehaviour, damageInterface
{
    [Range(1, 10)]public int maxHealth;
    [Range(1, 10)][SerializeField] int shootDamage;
    [Range(1, 50)][SerializeField] int shootDist;
    [Range(0, 2)][SerializeField] float shootRate;
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
        if (health <= 0)
        {
            health = 0;
            gameManager.instance.statePause();
            Debug.Log("You Died!");
        }
    }
}
