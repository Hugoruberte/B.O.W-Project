using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTarget : Target
{
	protected override void DeathBehaviour()
	{
		this.rend.enabled = false;

		this.deathParticle.Play();

		Destroy(gameObject, 5f);
	}
}
