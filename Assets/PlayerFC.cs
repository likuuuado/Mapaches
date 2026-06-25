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
    bool isCruching = false;
    bool facingRight;
    bool canCombo;
    bool isAttacking;
    
    float timer;
    float moveInput;
    bool jump;
    bool attack;
    bool ultimate;

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

        /*if(isCruching)
        {
            animator.SetBool("IsCruching",true);
        }*/
    }

    void HandleAttacks()
{
    if (attack)
    {
        if (!isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("Attack1");
        }
        else if (canCombo)
        {
            canCombo = false;
            animator.SetTrigger("Attack2");
        }
        
        EndAttack();
    }

    if (ultimate)
    {
        animator.SetTrigger("UseUltimate");
    }
}

    void ReadInput()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        jump = Input.GetKeyDown(KeyCode.Space);

        attack = Input.GetKeyDown(KeyCode.J);

        isCruching = Input.GetKeyDown(KeyCode.C);

        ultimate = Input.GetKeyDown(KeyCode.K);
    }

    public void EnableCombo()
    {
        canCombo = true;
    }

    public void DisableCombo()
    {
        canCombo = false;
    }

    public void EndAttack()
    {
    isAttacking = false;
    canCombo = false;
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
