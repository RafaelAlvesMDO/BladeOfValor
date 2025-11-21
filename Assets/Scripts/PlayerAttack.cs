using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Cooldowns")]
    private float attackCooldown = 0.6f;
    private float airSlashCooldown = 3f;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private Mana mana;

    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float attackDamage = 1f;

    [Header("References")]
    [SerializeField] private Transform startPoint; // Origin point of the Air Slash attack
    [SerializeField] private GameObject[] airSlashes; 
    private Animator anim;

    [SerializeField] private AudioClip SwordHitSound;
    [SerializeField] private AudioClip AirSlashSound;

    private void Awake()
    {
        // Make the player persist between scenes
        DontDestroyOnLoad(gameObject);

        // Search for the references if isn't assigned
        if (startPoint == null)
        {
            startPoint = transform.Find("StartPoint");
            if (startPoint == null)
                Debug.LogError("StartPoint not found! Create 'StartPoint' in Player.");
        }

        if (airSlashes == null || airSlashes.Length == 0)
            Debug.LogWarning("AirSlashes not assigned. Add at least 1 prefab/object in the array.");
    }

    private void Start()
    {
        // Gets the Player Animator
        anim = GetComponent<Animator>();
        if (anim == null)
            Debug.LogError("Animator cannot found the Player!");
        
        if (mana == null)
            mana = GetComponent<Mana>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && cooldownTimer >= attackCooldown)
            Attack();

        if (Input.GetKey(KeyCode.Q) && cooldownTimer >= airSlashCooldown)
            AirSlash();
    }

    private void Attack()
    {
        SoundManager.instance.PlaySound(SwordHitSound);
        if (anim != null)
        {
            anim.SetTrigger("attack");
            cooldownTimer = 0;
        }
    }

    private void AirSlash()
    {
        SoundManager.instance.PlaySound(AirSlashSound);
        double manaCost = 0.2;

        if (mana == null)
        {
            Debug.LogWarning("Mana não encontrada no Player!");
            return;
        }

        if (mana.currentMana <= 0)
        {
            Debug.Log("Mana insuficiente para usar AirSlash!");
            return;
        }

        mana.UseMana(manaCost);

        if (anim != null)
        {
            anim.SetTrigger("attack");
            anim.SetTrigger("airSlash");
        }

        if (startPoint == null || airSlashes == null || airSlashes.Length == 0)
            return; // Avoid NullReference

        int index = FindAvailableAirSlash();
        GameObject airSlashObj = airSlashes[index];

        if (airSlashObj != null)
        {
            airSlashObj.transform.position = startPoint.position;
            var airSlashScript = airSlashObj.GetComponent<AirSlashProjectile>();
            if (airSlashScript != null)
                airSlashScript.SetDirection(Mathf.Sign(transform.localScale.x));
            else
                Debug.LogWarning("AirSlashProjectile not found in AirSlash object.");
        }

        cooldownTimer = 0;
    }

    private int FindAvailableAirSlash()
    {
        for (int i = 0; i < airSlashes.Length; i++)
        {
            if (!airSlashes[i].activeInHierarchy)
                return i;
        }

        return 0;
    }

    public void DealDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(startPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

}
