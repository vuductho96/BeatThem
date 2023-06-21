using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;  // Reference to the target object (e.g., the player character)

    public float distance = 5f;  // Distance between the camera and the target
    public float height = 3f;    // Height offset of the camera from the target
    public float smoothSpeed = 10f;  // Speed at which the camera follows the target

    private Vector3 offset;      // Offset vector between the camera and the target

    private void Start()
    {
        // Calculate the initial offset vector between the camera and the target
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // Calculate the desired camera position based on the target's position and offset
        Vector3 targetPosition = target.position + offset;
        Vector3 desiredPosition = targetPosition - transform.forward * distance + Vector3.up * height;

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Make the camera look at the target
        transform.LookAt(target);
    }
}
