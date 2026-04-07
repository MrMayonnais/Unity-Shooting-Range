using Project_Files.Scripts.Player.Input;
using UnityEngine;

namespace Project_Files.Scripts.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float crouchSpeed = 5f;
        [SerializeField] private float sprintSpeed = 8f;
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private float gravityMultiplier = 2f;
        [Range(0f,1f)]
        [SerializeField] private float airManeuverability = 0.5f;
    
        [SerializeField] private Transform groundCheckPoint;
        
        [SerializeField] private float acceleration = 10f;
        [SerializeField] private float deceleration = 15f;
    
        private Rigidbody _rb;
        private bool _isGrounded;
    
        private float _currentSpeed;
    
        private Vector2 _moveDirection;
        private Vector3 _currentVelocity;
        private Vector3 _movement;
    
        private const float GroundCheckDistance = 0.2f;
    
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _currentSpeed = moveSpeed;
        }
    
        private void OnEnable()
        {
            PlayerInputEvents.OnJumpInput += OnPlayerJump;
            PlayerInputEvents.OnMoveInput += MovePlayer;
        }

        private void OnDisable()
        {
            PlayerInputEvents.OnJumpInput -= OnPlayerJump;
            PlayerInputEvents.OnMoveInput -= MovePlayer;
        }

        private void Update()
        {
            _isGrounded = IsGrounded();
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }
    
        private void OnPlayerJump(bool isJumping)
        {
            if (isJumping && _isGrounded)
            {
                _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        private void MovePlayer(Vector2 input)
        {
            _moveDirection = input.normalized;
        }
    
        private void HandleMovement()
        {
            if(!_isGrounded)
            {
                // Apply extra gravity when in the air
                _rb.AddForce(Physics.gravity * (gravityMultiplier - 1f), ForceMode.Acceleration);
                
                // Reduce horizontal control in the air
                _currentVelocity *= airManeuverability;
            }
            
            _movement = (transform.forward * _moveDirection.y + transform.right * _moveDirection.x).normalized;
            
            Vector3 targetVelocity = _movement * _currentSpeed;
            
            // Smooth towards target using acceleration / deceleration
            float rate = _movement.sqrMagnitude > 0f ? acceleration : deceleration;
            _currentVelocity = Vector3.MoveTowards(_currentVelocity, targetVelocity, rate * Time.fixedDeltaTime);
 
            // Apply horizontal velocity, preserving existing vertical (Y) velocity
            var velocityChange = _currentVelocity - new Vector3(_rb.linearVelocity.x, 0f, _rb.linearVelocity.z);
            _rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
    
        private bool IsGrounded()
        {   
            Debug.DrawLine(groundCheckPoint.position, new Vector3(groundCheckPoint.position.x, groundCheckPoint.position.y - GroundCheckDistance, groundCheckPoint.position.z), Color.red);
            return Physics.Raycast(groundCheckPoint.position, Vector3.down, GroundCheckDistance, LayerMask.GetMask("Ground"));
        }
    }
}
