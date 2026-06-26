using UnityEngine;

public class PlayerFC : MonoBehaviour
{
<<<<<<< HEAD
    [Header("References")]
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject graphics;
    [SerializeField] Animator animator;
    [SerializeField] Transform attackPoint;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 10f;

    [Header("Combat")]
    [SerializeField] float hitRadius = 1f;
    [SerializeField] int damage = 10;
    [SerializeField] LayerMask enemyLayer;
=======
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
>>>>>>> origin/autista-de-mierda

    Rigidbody2D rb;

    bool isGrounded = true;
<<<<<<< HEAD
    bool facingRight;
    bool canCombo;
    bool isAttacking;
    bool isCruching;

    float moveInput;
    bool jump;
    bool attack;
    bool ultimate;
=======
    bool isCrouching = false;
>>>>>>> origin/autista-de-mierda

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
<<<<<<< HEAD
        ReadInput();

        HandleMovement();

        HandleAttacks();

        UpdateFacing();
    }

   
    #region Movement

    void ReadInput()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        jump = Input.GetKeyDown(KeyCode.Space);

        attack = Input.GetKeyDown(KeyCode.J);

        isCruching = Input.GetKeyDown(KeyCode.C);

        ultimate = Input.GetKeyDown(KeyCode.K);
=======
        HandleMovement();
>>>>>>> origin/autista-de-mierda
    }

    void HandleMovement()
    {
<<<<<<< HEAD
        rb.linearVelocity = new Vector2(
            moveInput * moveSpeed,
            rb.linearVelocity.y
        );

        if(jump && isGrounded)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );

            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }

    }

    #endregion

    #region Combat

    void HandleAttacks()
    {
        if (attack)
        {
            if(!isAttacking)
            {
                isAttacking = true;
                animator.SetTrigger("Attack1");
            }
            else if (canCombo)
            {
                canCombo = false;
                animator.SetTrigger("Attack2");
            }
        }

        if (ultimate)
        {
            animator.SetTrigger("UseUltimate");
        }
    }

    public void DealDamage()
    {
        Collider2D hit = Physics2D.OverlapCircle(
            attackPoint.position,
            hitRadius,
            enemyLayer
        );

        if (hit == null)
            return;
        
        Health health = hit.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }

    #endregion

    #region Animation Events


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


    #region Helpers

=======
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

>>>>>>> origin/autista-de-mierda
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
<<<<<<< HEAD
            animator.SetBool("IsJumping", false);
        }
    }

    void UpdateFacing()
    {
        if(enemy == null || graphics == null)
            return;

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

    /*void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSpehre(
            attackPoint.position,
            hitRadius
        );
    }*/

    #endregion
=======
        }
    }
>>>>>>> origin/autista-de-mierda
}
