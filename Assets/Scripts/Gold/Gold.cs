using UnityEngine;

public class Gold : MonoBehaviour
{
    public static Gold Instance; // Singleton simples para acesso global

    [SerializeField] private int startingGold = 0;
    public int CurrentGold { get; private set; }

    private void Awake()
    {
        // Garante que só exista um Gold ativo (não destrói ao mudar de cena)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CurrentGold = startingGold;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddGold(int amount)
    {
        CurrentGold += amount;
        // Atualiza o HUD se necessário
        GoldUI.Instance?.UpdateGoldUI(CurrentGold);
    }

    public void SpendGold(int amount)
    {
        if (CurrentGold >= amount)
        {
            CurrentGold -= amount;
            GoldUI.Instance?.UpdateGoldUI(CurrentGold);
        }
        else
        {
            Debug.Log("Ouro insuficiente!");
        }
    }
}