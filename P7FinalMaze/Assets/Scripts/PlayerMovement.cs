using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gravity = 9.8f;
    public Transform cameraPivot; // Reference to the CameraPivot

    private CharacterController controller;
    private Vector3 moveDirection;

    void Start()
    {
        // Get the CharacterController component attached to the player
        controller = GetComponent<CharacterController>();

        // Check if the CharacterController component is attached
        if (controller == null)
        {
            Debug.LogError("No CharacterController component found on this GameObject. Please add one.");
        }

        // Ensure the cameraPivot is correctly positioned relative to the player
        if (cameraPivot != null)
        {
            cameraPivot.SetParent(transform);
            cameraPivot.localPosition = new Vector3(0, 1.6f, 0); // Adjust based on your player's head height
            cameraPivot.localRotation = Quaternion.identity;
        }
        else
        {
            Debug.LogError("No CameraPivot transform found. Please assign the camera pivot.");
        }
    }

    void Update()
    {
        // Only move the player if the CharacterController component is attached
        if (controller != null)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        // Get input for movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Apply movement speed
        moveDirection = move * moveSpeed;

        // Apply gravity
        if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        else
        {
            moveDirection.y = -1f; // Slight downward force to keep grounded
        }

        // Move the player
        controller.Move(moveDirection * Time.deltaTime);
    }
}
