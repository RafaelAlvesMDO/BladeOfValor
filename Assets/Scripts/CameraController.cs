using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private Transform player;
    [SerializeField] private Tilemap map;
    [SerializeField] private float smoothTime = 0.2f;

    private float minX;
    private float maxX;
    private Vector3 velocity = Vector3.zero;
    private float halfCameraWidth;

    void Start()
    {
        // Find the Player again when change scenes
        player = GameObject.FindWithTag("Player")?.transform;

        Camera cam = Camera.main;
        halfCameraWidth = cam.orthographicSize * cam.aspect;

        if (map == null)
            map = FindObjectOfType<Tilemap>();

        if (map != null)
        {
            Bounds mapBounds = map.localBounds;
            minX = mapBounds.min.x + halfCameraWidth;
            maxX = mapBounds.max.x - halfCameraWidth;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Update references when changing scenes
        player = GameObject.FindWithTag("Player")?.transform;
        map = FindObjectOfType<Tilemap>();

        if (map != null)
        {
            Bounds mapBounds = map.localBounds;
            minX = mapBounds.min.x + halfCameraWidth;
            maxX = mapBounds.max.x - halfCameraWidth;
        }
    }

    void Update()
    {
        if (player == null)
            return;

        float targetX = Mathf.Clamp(player.position.x, minX, maxX);
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
