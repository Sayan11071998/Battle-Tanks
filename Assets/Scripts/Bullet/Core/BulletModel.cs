using UnityEngine;

public abstract class BulletModel : MonoBehaviour
{
    public float damage;
    public float speed;
    public float lifetime;
    public LayerMask hitLayers;

    [HideInInspector]
    public Transform target;
    [HideInInspector]
    public TankModel shooter;

    protected float spawnTime;

    public virtual void Initialize(float damageValue, Transform targetTransform = null, TankModel shooterTank = null)
    {
        damage = damageValue;
        target = targetTransform;
        shooter = shooterTank;
        spawnTime = Time.time;
    }

    public bool ShouldDestroy()
    {
        return Time.time - spawnTime >= lifetime;
    }
}