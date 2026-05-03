using UnityEngine;
using UnityEngine.InputSystem; // Must have this!

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Change "InputValue" to "InputAction.CallbackContext"
    public void OnLook(InputAction.CallbackContext context)
{
    // Use 'ReadValue' to get the movement
    Vector2 mouseDelta = context.ReadValue<Vector2>();

    // Lower the multiplier here if it's still too fast
    float mouseX = mouseDelta.x * mouseSensitivity * 0.01f; 
    float mouseY = mouseDelta.y * mouseSensitivity * 0.01f;

    xRotation -= mouseY;
    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    playerBody.Rotate(Vector3.up * mouseX);
}
}