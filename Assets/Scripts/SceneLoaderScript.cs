using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
   
    public void LoadNextScene()
    {
        GameSession gameStatus = FindObjectOfType<GameSession>();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        GameSession currStatus = FindObjectOfType<GameSession>();
        
        gameStatus.RestoreBalls();

    }

    public void GoToStartScene()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene(0);        

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
