using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int numberOfPlatforms = 20;
    public float minY = 1f;
    public float maxY = 3f;
    public Transform startPlatform; // De referentie naar het beginplatform

    private float screenHalfWidth;
    private float screenTopY;

    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        screenHalfWidth = ScreenBounds.screenBounds.x;
        screenTopY = ScreenBounds.screenBounds.y;

        // Start spawning just above the start platform
        spawnPosition.y = startPlatform.position.y;

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY); // Move upward
            spawnPosition.x = Random.Range(-screenHalfWidth, screenHalfWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
