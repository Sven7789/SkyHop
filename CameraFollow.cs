using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // De speler die de camera moet volgen
    public float smoothSpeed = 0.125f; // De snelheid van de camera beweging
    public Vector3 offset; // De offset van de camera positie ten opzichte van de speler

    void LateUpdate()
    {
        // Volg alleen de speler omhoog (y-as), de x-as blijft hetzelfde
        Vector3 desiredPosition = new Vector3(transform.position.x, player.position.y + offset.y, transform.position.z);

        // Gebruik Lerp voor een soepele overgang
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Alleen de camera omhoog laten bewegen als de speler hoger is dan de camera
        if (smoothedPosition.y > transform.position.y)
        {
            transform.position = smoothedPosition;
        }
    }
}
