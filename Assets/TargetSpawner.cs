using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum difficulty
{
    UNKNOWNN,
    EASY,
    MODERATE,
    HARD
}

//Spawner but not used yet.
public class TargetSpawner : MonoBehaviour
{
    //public difficulty gameDifficulty;

    public GameObject[] targetsPrefab;

    public int targetNumber;

    public float initSpawnTime;

    public Vector3 posMin;

    public Vector3 posMax;

    private int targetCounter = 0;

    private WaitForSeconds waitBeforeSpawn;

    // Start is called before the first frame update
    void Start()
    {
        waitBeforeSpawn = new WaitForSeconds(initSpawnTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void BeginGame()
    {
        StartCoroutine(SpawnTarget());
    }

    //spawn a new target.
    void FindSpawnLocation()
    {

    }

    IEnumerator SpawnTarget()
    {
        while(true)
        {
            yield return waitBeforeSpawn; 
        }
        
    }
}
