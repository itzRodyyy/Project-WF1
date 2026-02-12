using UnityEngine;

public class movement : MonoBehaviour
{
    [Range(5, 15)] public int moveSpeed;
    [Range(8, 12)] public int jumpPower;
    [Range(12, 30)][SerializeField] int gravity;
    [SerializeField] float standHeight;
    [SerializeField] float crouchHeight;
    [SerializeField] CharacterController player;

    Vector3 moveDirection;
    Vector3 playerVelocity;
    bool hasJumped;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.height = standHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGrounded)
        {
            hasJumped = false;
            playerVelocity = Vector3.zero;
        }
        Walk();
        Jump();

        playerVelocity.y -= gravity * Time.deltaTime;
        player.Move(playerVelocity * Time.deltaTime);

        Crouch();
    }

    void Walk()
    {
        moveDirection = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        player.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !hasJumped)
        {
            playerVelocity.y = jumpPower;
            hasJumped = true;
        }
    }

    void Crouch()
    {
        if (Input.GetButtonDown("Crouch"))
            player.height = crouchHeight;
        if (Input.GetButtonUp("Crouch"))
            player.height = standHeight;
    }
}
