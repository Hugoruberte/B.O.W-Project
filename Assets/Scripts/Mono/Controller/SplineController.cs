using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SplineController : MonoBehaviour
{
	[Header("Parameters")]
	[SerializeField, Range(0.01f, 50f)] private float speed = 5f;
	[SerializeField, Range(0.1f, 2.5f)] private float threshold = 0.1f;
	[SerializeField, Range(0.001f, 20f)] private float smooth = 5f;
	[SerializeField] private bool isWorldRelative = false;

	[Header("Points")]
	public List<Vector3> points = new List<Vector3>();

	private int index = 0;
	private Vector3 origin;
	private Vector3 target;
	private Vector3 aim;
	private Rigidbody rb;

	
	void Awake()
	{
		this.rb = GetComponent<Rigidbody>();
	}

	void Start()
	{
		this.origin = transform.position;
		this.index = 0;
		this.target = this.GetPointRelative(this.index);
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
			this.target = this.GetPointRelative(this.index);
		}

		Vector3 direction = (this.target - this.rb.position).normalized;
		this.aim = Vector3.RotateTowards(this.aim, direction, this.smooth * Time.deltaTime, 0.0f);

		return this.aim * this.speed;
	}

	public Vector3 GetPointRelative(int i)
	{
		if(this.isWorldRelative) {
			return this.points[i];
		} else {
			if(Application.isPlaying) {
				return this.origin + this.points[i];
			} else {
				return transform.position + this.points[i];
			}
		}
	}

	public Vector3 SetPointRelative(Vector3 p)
	{
		if(this.isWorldRelative) {
			return p;
		} else {
			return p - transform.position;
		}
	}

    public void Stop()
    {
        this.enabled = false;
        this.rb.constraints = RigidbodyConstraints.FreezeAll;
        this.rb.velocity = Vector3.zero;
    }














	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(this.GetPointRelative(0), 0.25f);

		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(this.GetPointRelative(0), this.GetPointRelative(this.points.Count - 1));

		for(int i = 1; i < this.points.Count; i++) {

			Gizmos.color = Color.red;
			Gizmos.DrawSphere(this.GetPointRelative(i), 0.25f);

			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(this.GetPointRelative(i - 1), this.GetPointRelative(i));
		}
	}
}
