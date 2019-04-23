using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

[RequireComponent(typeof(EnemyController))]
public class EnemyTarget : Target
{
	private EnemyController enemyController;
	private Rigidbody rb;
	private Collider cl;

	protected override void Awake()
	{
		base.Awake();

		this.enemyController = GetComponent<EnemyController>();
		this.rb = GetComponent<Rigidbody>();
		this.cl = GetComponent<Collider>();

        gameObject.SetActive(true);
	}

	public override void DeathBehaviour()
	{
        base.DeathBehaviour();

		this.enemyController.StopAllCoroutines();
		this.enemyController.enabled = false;

		this.rb.velocity = Vector3.zero;
		this.rb.constraints = RigidbodyConstraints.FreezeAll;
		this.cl.enabled = false;

		this.rend.enabled = false;
		this.deathParticle.Play();

		Destroy(gameObject, 7.5f);
	}
}
