using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPesronControl : MonoBehaviour
{
    public float moveSpeed = 5f;   // Movement speed of the character
    public float gravity = -9.81f; // Gravity value to simulate downward force

    private CharacterController controller; // Reference to the CharacterController component
    private Vector3 velocity;               // Current velocity of the character

    private void Awake()
    {
        // Get the reference to the CharacterController component
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Read input for movement axes (e.g., WASD or arrow keys)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed;

        // Apply movement to the character controller
        controller.Move(movement * Time.deltaTime);

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
