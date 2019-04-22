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

public class TargetSpawner : MonoBehaviour
{
    //public difficulty gameDifficulty;

    public GameObject Player;

    public GameObject[] targetsPrefab;

    public int targetNumber;

    public float initSpawnTime;

    private WaitForSeconds waitBeforeSpawn;

    public Vector3 Scale;

    private Vector3 minSpawn;

    private Vector3 maxSpawn;

    // Start is called before the first frame update
    void Start()
    {
        waitBeforeSpawn = new WaitForSeconds(initSpawnTime);

        minSpawn = transform.position - Scale/2;

        maxSpawn = transform.position + Scale/2;

        //to Remove
        BeginGame();

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
    Vector3 GetSpawnLocation(Vector3 min, Vector3 max)
    {
        float x_random = Random.Range(min.x, max.x);
        float y_random = Random.Range(min.y, max.y);
        float z_random = Random.Range(min.z, max.z);

        return new Vector3(x_random, y_random, z_random);
    }

    IEnumerator SpawnTarget()
    {
        int targetCount = 0;
        int targetIndex = 0;
        bool stopSpawn = false;
        while (true && !stopSpawn)
        {
            yield return waitBeforeSpawn;

            GameObject targetCopy = Instantiate(targetsPrefab[targetIndex], GetSpawnLocation(minSpawn, maxSpawn), new Quaternion());
            targetCopy.transform.LookAt(Player.transform);

            EnemyController enemyCopy = targetCopy.GetComponent<EnemyController>();
            if (enemyCopy != null)
            {
                enemyCopy.SetTarget(Player.transform);
            }

            targetCount++;
            targetIndex = targetCount % targetsPrefab.Length;
            if(targetCount >= targetNumber && targetNumber > 0)
            {
                stopSpawn = true;
            }
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, Scale);

    }
}