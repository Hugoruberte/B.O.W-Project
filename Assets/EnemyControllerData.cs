using UnityEngine;

[CreateAssetMenu(fileName = "EnemyControllerData", menuName = "Scriptable Object/Data/EnemyControllerData", order = 1)]
public class EnemyControllerData : ScriptableObject
{
	[Header("Parameters")]
	[Range(0.1f, 20f)] public float speed = 5f;
	[Range(0.01f, 2f)] public float smoothRun = 1f;
	public AnimationCurve animationSpeedCurve = new AnimationCurve();
}