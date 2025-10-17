using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackCooldown = 0.6f;
    private float airSlashCooldown = 10;
    [SerializeField] private Transform startPoint;
    [SerializeField] private GameObject[] airSlashes;
    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
            Attack();

        if (Input.GetKey(KeyCode.Q) && cooldownTimer > airSlashCooldown)
            AirSlash();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }

    private void AirSlash()
    {
        anim.SetTrigger("attack");
        anim.SetTrigger("airSlash");
        cooldownTimer = 0;

        airSlashes[FindAirSlash()].transform.position = startPoint.position;
        airSlashes[FindAirSlash()].GetComponent<AirSlashProjectile>().SetDirection
        (Mathf.Sign(transform.localScale.x));
    }

    private int FindAirSlash()
    {
        for (int i = 0; i < airSlashes.Length; i++)
        {
            if (!airSlashes[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
