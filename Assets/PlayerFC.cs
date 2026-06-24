using UnityEngine;

public class PlayerFC : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject graphics;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Animator animator;


    Rigidbody2D rb;

    bool isGrounded = true;
    bool isCrouching = false;
    bool facingRight;
    
    float timer;
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

        HandleAttacks();
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
            animator.SetBool("IsJumping", true);
        }
    }

    void HandleAttacks()
    {

        if (attack)
        {
            animator.SetTrigger("Attack1");
            /*timer -= Time.deltaTime;
            if (timer <= 0)
            {
                animator.Set
            }*/
        }
    }

    void ReadInput()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        jump = Input.GetKeyDown(KeyCode.Space);

        attack = Input.GetKeyDown(KeyCode.J);

        //isCrouching = Input.GetKeyDown(KeyCode.Ctrl);

        //ultimate = Input.GetKeyDown(KeyCode.K);
    }
    #endregion


    #region helpers
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
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
