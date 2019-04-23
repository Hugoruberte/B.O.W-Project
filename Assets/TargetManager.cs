using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Tools;

public class TargetManager : Singleton<TargetManager>
{
    public UnityEvent onStartGame = new UnityEvent();
    private GameModeManager gameModeManager;

    private List<GameObject> targets = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        gameModeManager = GameModeManager.instance;
    }

    public void RegisterNewTarget(GameObject target)
    {
        Debug.Log("registered");
        targets.Add(target);
    }

    public void RemoveTarget(GameObject target)
    {
        targets.Remove(target);
        if (targets.Count <= 0)
        {
            Debug.Log("endGame");
            gameModeManager.EndGame();
        }
    }

    public void ActivateTargets()
    {
        foreach(GameObject go in targets)
        {
            go.SetActive(true);
        }

        onStartGame.Invoke();
    }

}
