using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTarget : Target
{
	public override void DeathBehaviour()
	{
        base.DeathBehaviour();

		this.rend.enabled = false;
        Collider cl = GetComponent<Collider>();

        cl.enabled = false;

		this.deathParticle.Play();

        SplineController spline = GetComponent<SplineController>();
        if(spline !=null)
        {
            spline.Stop();
        }

		Destroy(gameObject, 5f);
	}
}
