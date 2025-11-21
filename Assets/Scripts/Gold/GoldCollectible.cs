using UnityEngine;

public class GoldCollectible : MonoBehaviour
{
    [SerializeField] private int goldValue = 10;
    [SerializeField] private AudioClip CoinSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(CoinSound);
            collision.GetComponent<Gold>().AddGold(goldValue);
            gameObject.SetActive(false);
        }
    }
}
