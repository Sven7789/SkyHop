using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject GameOver; // Verwijzing naar het Game Over Canvas

    void Start()
    {
        // Zorg ervoor dat het Game Over Canvas in het begin uitgeschakeld is
        GameOver.SetActive(false);
    }

    public void ShowGameOverScreen()
    {
        // Activeer het Game Over Canvas
        GameOver.SetActive(true);
    }
}
