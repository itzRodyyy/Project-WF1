using UnityEngine;

public class camera : MonoBehaviour
{
    [Range(80, 500)][SerializeField] int sens;
    [SerializeField] int lockVertMin, lockVertMax;
    [SerializeField] bool invertY;

    float rotX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;

        if (invertY)
            rotX += mouseY;
        else
            rotX -= mouseY;

        rotX = Mathf.Clamp(rotX, lockVertMin, lockVertMax);

        transform.localRotation = Quaternion.Euler(rotX, 0, 0);

        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
