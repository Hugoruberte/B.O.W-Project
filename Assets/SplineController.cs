using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SplineController : MonoBehaviour
{
	[Header("Parameters")]
	[SerializeField, Range(0.01f, 50f)] private float speed = 5f;
	[SerializeField, Range(0.1f, 2.5f)] private float threshold = 0.1f;
	[SerializeField, Range(0.001f, 2f)] private float smooth = 5f;

	[Header("Points")]
	public List<Vector3> points = new List<Vector3>();

	private int index = 0;
	private Vector3 target;
	private Vector3 aim;
	private Rigidbody rb;

	
	void Awake()
	{
		this.rb = GetComponent<Rigidbody>();
	}

	void Start()
	{
		this.index = 0;
		this.target = this.points[this.index];
		this.aim = (this.target - this.rb.position).normalized;
	}

	void FixedUpdate()
	{
		this.rb.velocity = this.GetNextVelocity();
	}

	public Vector3 GetNextVelocity()
	{
		// Reach target -> switch to next target
		if(Vector3.Distance(this.rb.position, this.target) < this.threshold) {

			this.index = (this.index + 1) % this.points.Count;
			this.target = this.points[this.index];
		}

		Vector3 direction = (this.target - this.rb.position).normalized;
		this.aim = Vector3.RotateTowards(this.aim, direction, this.smooth, 0.0f);

		return this.aim * this.speed;
	}
















	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(this.points[0], 0.25f);

		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(this.points[0], this.points[this.points.Count - 1]);

		for(int i = 1; i < this.points.Count; i++) {

			Gizmos.color = Color.red;
			Gizmos.DrawSphere(this.points[i], 0.25f);

			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(this.points[i - 1], this.points[i]);
		}
	}
}
