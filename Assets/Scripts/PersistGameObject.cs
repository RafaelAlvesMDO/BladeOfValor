using UnityEngine;

public class PersistGameObject : MonoBehaviour
{
     void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
