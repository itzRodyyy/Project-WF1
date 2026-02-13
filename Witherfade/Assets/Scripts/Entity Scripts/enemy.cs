using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour, damageInterface
{
    [SerializeField] NavMeshAgent agent;
    [Range(1,15)][SerializeField] int HP;
    [Range(1,15)][SerializeField] int faceTargetSpeed;
    [Range(0, 2)][SerializeField] float attackRate;
    [Range(1, 20)][SerializeField] int attackRange;
    [Range(1, 10)][SerializeField] int attackDamage;
    [SerializeField] LayerMask ignoreLayer;
    [SerializeField] Renderer model;

    bool playerInRange;
    float attackTimer;
    Color colorOrig;
    Vector3 playerDirection;

    public void TakeDamage(int damage)
    {
        HP -= damage;
        StartCoroutine(flashRed());
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colorOrig = model.material.color;
        agent.stoppingDistance = attackRange;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * attackRange, Color.orange);
        attackTimer += Time.deltaTime;
        if (playerInRange)
        {
            agent.SetDestination(gameManager.instance.player.transform.position);
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                facePlayer();
                if (attackTimer >= attackRate)
                {
                    attackTimer = 0;
                    attackPlayer();
                }
            }
        }
    }



    IEnumerator flashRed()
    {
        model.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        model.material.color = colorOrig;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void facePlayer()
    {
        playerDirection = (gameManager.instance.player.transform.position - transform.position);
        Quaternion rot = Quaternion.LookRotation(new Vector3(playerDirection.x, transform.position.y, playerDirection.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * faceTargetSpeed);
    }

    void attackPlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange, ~ignoreLayer))
        {
            damageInterface victim = hit.collider.GetComponent<damageInterface>();
            if (victim != null)
            {
                victim.TakeDamage(attackDamage);
            }
        }
    }

}
