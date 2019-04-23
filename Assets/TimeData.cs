using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "TimeData", menuName = "Scriptable Object/Data/TimeData", order = 1)]
public class TimeData : ScriptableObject
{
	[System.NonSerialized] private float _time = 0f;
	public float time {
		get { return this._time; }
		set {
			this._time = value;
		}
	}
}