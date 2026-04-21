using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
   [SerializeField] float moveSpeed = 50f;


    Vector3 moveVector;

    Rigidbody2D rb;
    InputAction move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        move = InputSystem.actions.FindAction("Move");
    }


    void Update()
    {
        moveVector = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (moveVector.x < 0)
        {
            rb.linearVelocityX = -moveSpeed;
        }
        else if (moveVector.x > 0)
        {
            rb.linearVelocityX = moveSpeed;
        }

        if (moveVector.y < 0)
        {
            rb.linearVelocityY = -moveSpeed;
        }
        else if (moveVector.y > 0)
        {
            rb.linearVelocityY = moveSpeed;
        }
    }
}
