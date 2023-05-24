using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // --- VARIABLES -----------------------------------------------------------

    [Header("COMPONENTS")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerInput _input;

    [Header("INPUT")]
    [SerializeField] private InputActionReference _moveX;
    [SerializeField] private InputActionReference _moveY;
    [SerializeField] private InputActionReference _moveV2;

    [Header("PARAMETERS")]
    [SerializeField] private float _moveSpeed = 5f;

    private bool _movingX, _movingY, _inverted;
    private Vector2 _movement;
    private Vector3 _originDir, _invertDir;

    // --- ON OBJECT STARTUP ---------------------------------------------------

    private void Awake()
    {
        _moveX.action.started += _ => {_movingX = true; _movingY = false;};
        _moveY.action.started += _ => {_movingX = false; _movingY = true;};

        _moveX.action.canceled += _ => _movingX = false;
        _moveY.action.canceled += _ => _movingY = false;

        // Sets Vector3s for character facing direction.
        _originDir = transform.localScale;
        _invertDir = _originDir;
        _invertDir.x = -_invertDir.x;

        _inverted = false;
    }
    
    // --- UPDATE --------------------------------------------------------------

    private void Update()
    {
        _movement = _moveV2.action.ReadValue<Vector2>();

        // Control variables so that diagonal movement is avoided.
        if (_movingX) _movement.y = 0;
        else if (_movingY) _movement.x = 0;

        // Inverts sprite when moving left.
        if (_movement.x < 0 && !_inverted) 
        {
            transform.localScale = _invertDir;
            _inverted = true;
        }

        // Reverts sprite to face right.
        else if (_movement.x > 0 && _inverted)
        {
            transform.localScale = _originDir;
            _inverted = false;
        }

        // Alternates between idle and running animations.
        _animator.SetFloat("Speed", _movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement.normalized * _moveSpeed 
            * Time.fixedDeltaTime);
    }
}
