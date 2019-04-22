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
	private Animator anim;
	private Renderer rend;
	private ParticleSystem deathParticle;

	private const float DELAY_BEFORE_FADE_AWAY = 0.625f;

	void Awake()
	{
		this.enemyController = GetComponent<EnemyController>();
		this.rb = GetComponent<Rigidbody>();
		this.cl = GetComponent<Collider>();
		this.rend = GetComponentInChildren<Renderer>();
		this.deathParticle = this.GetComponentInChildrenWithName<ParticleSystem>("Death");
		this.anim = this.enemyController.anim;
	}

	protected override void DeathBehaviour()
	{
		this.enemyController.StopAllCoroutines();
		this.enemyController.enabled = false;

		this.rb.velocity = Vector3.zero;
		this.rb.constraints = RigidbodyConstraints.FreezeAll;
		this.cl.enabled = false;

		this.anim.speed = 0.875f;
		this.anim.SetTrigger("Death");
		this.deathParticle.Play();

		this.StartCoroutine(this.DeathCoroutine());
	}

	private IEnumerator DeathCoroutine()
	{
		Color from, to, color;
		float step;

		yield return Yielders.Wait(DELAY_BEFORE_FADE_AWAY);

		// fade away
		from = this.rend.material.GetColor("_Color");
		to = new Color(from.r, from.g, from.b, 0f);
		step = 0f;
		while(step < 1f) {
			step += this.enemyController.data.fadeSpeed * Time.deltaTime;
			color = Color.Lerp(from, to, step);
			this.rend.material.SetColor("_Color", color);
			yield return null;
		}
		
		Destroy(gameObject, 5f);
	}

	void Update()
	{
		if(Input.GetKeyDown("space")) {
			this.DeathBehaviour();
		}
	}
}
