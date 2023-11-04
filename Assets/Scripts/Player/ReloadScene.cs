using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public string sceneNameToReload; // Specify the scene to reload in the Inspector

    public void ReloadTheScene()
    {
        SceneManager.LoadScene(sceneNameToReload);
    }
}
