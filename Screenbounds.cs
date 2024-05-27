using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    public static Vector2 screenBounds;

    void Start()
    {
        Camera mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }
}
