using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;


    void Start()
    {
        totalhealthBar.fillAmount = (float)0.6;
    }

    void Update()
    {
        currenthealthBar.fillAmount = (float)playerHealth.currentHealth;
    }
}
