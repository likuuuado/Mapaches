using UnityEngine;

public class TortugaIA : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform player;
    [SerializeField] Animator animator;
    [SerializeField] Transform attackPoint;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float attackRange = 4f;
    [SerializeField] float decisionCooldown = 1;

    float timer;

    [Header("Combat")]
    [SerializeField] float hitRadius = 1f;
    [SerializeField] int damage = 10;
    [SerializeField] LayerMask enemyLayer;

    bool isAttacking;

    void Update()
    {
        Debug.Log(isAttacking);
        if (player == null || isAttacking)
            return;

        float distance = Vector2.Distance(
            transform.position, 
            player.position
        );

        if (distance > attackRange)
        {
            MoveTowardsPlayer();
            //Debug.Log("Distancia: " + distance);
        }
        else
        {
            animator.SetBool("IsWalking", false);

            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                ChooseAttack();
                timer = decisionCooldown;
            }
        }
    }

    #region Movement

    void MoveTowardsPlayer()
    {
        //Debug.Log("Intento acercarme");
        Vector2 direction = 
            (player.position - transform.position).normalized;

        transform.position += 
            (Vector3)direction * 
            moveSpeed * 
            Time.deltaTime;

        animator.SetBool("IsWalking", true);

        if (direction.x < 0)
            transform.localScale = new Vector3(1,1,1);
        else
            transform.localScale = new Vector3(-1,1,1);
    }

    #endregion

    #region Combat

    void ChooseAttack()
    {
        //Debug.Log("Intentando atacar");

        isAttacking = true;

        switch (Random.Range(0, 3))
        {
            case 0:
                animator.SetTrigger("Attack");
                break;

            case 1:
                animator.SetTrigger("DoubleAttack");
                break;

            case 2:
                animator.SetTrigger("Embestida");
                animator.SetTrigger("Embestida");
                break;
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

    public void EndAttack()
    {
        Debug.Log("Fin del ataque");
        isAttacking = false;
    }

    #endregion

}