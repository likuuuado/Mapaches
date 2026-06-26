using UnityEngine;

public class PlayerFC : MonoBehaviour
{
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

    Rigidbody2D rb;

    bool isGrounded = true;
    bool facingRight;
    bool canCombo;
    bool isAttacking;
    bool isCruching;

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
    }

    void HandleMovement()
    {
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
}
