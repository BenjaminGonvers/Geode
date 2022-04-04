using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "GrassLevel1";

    public SceneFader sceneFader;

    public void PlayGame()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
