using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float _speed;
    private int _speedMultiplier;
    public Vector2 _velocity;
    private bool _btnPressed;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        HorizontalMovement();
    }
    void HorizontalMovement()
    {
       
       float targetSpeed= _speedMultiplier* _speed;
        _rigidbody.velocity = new Vector2(targetSpeed, _rigidbody.velocity.y);
    }
    public void Move(InputAction.CallbackContext value)
    {
       
        if(value.started)
        {
            _btnPressed = true;
            _speedMultiplier = 1;
        }else if(value.canceled)
        {
            _btnPressed= false;
            _speedMultiplier = 0;
        }
    }
}
