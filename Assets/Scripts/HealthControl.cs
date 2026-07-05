using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Anger anger;

    void Awake()
    {
        anger = GetComponent<Anger>();
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anger?.AddAnger(10);
        //Debug.Log(gameObject.name + " recibio " + damage + " de daño");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public int CurrentHealth
    {
        get {return currentHealth;}
    }

    void Die()
    {
        Debug.Log(gameObject.name + " murió");
    }
}