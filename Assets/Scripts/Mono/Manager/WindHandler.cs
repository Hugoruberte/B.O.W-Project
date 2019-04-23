using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

public class WindHandler : Singleton<WindHandler>
{
    public Vector3[] directions;
    public float minSpeed;
    public float maxSpeed;

    private Vector3 windForce;

    public float minWindTime;
    public float maxWindTime;

    private float windEndTime;

    [SerializeField] private WindData windData = null;

    // Start is called before the first frame update
    void Start()
    {
        calculateWindForce();
        calculateWindTime();
    }

    private void Update()
    {
        if(Time.time > windEndTime)
        {
            calculateWindForce();
            calculateWindTime();
        }
    }

    public Vector3 getWindForce()
    {
        return windForce;
    }

    private void calculateWindForce()
    {
        float windSpeed = Random.Range(minSpeed, maxSpeed);

        int indexDirection = Random.Range(0, directions.Length);
        Vector3 direction = directions[indexDirection];

        windData.wind = windSpeed;

        windForce = windSpeed * direction;
    }

    private void calculateWindTime()
    {
        windEndTime = Time.time + Random.Range(minWindTime, maxWindTime);
    }

}
