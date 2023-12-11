using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField]
    private string firstLevel;

    private SFXManager sfxManager;

    void Start()
    {
        sfxManager = SFXManager.Instance;
        sfxManager.PlayAudio(AudioType.ST_MAIN_MENU);
    }

    public void EnterGame() 
    {
        LoadScene(firstLevel);
        sfxManager.PlayAudio(AudioType.ST_MAIN_SOUNDTRACK);
    }


    private void LoadScene(string scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game!");
    }
}

