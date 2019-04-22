using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

[RequireComponent(typeof(EnemyController))]
public class Enemy : Target
{
	private EnemyController enemyController;
	private Rigidbody rb;
	private Collider cl;
	private Renderer rend;
	private ParticleSystem deathParticle;

	void Awake()
	{
		this.enemyController = GetComponent<EnemyController>();
		this.rb = GetComponent<Rigidbody>();
		this.cl = GetComponent<Collider>();
		this.rend = GetComponentInChildren<Renderer>();
		this.deathParticle = this.GetComponentInChildrenWithName<ParticleSystem>("Death");
	}

	protected override void DeathBehaviour()
	{
		this.enemyController.StopAllCoroutines();
		this.enemyController.enabled = false;

		this.rb.velocity = Vector3.zero;
		this.rb.constraints = RigidbodyConstraints.FreezeAll;
		this.cl.enabled = false;

		this.rend.enabled = false;
		this.deathParticle.Play();

		Destroy(gameObject, 7.5f);
	}

	void Update()
	{
		if(Input.GetKeyDown("space")) {
			this.DeathBehaviour();
		}
	}
}
