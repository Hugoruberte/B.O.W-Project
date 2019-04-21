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
            ScoreHandler.instance.playerScore += pointValue;
        }
        else
        {
            Debug.Log.Error("Singleton Score not in the scene !!");
        }

        DeathBehaviour();
    }

    protected void DeathBehaviour()
    {
        Destroy(gameObject);
    }
}
