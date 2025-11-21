using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 2f;
    [SerializeField] private double contactDamage = 0.2;
    [SerializeField] private float damageCooldown = 1f;

    private Transform targetPoint;
    private float lastDamageTime;
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        targetPoint = pointB;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

        if (animator != null)
            animator.SetBool("walk", true); // começa andando
    }

    void Update()
    {
        MoveBetweenPoints();
    }

    private void MoveBetweenPoints()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        // Sempre que está andando, garante que a animação "walk" está ativa
        if (animator != null)
            animator.SetBool("walk", true);

        // Quando chega ao destino, troca de ponto e inverte o sprite
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            targetPoint = targetPoint == pointA ? pointB : pointA;

            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TryDamage(other);
        }
    }

    private void TryDamage(Collider2D other)
    {
        if (Time.time - lastDamageTime < damageCooldown) return;

        var playerHealth = other.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(contactDamage);
            lastDamageTime = Time.time;
        }
    }
}
