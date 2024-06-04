/*
 Autheur: Sven Nieuwenhuizen
 Onderwerp: Mainmenu Script SkyHop
 Datum: 04-05-2024
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("SkyHop");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
}
