using UnityEngine;

[CreateAssetMenu(fileName = "EnemyControllerData", menuName = "Scriptable Object/Data/EnemyControllerData", order = 1)]
public class EnemyControllerData : ScriptableObject
{
	[Header("Run")]
	[Range(0.1f, 20f)] public float speed = 5f;
	[Range(0.01f, 2f)] public float smoothRun = 1f;
	public AnimationCurve animationSpeedCurve = new AnimationCurve();

	[Header("Death")]
	[Range(0.01f, 10f)] public float fadeSpeed = 1f;

    [Header("Reach")]
    [Range(0.01f, 20f)] public float threshold = 1f;
    [Range(0f, 10f)] public float reachPenality = 3f;
}