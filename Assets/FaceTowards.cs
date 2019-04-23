using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTowards : MonoBehaviour
{
    private Transform target;
    private Transform myTransform;
    private readonly Vector3 up = Vector3.up;

    private void Awake()
    {
        this.myTransform = transform;
        this.target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        this.myTransform.LookAt(this.target, this.up);
    }
}
