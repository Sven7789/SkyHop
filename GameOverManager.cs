/*
 Autheur: Sven Nieuwenhuizen
 Onderwerp: GameOverManager Script
 Datum: 27-05-2024
 */
using UnityEngine;
using UnityEngine.UI; // Voor Button

public class GameOverManager : MonoBehaviour
{
    public GameObject GameOver; // Verwijzing naar het Game Over Canvas
    public Button BackToMain; // Verwijzing naar de BackToMain knop
    public Button Retry; // Verwijzing naar de Retry knop

    void Start()
    {
        // Zorg ervoor dat het Game Over Canvas en de knoppen in het begin uitgeschakeld zijn
        GameOver.SetActive(false);
        BackToMain.gameObject.SetActive(false);
        Retry.gameObject.SetActive(false);
    }

    public void ShowGameOverScreen()
    {
        // Activeer het Game Over Canvas en de knoppen
        GameOver.SetActive(true);
        BackToMain.gameObject.SetActive(true);
        Retry.gameObject.SetActive(true);
    }
}
