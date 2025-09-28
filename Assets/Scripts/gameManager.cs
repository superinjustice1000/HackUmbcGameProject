using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class gameManager : MonoBehaviour
{
    public int gameScore;
    [SerializeField] int winScore;
    public Canvas winMenu;
    [SerializeField] GameObject playerLink;
    [SerializeField] playerControls playerControlsLink;
    public TMP_Text TMPLink;

    private void Awake()
    {
        winMenu.enabled = false;
        Time.timeScale = 1.0f;
        playerLink = GameObject.Find("Player");
        playerControlsLink = playerLink.GetComponent<playerControls>();
        playerControlsLink.enabled = true;
        TMPLink.text = gameScore.ToString();
    }


    public void increaseScore(int score)
    {
        gameScore += score;
        TMPLink.text = gameScore.ToString();
    }

    public void decreaseScore(int score)
    {
        gameScore -= score;
        TMPLink.text = gameScore.ToString();
    }

    public int getGameScore() { return gameScore; }

    public void resetScore()
    {
        gameScore = 0;
        Debug.Log("GAME SCORE RESET!!!");
        TMPLink.text = gameScore.ToString();
    }

    public void gameWin()
    {
        if(winScore == gameScore) 
        {
            //Debug.Log("GAME WIN");
            Time.timeScale = 0f;
            winMenu.enabled = true;
            playerControlsLink.enabled = false;
        }
    }

    private void Update()
    {
        gameWin();
    }

    


}
