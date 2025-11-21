using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private double startingHealth;
    public double currentHealth { get; private set; }

    private Animator anim;
    private bool dead;

    [SerializeField] private AudioClip HurtSound;
    [SerializeField] private AudioClip DeathSound;

    void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(double _damage)
    {
        currentHealth = Math.Clamp(currentHealth - _damage, 0.0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            SoundManager.instance.PlaySound(HurtSound);
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                SoundManager.instance.PlaySound(DeathSound);
            }
        }
    }

    // public void Respawn()
    // {
    //     dead = false;
    //     AddHealth(startingHealth);
    //     anim.Play("Idle");

    //     GetComponent<PlayerMovement>().enabled = true;
    // }

    public void Heal(double hp)
    {
        currentHealth = Math.Clamp(currentHealth + hp, 0.0, startingHealth);
    }

    public void AddHealth(double hp)
    {
        currentHealth = Math.Clamp(currentHealth + hp, 0.0, startingHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(0.2);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Heal(0.2);
        }
    }
}
