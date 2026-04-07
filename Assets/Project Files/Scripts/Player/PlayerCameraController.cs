using Project_Files.Scripts.Player.Input;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private float sensitivity = 100f;
    [SerializeField] private bool invertYAxis = false;
    
    [SerializeField] private float minPitch = -90f;
    [SerializeField] private float maxPitch = 90f;
    
    private Vector2 _lookDirection;
    private float _pitch; //Y rotation
    private float _yaw; //X rotation
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _pitch = 0;
        _yaw = 0;
    }
    

    private void OnEnable()
    {
        PlayerInputEvents.OnLookInput += Look;
    }
    
    private void OnDisable()
    {
        PlayerInputEvents.OnLookInput -= Look;
    }

    private void Update()
    {
        UpdateCameraLook();
    }

    private void Look(Vector2 lookDirection)
    {
        _lookDirection = lookDirection;
    }

    private void UpdateCameraLook()
    {
        _pitch = Mathf.Clamp(_pitch + (_lookDirection.y * sensitivity * Time.deltaTime * (invertYAxis ? 1 : -1)), minPitch, maxPitch);
        _yaw += _lookDirection.x * sensitivity * Time.deltaTime;
        
        cameraPivot.localRotation = Quaternion.Euler(_pitch, 0, 0);
        transform.localRotation = Quaternion.Euler(0, _yaw, 0);
        
    }
}
