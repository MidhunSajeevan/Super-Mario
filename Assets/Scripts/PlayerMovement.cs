//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.InputSystem;
//public class PlayerMovement : MonoBehaviour
//{
//    private Rigidbody2D _rigidbody;
//    private Vector2 _moveInput;
//    public float _walkSpeed = 8f;
//    private Vector2 velocity;
//    private Camera _camera;
//    private float _maxJumpHeight = 5f;
//    private float _maxJumpTime = 1f;

//    public float jumpforce => (2f *  _maxJumpHeight)/(_maxJumpTime / 2f);
//    public float gravity => (-2f * _maxJumpHeight) / Mathf.Pow((_maxJumpTime / 2f), 2);

//    public bool grounded {  get; private set; }
//    public bool jumping { get; private set; }
//    public bool _isMoving {  get; private set; }
//    private void Awake()
//    {
//        _rigidbody = GetComponent<Rigidbody2D>();
//        _camera = Camera.main;
//    }
//    private void Update()
//    {
//        HorizontalMovement();
//    }
//    void HorizontalMovement()
//    {
//        velocity.x = Mathf.MoveTowards(velocity.x, _moveInput.x*_walkSpeed,_walkSpeed * Time.deltaTime);
//    }
//    private void FixedUpdate()
//    {
//            Vector2 positon=_rigidbody.position;
//        positon += velocity * Time.fixedDeltaTime;

//        Vector2 leftEdge = _camera.ScreenToWorldPoint(Vector2.zero);
//        Vector2 rightEdge= _camera.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));

//        positon.x = Mathf.Clamp(positon.x , leftEdge.x + 0.5f, rightEdge.x - 0.5f);

//        _rigidbody.MovePosition(positon);
//    }

//    public void Move(InputAction.CallbackContext value)
//    {
//       _moveInput=value.ReadValue<Vector2>();
//        _isMoving = _moveInput != Vector2.zero;
//    }
//}
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer; // Assign the ground layer in the inspector
    public float groundCheckRadius = 0.2f; // Adjust the radius as needed

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        CheckGrounded();
    }

   public void OnMove(InputAction.CallbackContext value)
    {
        moveInput = value.ReadValue<Vector2>();
    }

   public void OnJump(InputAction.CallbackContext value)
    {
        Debug.Log("Jumping -------------");
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
    }
}
