using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;

    private Rigidbody rb;
    private Camera playerCamera;
    private float xRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main;

        // Lock cursor in the center
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate horizontally (y-axis) -> player body
        transform.Rotate(Vector3.up * mouseX);

        // Rotate vertically (x-axis) -> camera only
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f); // prevent flipping
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = transform.right * h + transform.forward * v;
        rb.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);
    }
}
