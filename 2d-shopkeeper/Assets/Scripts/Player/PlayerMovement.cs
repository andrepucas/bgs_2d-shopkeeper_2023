using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // --- VARIABLES -----------------------------------------------------------

    [Header("COMPONENTS")]
    [SerializeField] private GameObject _model;

    [Header("INPUT")]
    [SerializeField] private InputActionReference _moveX;
    [SerializeField] private InputActionReference _moveY;
    [SerializeField] private InputActionReference _moveV2;

    [Header("PARAMETERS")]
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody2D _rb;
    private Animator _animator;
    private PlayerInput _input;
    
    private bool _movingX, _movingY, _inverted;
    private Vector2 _movement;
    private Vector3 _originDir, _invertDir;

    // --- ON OBJECT STARTUP ---------------------------------------------------

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _input = GetComponent<PlayerInput>();
        
        _moveX.action.started += _ => {_movingX = true; _movingY = false;};
        _moveY.action.started += _ => {_movingX = false; _movingY = true;};

        _moveX.action.canceled += _ => _movingX = false;
        _moveY.action.canceled += _ => _movingY = false;

        // Sets Vector3s for character facing direction.
        _originDir = Vector3.one;
        _invertDir = Vector3.one;
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
            _model.transform.localScale = _invertDir;
            _inverted = true;
        }

        // Reverts sprite to face right.
        else if (_movement.x > 0 && _inverted)
        {
            _model.transform.localScale = _originDir;
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

    // --- METHODS -------------------------------------------------------------

    public void Freeze() => _animator.SetFloat("Speed", 0);
}
