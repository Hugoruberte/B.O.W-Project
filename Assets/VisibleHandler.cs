using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleHandler : MonoBehaviour
{
    private float nextThresholdTime;

    public float upTime;

    public float downTime;

    public Transform targetBody;

    public Target currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        nextThresholdTime = Time.time + upTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetBody != null)
        {
            if (Time.time > nextThresholdTime)
            {
                bool currentBodyState = targetBody.gameObject.activeSelf;
                targetBody.gameObject.SetActive(!currentBodyState);

                //toTest
                currentTarget.enabled = !currentBodyState;

                if (currentBodyState)
                {
                    nextThresholdTime += downTime;
                }
                else
                {
                    nextThresholdTime += upTime;
                }

            }
        }
    }
}
