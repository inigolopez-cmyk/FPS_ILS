using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    [SerializeField]
    private InputAction movementInput;
    [SerializeField]
    private InputAction jumpInput;
    CharacterController controller; // Nos ahorra: crear escaleras, colisión con el piso,

    private float playerSpeed = 5.0f;
    private float gravityValue = -9.81f;
    private float jump = 5.0f;

    private Vector3 playerVelocity;
    private bool grounded;

    private void Awake() // activates before any function
    {
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        movementInput.Enable();
        jumpInput.Enable();
    }

    private void OnDisable()
    {
        movementInput.Disable();
        jumpInput.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPlaying == true)
        { 
            grounded = controller.isGrounded;
            if (grounded)
            {
                if (playerVelocity.y < -2) // si en los if sólo necesitamos 1 línea, podemos no poner llaves {}.
                    playerVelocity.y = -1;
            }

            Vector2 Movement = movementInput.ReadValue<Vector2>();
            Vector3 direction = transform.right * Movement.x + transform.forward * Movement.y;
            direction = Vector3.ClampMagnitude(direction, 1);

            if (grounded && jumpInput.triggered)
            {
                playerVelocity.y = Mathf.Sqrt(jump * -2 * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;

            Vector3 finalMove = direction * playerSpeed + Vector3.up * playerVelocity.y;

            controller.Move(finalMove * Time.deltaTime);
        }
    }
}
