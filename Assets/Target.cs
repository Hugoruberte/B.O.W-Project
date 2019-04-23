using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	//targetPointValue
	[SerializeField, Range(1, 1000)] private int pointValue = 10;

    private TargetManager targetManager;

    private void Start()
    {
        targetManager = TargetManager.instance;
        if(targetManager != null)
        {
            targetManager.RegisterNewTarget(gameObject);
        }
    }

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

        if (targetManager != null)
        {
            targetManager.RemoveTarget(gameObject);
        }


		ScreenShakeVR.TriggerShake(5f, 3f);

		this.DeathBehaviour();
	}

	protected virtual void DeathBehaviour()
	{
		Destroy(gameObject);
	}
}
