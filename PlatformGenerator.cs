/*
 Autheur: Sven Nieuwenhuizen
 Onderwerp: PlatformGenerator Script
 Datum: 27-05-2024
 */
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject movingPlatformPrefab;
    public int numberOfPlatforms = 20;
    public float minY = 1f;
    public float maxY = 3f;
    public Transform startPlatform; // De referentie naar het beginplatform
    public float movingPlatformSpawnProbability = 0.2f; // Kans om een bewegend platform te spawnen

    private float screenHalfWidth;
    private float platformHalfWidth;
    private Vector3 spawnPosition = new Vector3();
    private Queue<GameObject> platforms = new Queue<GameObject>();

    void Start()
    {
        // Bereken de helft van de schermbreedte in wereldunits
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        platformHalfWidth = platformPrefab.transform.localScale.x / 2;

        spawnPosition.y = startPlatform.position.y;

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        if (platforms.Peek().transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize - platformHalfWidth)
        {
            Destroy(platforms.Dequeue());
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        spawnPosition.y += Random.Range(minY, maxY); // Verhoog de y-positie
        spawnPosition.x = Random.Range(-screenHalfWidth + platformHalfWidth, screenHalfWidth - platformHalfWidth); // Random x-positie binnen het scherm

        GameObject platform;

        // Spawn een bewegend platform met een bepaalde kans
        if (Random.value < movingPlatformSpawnProbability)
        {
            platform = Instantiate(movingPlatformPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }

        // Voeg een BoxCollider2D toe voor de bovenkant detectie
        GameObject topCollider = new GameObject("TopCollider");
        topCollider.transform.SetParent(platform.transform);
        topCollider.transform.localPosition = Vector3.zero;
        BoxCollider2D topBoxCollider = topCollider.AddComponent<BoxCollider2D>();
        topBoxCollider.isTrigger = true;
        topBoxCollider.size = new Vector2(platformPrefab.transform.localScale.x, 0.1f); // Pas de grootte aan naar behoefte
        topCollider.AddComponent<PlatformTopDetector>();

        platforms.Enqueue(platform);
    }
}

public class PlatformTopDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(transform.parent);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
