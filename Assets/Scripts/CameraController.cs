using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Tilemap map;
    [SerializeField] private float smoothTime = 0.2f;

    private float minX;
    private float maxX;
    private Vector3 velocity = Vector3.zero;
    private float halfCameraWidth;

    void Start()
    {
        // Calculate Visible Camera Width
        Camera cam = Camera.main;
        halfCameraWidth = cam.orthographicSize * cam.aspect;

        // Get Tilemap Limit
        Bounds mapBounds = map.localBounds;

        // Horizontal Limit
        minX = mapBounds.min.x + halfCameraWidth;
        maxX = mapBounds.max.x - halfCameraWidth;
    }

    void Update()
    {
        if (player == null)
            return;

        // Limit Position X inside the Limits
        float targetX = Mathf.Clamp(player.position.x, minX, maxX);
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        // Smooth Moviment
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
