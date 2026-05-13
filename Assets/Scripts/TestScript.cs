using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestScript : MonoBehaviour
{
    #region Variables: Movement

    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;

    [SerializeField] private float speed;

    #endregion
    #region Variables: Rotation
    private float _currentVelocity;

    #endregion
    #region Variables: Gravity

    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float _velocity;

    [SerializeField] private float jumpPower = 5f;
    private int _numberofJumps;
    [SerializeField] private int maxJumps = 2;
    [SerializeField] private Movement movement;

    [SerializeField] private float standingHeight = 2f;
    [SerializeField] private float crouchingHeight = 1f;
    [SerializeField] private float crouchTransitionSpeed = 10f;

    #endregion

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        
    }

    private void Update()
    {
        ApplyGravity(); 
        ApplyMovement();
        ApplyCrouch();
    }

    private void ApplyGravity()
    {
        _velocity = Mathf.Max(_velocity, -50f);
        if (_characterController.isGrounded && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }
        
        _direction.y = _velocity;
    }
    
    private void ApplyMovement()
{
    Vector3 move = transform.right * _input.x + transform.forward * _input.y;
    Vector3 horizontalDirection = new Vector3(move.x, 0.0f, move.z).normalized;

    _direction.x = horizontalDirection.x;
    _direction.z = horizontalDirection.z;

    var targetSpeed = movement.isSprinting ? movement.speed * movement.multiplier : movement.speed;
    movement.currentSpeed = Mathf.MoveTowards(movement.currentSpeed, targetSpeed, movement.accleration * Time.deltaTime);

    _characterController.Move(_direction * movement.currentSpeed * Time.deltaTime);
}

    private void ApplyCrouch()
{
    float targetHeight = movement.isCrounching ? crouchingHeight : standingHeight;

    _characterController.height = Mathf.Lerp(
        _characterController.height,
        targetHeight,
        crouchTransitionSpeed * Time.deltaTime
    );
}

    public void Move(InputAction.CallbackContext context)
{
    _input = context.ReadValue<Vector2>();
}

    public void OnJump(InputAction.CallbackContext context)
    {
        if(!context.started) return;

        if(!isGrounded() && _numberofJumps >= maxJumps) return;
        if(_numberofJumps == 0) StartCoroutine(WaitForLanding());

        _numberofJumps++;
        _velocity = jumpPower;
    }

    public void OnCrounch(InputAction.CallbackContext context)
    {
        movement.isCrounching = context.started || context.performed;

        if(movement.isCrounching)
        {
            _characterController.height = _characterController.height * movement.crouchMultiplier;
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        
        movement.isSprinting = context.started || context.performed;
    }

    private IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => !isGrounded());
        yield return new WaitUntil(isGrounded);

        _numberofJumps = 0;
    }

    private bool isGrounded() => _characterController.isGrounded;

    [Serializable]
    public struct Movement
    {
        public float speed;
        public float multiplier;
        public float accleration;
        public float crouchMultiplier;
        [HideInInspector] public bool isSprinting;
        [HideInInspector] public bool isCrounching;
        [HideInInspector] public float currentSpeed;
    }
}
