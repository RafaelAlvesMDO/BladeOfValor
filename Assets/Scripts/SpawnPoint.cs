using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Search Spawnpoint in the new scene
        GameObject spawn = GameObject.Find("PlayerSpawn");
        if (spawn != null)
        {
            transform.position = spawn.transform.position;
        }
    }

    void OnDestroy()
    {
        // Evita vazamento de evento
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
