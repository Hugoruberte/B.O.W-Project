using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : Singleton<GameModeManager>
{
    //manager & handler

    private TargetManager targetManager;
    private LeaderBoardSaver leaderBoardSaver;



    //timer for score
    private float gameTime;

    private float startGameTime;



    // Start is called before the first frame update
    void Start()
    {
        targetManager = TargetManager.instance;
        leaderBoardSaver = LeaderBoardSaver.instance;
        
    }

    //start of game
    public void StartGame()
    {
        if(targetManager != null)
        {
            targetManager.ActivateTargets();
        }

        startGameTime = Time.time;
    }

    //end of game
    public void EndGame()
    {
        string playerName = "roger";
        gameTime = Time.time - startGameTime;
        leaderBoardSaver.AddScore(playerName, gameTime);
    }

}
