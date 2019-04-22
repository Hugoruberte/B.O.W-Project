using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ScoreData", menuName = "Scriptable Object/Data/ScoreData", order = 1)]
public class ScoreData : ScriptableObject
{
	[System.NonSerialized] private int _score = 0;
	public int score {
		get { return this._score; }
		set {
			this._score = value;
			this.onScoreUpdate.Invoke();
		}
	}

	[System.NonSerialized] public UnityEvent onScoreUpdate;


	public void Initialize()
	{
		this.onScoreUpdate = new UnityEvent();
	}
}