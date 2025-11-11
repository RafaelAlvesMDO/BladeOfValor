using UnityEngine;

public class GoldCollectible : MonoBehaviour
{
    [SerializeField] private int goldValue = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Gold>().AddGold(goldValue);
            gameObject.SetActive(false);
        }
    }
}
