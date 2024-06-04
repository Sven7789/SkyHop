/*
 Autheur: Sven Nieuwenhuizen
 Onderwerp: Platformbehaviour Script SkyHop
 Datum: 27-05-2024
 */
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    private bool playerLanded = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !playerLanded)
        {
            playerLanded = true;
            ScoreManager.Instance.AddScore(1);
        }
    }
}
