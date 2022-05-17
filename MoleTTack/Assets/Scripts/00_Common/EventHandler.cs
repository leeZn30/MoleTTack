using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventHandler : MonoBehaviour
{
    public void loadScene(int scenenumber)
    {
        SceneManager.LoadScene(scenenumber);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
