using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource musicSound;
    [SerializeField] private AudioSource fxSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        fxSound.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSound.clip = clip;
        musicSound.Play();
    }
}