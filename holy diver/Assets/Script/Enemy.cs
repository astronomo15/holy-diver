using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 5f;
    [SerializeField] private bool dealDamage = true;
    [SerializeField] private int damageAmount = 10;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 4f);
    }

    private void Update()
    {
        rb.linearVelocity = new Vector2(0, -fallSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (dealDamage)
            {
                PlayerStats playerStats = collision.GetComponent<PlayerStats>();
                if (playerStats != null)
                {
                    playerStats.TakeDamage(damageAmount);
                }
            }

            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
