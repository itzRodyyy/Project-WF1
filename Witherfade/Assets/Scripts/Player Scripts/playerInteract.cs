using UnityEngine;

public class playerInteract : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int interactRange;
    [SerializeField] LayerMask ignoreLayer;
    [SerializeField] GameObject interactPopup;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position,
            Camera.main.transform.forward * interactRange, Color.blue);
        Interact();
    }

    void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactRange, ~ignoreLayer))
        {
            interactInterface interaction = hit.collider.GetComponent<interactInterface>();
            if (interaction != null)
            {
                interactPopup.SetActive(true);
                if (Input.GetButtonDown("Interact"))
                {
                    Debug.Log("Interaction: " + hit.collider.name);
                    interactPopup.SetActive(false);
                    interaction.onInteract();
                }
            }
            else
                interactPopup.SetActive(false);
        }
        else
            interactPopup.SetActive(false);
    }
}
