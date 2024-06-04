/*
 Autheur: Sven Nieuwenhuizen
 Onderwerp: MovingPlatform Script
 Datum: 27-05-2024
 */
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Snelheid van platform
    public float speed = 2f;
    //afstand die platform aflegd
    public float moveDistance = 3f;

    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Als platform naar rechts of links gaat geef snelheid en afstand mee
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= startPosition.x - moveDistance)
            {
                movingRight = true;
            }
        }
    }
}

