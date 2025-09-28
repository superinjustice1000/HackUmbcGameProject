using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour
{

    [SerializeField] gameManager gameManagerLink;
    //public int loadlevelNumber;

    private void Start()
    {
        gameManagerLink = FindObjectOfType<gameManager>();
    }
    public void quit()
    {
        Application.Quit();
        Debug.Log("QUIT GAME!");
    }

    public void Restart()
    {
        gameManagerLink.resetLevel();
    }

    public void loadLevel(int level)
    {
        gameManagerLink.loadLevel(level);
    }
}
