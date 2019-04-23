using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

public class TargetManager : Singleton<TargetManager>
{

    private GameModeManager gameModeManager;

    private List<GameObject> targets;

    

    // Start is called before the first frame update
    void Start()
    {
        gameModeManager = GameModeManager.instance;

        targets = new List<GameObject>();   
    }

    public void RegisterNewTarget(GameObject target)
    {
        targets.Add(target);
    }

    public void RemoveTarget(GameObject target)
    {
        targets.Remove(target);
        if (targets.Count <= 0)
        {
            gameModeManager.EndGame();
            
        }
    }

    public void ActivateTargets()
    {
        foreach(GameObject gameObject in targets)
        {
            gameObject.SetActive(true);
        }
        
    }

}
