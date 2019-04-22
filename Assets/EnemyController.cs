using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
	[Header("Run towards")]
	[SerializeField] private Transform target = null;

	[Header("Data")]
	[SerializeField] private EnemyControllerData data = null;

	private Transform tr;
	private Rigidbody rb;
	private Animator anim;
	private Vector3 direction;

	void Awake()
	{
		this.tr = transform;
		this.rb = GetComponent<Rigidbody>();
		this.anim = GetComponentInChildren<Animator>();

		if(this.target == null) {
			Debug.LogWarning("WARNING : Target is null", transform);
		}
	}

	void Start()
	{
		this.anim.SetTrigger("TransitionToAlert");
		StartCoroutine(this.StartRunningCoroutine());
	}

	private IEnumerator StartRunningCoroutine()
	{
		while(this.anim.GetFloat("SpeedPercent") < 0.99f) {
			this.anim.SetFloat("SpeedPercent", 1f, this.data.smoothRun, Time.deltaTime);
			yield return null;
		}

		this.anim.SetFloat("SpeedPercent", 1f);
	}

	void FixedUpdate()
	{
		Vector3 aim = this.target.position;
		aim.Set(aim.x, this.tr.position.y, aim.z);

		this.direction = (aim - this.tr.position).normalized;

		this.tr.rotation = Quaternion.LookRotation(this.direction);
		this.rb.AddForce(this.direction * this.data.speed, ForceMode.Force);

		this.anim.speed = this.data.animationSpeedCurve.Evaluate(this.rb.velocity.magnitude);
	}

    public void SetTarget(Transform targetToReached)
    {
        target = targetToReached;
    }
}
