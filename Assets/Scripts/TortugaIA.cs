using UnityEngine;

public class TortugaIA : MonoBehaviour
{
    public Transform player;
    public Animator animator;

    public float moveSpeed = 3f;
    public float attackRange = 4f;


    public float decisionCooldown = 1.5f;

    private float timer;
    private bool isAttacking;

    void Update()
    {
        if (player == null || isAttacking)
            return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                ChooseAttack();
                timer = decisionCooldown;
                EndAttack();
            }
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

        animator.SetBool("IsWalking", true);

        if (direction.x < 0)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void ChooseAttack()
    {
        animator.SetBool("IsWalking", false);

        int attack = Random.Range(0, 3);

        isAttacking = true;

        switch (attack)
        {
            case 0:
                animator.SetTrigger("Attack");
                break;

            case 1:
                animator.SetTrigger("DoubleAttack");
                break;

            case 2:
                animator.SetTrigger("Embestida");
                break;
        }
    }

    // Llamado desde un Animation Event
    public void EndAttack()
    {
        isAttacking = false;
    }
}