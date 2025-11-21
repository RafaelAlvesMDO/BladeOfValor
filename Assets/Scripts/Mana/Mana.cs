using System;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] private double startingMana;
    public double currentMana { get; private set; }
    void Start()
    {
        currentMana = startingMana;
    }

    public void UseMana(double amount)
    {
        currentMana = Math.Clamp(currentMana - amount, 0.0, startingMana);
    }

    public void Meditate(double mana)
    {
        currentMana = Math.Clamp(currentMana + mana, 0.0, startingMana);
    }

    public void AddMana(double mana)
    {
        currentMana = Math.Clamp(currentMana + mana, 0.0, startingMana);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Meditate(0.2);
        }
    }
}
