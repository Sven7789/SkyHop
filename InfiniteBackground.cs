/*
 Autheur: Sven Nieuwenhuizen
 Onderwerp: InfiniteBackground Script
 Datum: 04-05-2024
 */
using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    public Transform cameraTransform; // De referentie naar de camera
    private Vector3 initialOffset;

    void Start()
    {
        // Bereken de initiële offset tussen de achtergrond en de camera
        initialOffset = transform.position - cameraTransform.position;
    }

    void LateUpdate()
    {
        // Update de positie van de achtergrond om de offset te behouden
        transform.position = cameraTransform.position + initialOffset;
    }
}
