using UnityEngine;

public class InputManager : MonoBehaviour
{
    private DefaultInputs playerInput;
    private DefaultInputs.DefaultMapActions onGround;

    private PlayerMovement movement;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new DefaultInputs();
        onGround = playerInput.DefaultMap;

        movement = GetComponent<PlayerMovement>();

        onGround.Jump.performed += ctx => movement.Jump();
        onGround.Sprint.performed += ctx => movement.Sprint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //tell the playermotor to move using the value from our movement action.
        movement.ProcessMove(onGround.Movement.ReadValue<Vector2>());
        
    }

    private void LateUpdate()
    {

    }

    private void OnEnable()
    {
        onGround.Enable();
    }

    private void OnDisable()
    {
        onGround.Disable();
    }

}