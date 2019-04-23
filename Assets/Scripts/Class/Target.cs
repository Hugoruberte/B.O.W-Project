﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

public abstract class Target : MonoBehaviour
{
	//targetPointValue
	[SerializeField, Range(1, 1000)] private int pointValue = 10;

    private TargetManager targetManager;

	protected Renderer rend;
	protected ParticleSystem deathParticle;

	protected virtual void Awake()
	{
		this.rend = GetComponentInChildren<Renderer>();
		this.deathParticle = this.GetComponentInChildrenWithName<ParticleSystem>("Death");
	}

    private void Start()
    {
        targetManager = TargetManager.instance;
        targetManager.RegisterNewTarget(gameObject);
    }

    //when collided with arrow
    private void ApplyDamage()
	{
		ScoreHandler.instance.AddScoreToPlayer(this.pointValue);

		ScreenShakeVR.TriggerShake(5f, 3f);


        targetManager.RemoveTarget(gameObject);

		this.DeathBehaviour();
	}

	protected abstract void DeathBehaviour();
}
