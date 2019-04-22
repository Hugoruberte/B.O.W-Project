using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

public class ScoreHandler : Singleton<ScoreHandler>
{
    public int winScore = 0;
    private int playerScore = 0;

    public void AddScoreToPlayer(int score)
    {
        playerScore += score;
        if(playerScore >= winScore) {
            //win function...

            Debug.Log("You Win !");
        }
    }

}
