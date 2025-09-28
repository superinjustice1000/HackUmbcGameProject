using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{

    public void quit()
    {
        Application.Quit();
        Debug.Log("QUIT GAME!");
    }

    public void loadLevel(int level)
    {
        SceneManager.LoadSceneAsync(level);
    }

    public void resetLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
