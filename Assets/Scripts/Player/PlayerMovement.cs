using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // vars
    Vector2 moveInput;
    public Vector2 lastMoveDirection { get; private set; } = Vector2.down;
    Rigidbody2D rb;

    public bool canMove = true;


    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float acceleration = 5f;
    [SerializeField] float damping = 5f;


    // refs
    InputSystem_Actions inputActions;


    public void Awake()
    {
        inputActions = new InputSystem_Actions();
        rb = GetComponent<Rigidbody2D>();

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
    }



    public void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;

    }

    public void OnDisable()
    {
        inputActions.Player.Move.performed -= ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled -= ctx => moveInput = Vector2.zero;
        inputActions.Disable();
    }

    public void Move()
    {
        Vector2 currentSpeed = rb.linearVelocity;
        Vector2 targetSpeed = moveInput.normalized * maxSpeed;
        Vector2 speedDifference = targetSpeed - currentSpeed;

        rb.AddForce(speedDifference * acceleration, ForceMode2D.Force);
        rb.AddForce(-rb.linearVelocity * damping, ForceMode2D.Force);

        if (moveInput != Vector2.zero)
        {
            lastMoveDirection = moveInput.normalized;
        }

    }

}
