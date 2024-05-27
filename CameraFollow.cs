using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // De speler die de camera moet volgen
    public float smoothSpeed = 0.125f; // De snelheid van de camera beweging
    public Vector3 offset; // De offset van de camera positie ten opzichte van de speler
    public float gameOverY = -10f; // De y-positie waarbij het game over is

    private bool gameOver = false; // Bool om bij te houden of het game over is
    private GameOverManager gameOverManager; // Verwijzing naar de GameOverManager

    void Start()
    {
        // Vind de GameOverManager in de scene
        gameOverManager = FindObjectOfType<GameOverManager>();
    }

    void LateUpdate()
    {
        if (!gameOver) // Controleer alleen als het nog geen game over is
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

            // Controleer of de speler onder de camera is gekomen
            if (player.position.y < transform.position.y + gameOverY)
            {
                Debug.Log("Game Over!"); // Voer acties uit voor game over (bijvoorbeeld: toon een game over scherm, laad een ander level, etc.)
                gameOver = true; // Markeer het als game over
                gameOverManager.ShowGameOverScreen(); // Activeer het game over scherm
            }
        }
    }
}
