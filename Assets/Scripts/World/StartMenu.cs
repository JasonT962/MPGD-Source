using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene(4);
    }

    public void PlayCredits()
    {
        SceneManager.LoadScene(5);
    }

    public void PlayStartMenu()
    {
        SceneManager.LoadScene(0);
    }
}
