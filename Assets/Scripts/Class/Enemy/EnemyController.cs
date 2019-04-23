using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    public Animator anim { get; private set; }

    [Header("Run towards")]
    [SerializeField] private Transform target = null;

    [Header("Data")]
    public EnemyControllerData data;

    private Transform tr;
    private Rigidbody rb;
    private Vector3 direction;
    private EnemyTarget enemyTarget;


    void Awake()
    {
        this.tr = transform;
        this.rb = GetComponent<Rigidbody>();
        this.anim = GetComponentInChildren<Animator>();
        this.enemyTarget = GetComponent<EnemyTarget>();

        if (this.target == null)
        {
            Debug.LogWarning("WARNING : Target is null", transform);
        }
    }

    void Start()
    {
        this.anim.SetTrigger("TransitionToAlert");
        StartCoroutine(this.StartRunningCoroutine());
    }

    private IEnumerator StartRunningCoroutine()
    {
        while (this.anim.GetFloat("SpeedPercent") < 0.99f)
        {
            this.anim.SetFloat("SpeedPercent", 1f, this.data.smoothRun, Time.deltaTime);
            yield return null;
        }

        this.anim.SetFloat("SpeedPercent", 1f);
    }

    void FixedUpdate()
    {
        Vector3 aim = this.target.position;
        aim.Set(aim.x, this.tr.position.y, aim.z);

        this.direction = aim - this.tr.position;

        this.tr.rotation = Quaternion.LookRotation(this.direction);
        this.rb.AddForce(this.direction.normalized * this.data.speed, ForceMode.Force);

        this.anim.speed = this.data.animationSpeedCurve.Evaluate(this.rb.velocity.magnitude);

        if (this.direction.magnitude < this.data.threshold)
        {
            this.ReachedTarget();
        }
    }

    public void SetTarget(Transform targetToReached)
    {
        target = targetToReached;
    }

    private void ReachedTarget()
    {
        this.enemyTarget.DeathBehaviour();

        GameModeManager.instance.AddTime(this.data.reachPenality);
    }
}
