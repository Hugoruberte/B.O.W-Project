using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArrowUI : MonoBehaviour
{
    private WindHandler windHandler;
    private readonly Vector3 up = Vector3.up;
    private Quaternion target;

    [SerializeField] private Transform arrow = null;
    [SerializeField] private float omega = 10f;
    
    private void Start()
    {
        this.windHandler = WindHandler.instance;
    }

    private void Update()
    {
        this.target = Quaternion.LookRotation(this.windHandler.getWindForce(), this.up);

        if(Quaternion.Angle(this.arrow.rotation, this.target) > 0.1f)
        {
            // this.arrow.rotation = Quaternion.RotateTowards(this.arrow.rotation, this.target, this.omega * Time.deltaTime);
            this.arrow.rotation = Quaternion.Slerp(this.arrow.rotation, this.target, this.omega * Time.deltaTime);
        }
    }
}
