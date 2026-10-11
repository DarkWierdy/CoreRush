using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    public float sprintMultiplier = 2f;
    public float gravity = -9.8f;
    public float jumpHeight = 2f;

    float yRotation = 0f;
    float yVelocity;

    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 100f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 100f * Time.deltaTime;

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -80f, 80f);

        Camera.main.transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // Check if grounded
        if (controller.isGrounded && yVelocity < 0)
        {
            yVelocity = -2f; // keeps player stuck to ground
        }

        // Jump
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravity
        yVelocity += gravity * Time.deltaTime;

        // Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float currentSpeed = speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= sprintMultiplier;
        }

        Vector3 move = (transform.right * x + transform.forward * z);
        move *= currentSpeed;

        move.y = yVelocity;

        controller.Move(move * Time.deltaTime);
    }
}