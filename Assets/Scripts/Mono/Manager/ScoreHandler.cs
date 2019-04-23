using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

public class ScoreHandler : Singleton<ScoreHandler>
{
	[Header("Parameters")]
	public int winScore = 0;

	[Header("Score Scriptable Object")]
	[SerializeField] private ScoreData scoreData = null;

	protected override void Awake()
	{
		base.Awake();

		this.scoreData.Initialize();
	}

	void Start()
	{
		this.scoreData.score = 0;
	}

	public void AddScoreToPlayer(int score)
	{
		this.scoreData.score += score;

		if(this.scoreData.score >= winScore) {
			//win function...

			Debug.Log("You Win !");
		}
	}

}
