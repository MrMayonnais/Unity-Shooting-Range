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
    
        private Rigidbody _rb;
        private bool _isGrounded;
    
        private float _currentSpeed;
    
        private Vector3 _moveDirection;
    
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
            _moveDirection.x = input.x;
            _moveDirection.z = input.y;
        }
    
        private void HandleMovement()
        {
            if (!_isGrounded)
            {
                Vector3 velocity = _moveDirection * (airManeuverability * _currentSpeed);
                velocity.y = _rb.linearVelocity.y;
                _rb.linearVelocity = velocity;
                _rb.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
            }
            else
            {
                Vector3 velocity = _moveDirection * _currentSpeed;
                velocity.y = _rb.linearVelocity.y; // Preserve vertical velocity
                _rb.linearVelocity = velocity;
            }
        }
    
        private bool IsGrounded()
        {   
            Debug.DrawLine(groundCheckPoint.position, new Vector3(groundCheckPoint.position.x, groundCheckPoint.position.y - GroundCheckDistance, groundCheckPoint.position.z), Color.red);
            return Physics.Raycast(groundCheckPoint.position, Vector3.down, GroundCheckDistance, LayerMask.GetMask("Ground"));
        }
    }
}
