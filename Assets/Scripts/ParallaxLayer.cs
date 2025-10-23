using UnityEngine;
using UnityEngine.SceneManagement;

public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private float parallaxMultiplier = 0.5f; 
    // 0.2 = Slowest | 0.5 = Average | 1 = Same speed as Camera
    private Transform cam;
    private Vector3 lastCamPosition;

    private void Start()
    {
        SetupCamera();
        
        // Detect a new loaded scene
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find Camera when Scene changes if it persist.
        SetupCamera();
    }

    private void SetupCamera()
    {
        if (Camera.main != null)
        {
            cam = Camera.main.transform;
            lastCamPosition = cam.position;
        }
        else
        {
            Debug.LogWarning($"[ParallaxLayer] cannot found any camera '{SceneManager.GetActiveScene().name}'.");
        }
    }

    private void LateUpdate()
    {
        if (cam == null)
            return;

        // Calculate how much the camera moved since the last frame
        Vector3 deltaMovement = cam.position - lastCamPosition;

        // Move the layer properly
        transform.position += new Vector3(deltaMovement.x * parallaxMultiplier, deltaMovement.y * parallaxMultiplier, 0);

        lastCamPosition = cam.position;
    }
}
