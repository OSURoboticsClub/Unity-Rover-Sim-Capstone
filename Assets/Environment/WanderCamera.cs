using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
    public float moveSpeed = 500f;            // Increased movement speed (10x faster)
    public float lookSpeed = 4f;              // How fast the camera looks (mouse sensitivity)
    public float lookUpDownLimit = 80f;       // Limit for looking up and down
    public KeyCode unlockKey = KeyCode.Escape; // Key to unlock the mouse
    public KeyCode lockKey = KeyCode.Return;   // Key to lock the mouse

    private float pitch = 0f;                 // Current pitch (up/down rotation)
    private bool isMouseRotating = false;     // Whether the mouse is clicked and rotation is enabled
    private Camera mainCamera;                // Cached camera reference

    void Start()
    {
        mainCamera = Camera.main; // Cache the camera reference for faster access
        LockMouse(); // Ensure mouse is locked on start
    }

    void Update()
    {
        // Handle movement using WASD keys
        float moveX = Input.GetAxis("Horizontal");  // A/D or Left/Right arrow
        float moveZ = Input.GetAxis("Vertical");    // W/S or Up/Down arrow

        // Debug the input and speed
  
        // Without Time.deltaTime for testing
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        // Debug the resulting movement direction and speed
    

        // Apply movement directly without Time.deltaTime for now (for testing)
        transform.position += moveDirection * moveSpeed;

        // Handle mouse look for rotating the camera when mouse is clicked
        if (Input.GetMouseButton(0)) // Left mouse button (0) to start rotation
        {
            isMouseRotating = true;
        }
        else
        {
            isMouseRotating = false;
        }

        if (isMouseRotating)
        {
            // Only rotate when mouse is clicked
            float mouseX = Input.GetAxis("Mouse X");  // Mouse movement for left/right rotation
            float mouseY = Input.GetAxis("Mouse Y");  // Mouse movement for up/down rotation

            // Rotate the camera left/right (yaw)
            transform.Rotate(Vector3.up * mouseX * lookSpeed);

            // Rotate the camera up/down (pitch) with limits
            pitch -= mouseY * lookSpeed;
            pitch = Mathf.Clamp(pitch, -lookUpDownLimit, lookUpDownLimit);
            mainCamera.transform.localRotation = Quaternion.Euler(pitch, mainCamera.transform.eulerAngles.y, 0);
        }

        // Unlock the mouse (bring it out of the game window)
        if (Input.GetKeyDown(unlockKey))
        {
            UnlockMouse();
        }

        // Lock the mouse (keep it in the game window)
        if (Input.GetKeyDown(lockKey))
        {
            LockMouse();
        }
    }

    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;  // Unlock the mouse
        Cursor.visible = true;                   // Show the cursor
    }

    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the mouse to the center
        Cursor.visible = false;                  // Hide the cursor
    }
}

