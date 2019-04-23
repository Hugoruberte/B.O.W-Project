using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : Singleton<GameModeManager>
{
    //manager & handler

    private TargetManager targetManager;
    private LeaderBoardSaver leaderBoardSaver;

    private float startGameTime;
    private bool gameIsOver;


    [SerializeField] private TimeData timeData = null;



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
            Debug.Log("start game");
            targetManager.ActivateTargets();
        }

        startGameTime = Time.time;
        gameIsOver = false;
    }

    private void Update()
    {
        if(startGameTime == 0f)
        {
            return;
        }
        if (!gameIsOver)
        {
            timeData.time = Time.time - startGameTime;
        }
    }

    //end of game
    public void EndGame()
    {
        timeData.time = Time.time - startGameTime;
        leaderBoardSaver.AddScore(timeData.time);
        gameIsOver = true;

        UIHandler.instance.DisplayWin();
    }

    public void AddTime(float penality)
    {
        startGameTime -= penality;
    }
}
