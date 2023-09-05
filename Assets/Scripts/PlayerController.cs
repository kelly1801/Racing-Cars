using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Rigidbody rb;
    private float playerRadius;
    private float playerHeight;
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 30.0f;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        rb = GetComponent<Rigidbody>();
        playerRadius = GetComponent<BoxCollider>().size.x / 2;
        playerHeight = GetComponent<BoxCollider>().size.y;
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private Vector2 GetMovementVector()
    {
        Vector2 inputVector;

        inputVector =
            gameObject.CompareTag("Player 1")
            ?
            playerInputActions.Player.MovePlayer1.ReadValue<Vector2>()
            :
            playerInputActions.Player.MovePlayer2.ReadValue<Vector2>();

        return inputVector;
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GetMovementVector();
        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);

        // Apply forces for movement
        Vector3 velocity = moveDirection.normalized * moveSpeed;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);

        // Rotate smoothly without quaternions or Euler angles
        if (moveDirection != Vector3.zero)
        {
            Vector3 targetForward = Vector3.Slerp(transform.forward, moveDirection.normalized, Time.fixedDeltaTime * rotateSpeed);
            transform.forward = targetForward;
        }
    }
}



