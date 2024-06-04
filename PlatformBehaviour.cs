/*
 Autheur: Sven Nieuwenhuizen
 Onderwerp: Platformbehaviour Script SkyHop
 Datum: 27-05-2024
 */
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    //Player landed opgeven als speler op platform staat
    private bool playerLanded = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Score toevoegen als speler op een nieuw platform staat
        if (collision.gameObject.CompareTag("Player") && !playerLanded)
        {
            playerLanded = true;
            ScoreManager.Instance.AddScore(1);
        }
    }
}
