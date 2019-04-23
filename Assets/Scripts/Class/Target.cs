using UnityEngine;
using Tools;

public abstract class Target : MonoBehaviour
{
    private TargetManager targetManager;

	protected Renderer rend;
	protected ParticleSystem deathParticle;

	protected virtual void Awake()
	{
		this.rend = GetComponentInChildren<Renderer>();
		this.deathParticle = this.GetComponentInChildrenWithName<ParticleSystem>("Death");

        targetManager = FindObjectOfType<TargetManager>() as TargetManager;
        targetManager.RegisterNewTarget(gameObject);

        gameObject.SetActive(false);
    }

    //when collided with arrow
    private void ApplyDamage()
	{
      
		this.DeathBehaviour();
	}

	public virtual void DeathBehaviour()
    {
        targetManager.RemoveTarget(gameObject);
    }
}
