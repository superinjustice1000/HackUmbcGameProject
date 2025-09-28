using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public int gameScore;
    [SerializeField] int winScore;
    public Canvas winMenu;
    [SerializeField] GameObject playerLink;
    [SerializeField] playerControls playerControlsLink;

    private void Awake()
    {
        winMenu.enabled = false;
        Time.timeScale = 1.0f;
        playerLink = GameObject.Find("Player");
        playerControlsLink = playerLink.GetComponent<playerControls>();
        playerControlsLink.enabled = true;
    }


    public void increaseScore(int score)
    {
        gameScore += score;
    }

    public void decreaseScore(int score)
    {
        gameScore -= score;
    }

    public int getGameScore() { return gameScore; }

    public void resetScore()
    {
        gameScore = 0;
        Debug.Log("GAME SOCRE RESET!!!");    
    }

    public void gameWin()
    {
        if(winScore == gameScore) 
        {
            Debug.Log("GAME WIN");
            Time.timeScale = 0f;
            winMenu.enabled = true;
            playerControlsLink.enabled = false;
        }
    }

    private void Update()
    {
        gameWin();
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
