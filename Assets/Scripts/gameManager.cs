using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    int gameScore;
    
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
}
