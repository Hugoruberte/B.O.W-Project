using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //targetPointValue
    public int pointValue;

    //when collided with arrow
    private void ApplyDamage()
    {
        if (ScoreHandler.instance != null)
        {
            ScoreHandler.instance.AddScoreToPlayer(pointValue);
        }
        else
        {
            Debug.LogError("Singleton Score not in the scene !!");
        }

        DeathBehaviour();
    }

    protected void DeathBehaviour()
    {
        Destroy(gameObject);
    }
}
