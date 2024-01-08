using UnityEngine;

public class PlayerMovementSnappy : MonoBehaviour
{
    public CharacterController characterController;
    public float autoSpeed;
    public float moveSpeed;
    public float jumpForce;
    public bool doubleJump;
    public float gravityScale;

    private Vector3 moveDirection;
    private bool isMidAir;

    // Start is called at scene load
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, autoSpeed);

        if (Input.GetButtonDown("Jump"))
        {
            if (characterController.isGrounded)
            {
                moveDirection.y = jumpForce;
                isMidAir = true;
            }

            //Double jump here
            else if (isMidAir)
            {
                if (doubleJump)
                {
                    moveDirection.y = jumpForce;
                }
                isMidAir = false;
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
