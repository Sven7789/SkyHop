/*
 Autheur: Sven Nieuwenhuizen
 Onderwerp: PlayerController
 Datum: 27-05-2024
 */
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;

    private float screenHalfWidthInWorldUnits;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float halfPlayerWidth = transform.localScale.x / 2;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }

    void Update()
    {
        // Springen
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
        }

        // Bewegen naar links en rechts
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Schermwrapping
        WrapAroundScreen();
    }

    private void WrapAroundScreen()
    {
        Vector3 newPosition = transform.position;

        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            newPosition.x = screenHalfWidthInWorldUnits;
        }
        else if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            newPosition.x = -screenHalfWidthInWorldUnits;
        }

        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }
}
