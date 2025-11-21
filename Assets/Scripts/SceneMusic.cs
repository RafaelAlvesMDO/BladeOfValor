using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    [SerializeField] private AudioClip sceneMusic;

    private void Start()
    {
        if (sceneMusic != null)
            SoundManager.instance.PlayMusic(sceneMusic);
    }
}