using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameStatus gameStatus;
    private void Awake()
    {
        gameStatus = FindObjectOfType<GameStatus>();
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
        gameStatus.ResetGame();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
