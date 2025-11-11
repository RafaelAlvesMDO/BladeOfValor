using UnityEngine.UI;
using UnityEngine;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private Mana playerMana;
    [SerializeField] private Image totalmanaBar;
    [SerializeField] private Image currentmanaBar;


    void Start()
    {
        totalmanaBar.fillAmount = (float)0.6;
    }

    void Update()
    {
        currentmanaBar.fillAmount = (float)playerMana.currentMana;
    }
}
