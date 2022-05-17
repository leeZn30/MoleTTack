using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventHandler : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(360, 640, false);
    }

    public void loadScene(int scenenumber)
    {
        SceneManager.LoadScene(scenenumber);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
