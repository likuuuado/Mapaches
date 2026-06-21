using UnityEngine;

public class PlayerFC : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject graphics;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;



    Rigidbody2D rb;

    bool isGrounded = true;
    bool isCrouching = false;
    bool facingRight;
    

    float moveInput;
    bool jump;
    bool attack;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ReadInput();

        UpdateFacing();

        HandleMovement();
    }

    

   

    #region moviento e inputs
    void HandleMovement()
    {
        rb.linearVelocity =
        new Vector2(
            moveInput * moveSpeed,
            rb.linearVelocity.y
        );

        if(jump && isGrounded)
        {
            rb.linearVelocity =
            new Vector2(
            rb.linearVelocity.x,
            jumpForce
            );
            isGrounded = false;
        }
    }

    void ReadInput()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        jump = Input.GetKeyDown(KeyCode.Space);

        attack = Input.GetKeyDown(KeyCode.J);
    }
    #endregion


    #region helpers
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    void UpdateFacing()
    {
        facingRight =
        enemy.transform.position.x >
        transform.position.x;

        graphics.transform.localScale =
        new Vector3(
            facingRight ? 1 : -1,
            1,
            1
        );
    }
    #endregion



}
