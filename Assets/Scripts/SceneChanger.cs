using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitScene()
    {
        Application.Quit();
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void WinScene()
    {
        SceneManager.LoadScene("Win Scene");
    }
}
