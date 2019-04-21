using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SplineController)), CanEditMultipleObjects]
public class SplineControllerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		SplineController script = (SplineController)target;

		DrawDefaultInspector();

		if(GUILayout.Button("Reset")) {
			Undo.RecordObject(script, "Reset point");

			script.points.Clear();

			Vector3 pos = script.transform.position;

			script.points.Add(pos + Vector3.right * 1f);
			script.points.Add(pos - Vector3.right * 1f);
		}
	}

	protected virtual void OnSceneGUI()
	{
		SplineController script = (SplineController)target;

		for(int i = 0; i < script.points.Count; i++) {

			EditorGUI.BeginChangeCheck();

			Vector3 newPoint = Handles.PositionHandle(script.GetPointRelative(i), Quaternion.identity);
		
			if(EditorGUI.EndChangeCheck()) {
				Undo.RecordObject(script, "Change point");

				script.points[i] = script.SetPointRelative(newPoint);
			}
		}
	}
}