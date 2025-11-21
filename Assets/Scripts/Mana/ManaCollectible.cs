using UnityEngine;

public class ManaCollectible : MonoBehaviour
{
    [SerializeField] private float manaValue;
    [SerializeField] private AudioClip ManaSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(ManaSound);
            collision.GetComponent<Mana>().AddMana(manaValue);
            gameObject.SetActive(false);
        }
    }
}
