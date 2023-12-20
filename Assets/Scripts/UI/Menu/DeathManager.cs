using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject deathMenuUI;
    public void ReloadTheScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Revive() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Pause()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game!");
    }
}
