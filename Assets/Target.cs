using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	//targetPointValue
	[SerializeField, Range(1, 1000)] private int pointValue = 10;

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

		ScreenShakeVR.TriggerShake(5f, 3f);

		this.DeathBehaviour();
	}

	protected virtual void DeathBehaviour()
	{
		Destroy(gameObject);
	}
}
