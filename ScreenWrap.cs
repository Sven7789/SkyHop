/*
 Autheur: Sven Nieuwenhuizen
 Onderwerp:Screenwrap Script SkyHop
 Datum: 27-05-2024
 */
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private void Update()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        // Locatie speler berekenen door positie camera 
        if (viewportPosition.x < 0)
        {
            transform.position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x, transform.position.y, transform.position.z);
        }
        else if (viewportPosition.x > 1)
        {
            transform.position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x, transform.position.y, transform.position.z);
        }
    }
}
