using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "WindData", menuName = "Scriptable Object/Data/WindData", order = 1)]
public class WindData : ScriptableObject
{
	[System.NonSerialized] private float _wind = 0f;
	public float wind {
		get { return this._wind; }
		set {
			this._wind = value;
		}
	}
}