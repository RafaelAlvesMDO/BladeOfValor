using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    public static GoldUI Instance;

    [SerializeField] private TextMeshProUGUI goldAmount;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGoldUI(Gold.Instance.CurrentGold);
    }

    public void UpdateGoldUI(int amount)
    {
        goldAmount.text = amount.ToString();
    }
}
