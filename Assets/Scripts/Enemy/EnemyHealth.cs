using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Configurações de Vida")]
    [SerializeField] private float maxHealth = 1f;
    private float currentHealth;

    private Animator anim;
    private Rigidbody2D rb;
    private EnemyPatrol patrol;

    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        patrol = GetComponent<EnemyPatrol>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth > 0)
        {
            // Animação de dano
            anim.SetTrigger("hurt");
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} morreu!");

        // Impede o inimigo de continuar andando
        if (patrol != null)
            patrol.enabled = false;

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        // Desativa colisão
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;

        // Toca animação de morte
        anim.SetTrigger("die");

        // Desativa o script após a animação
        this.enabled = false;

        // Destroi o inimigo após um pequeno delay (tempo da animação)
        Destroy(gameObject, 0.5f);
    }
}
