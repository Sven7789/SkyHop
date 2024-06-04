/*
 Autheur: Sven Nieuwenhuizen
 Onderwerp: PlatformGenerator
 Datum: 27-05-2024
 */
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public int numberOfPlatforms = 20;
    public float minY = 1f;
    public float maxY = 3f;
    public Transform startPlatform; // De referentie naar het beginplatform

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
        platforms.Enqueue(Instantiate(platformPrefab, spawnPosition, Quaternion.identity));
    }
}
