using UnityEngine;

public class ManaCollectible : MonoBehaviour
{
    [SerializeField] private float manaValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Mana>().AddMana(manaValue);
            gameObject.SetActive(false);
        }
    }
}
