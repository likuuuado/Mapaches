using UnityEngine;

public class PlayerFC : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    Rigidbody2D rb;

    bool isGrounded = true;
    bool isCrouching = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        // Movimiento horizontal
        int direction = 0;

        if (Input.GetKey(KeyCode.A))
            direction = -1;

        if (Input.GetKey(KeyCode.D))
            direction = 1;

        
        isCrouching = Input.GetKey(KeyCode.S);

       
        if (isCrouching)
            direction = 0;

        rb.linearVelocity = new Vector2(
            direction * moveSpeed,
            rb.linearVelocity.y
        );

        // Salto
        if (
            Input.GetKeyDown(KeyCode.Space)
            && isGrounded
            && !isCrouching
        )
        {
            rb.linearVelocity =
                new Vector2(
                    rb.linearVelocity.x,
                    jumpForce
                );

            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
}
