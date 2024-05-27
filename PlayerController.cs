/*
 Autheur: Sven Nieuwenhuizen
 Onderwerp: Playercontroller Script
 Datum: 27-05-2024
 */
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float screenHalfWidth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Bereken de halve breedte van het scherm
        screenHalfWidth = ScreenBounds.screenBounds.x;
    }

    void Update()
    {
        // Bewegen naar links en rechts met A en D
        float moveInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Springen met W of Space
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            Debug.Log("Jump activated");  // Debug bericht voor sprong
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        // Beperk de positie binnen het scherm
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -screenHalfWidth, screenHalfWidth);
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Landed on platform");
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Left platform");
            isGrounded = false;
        }
    }
}
