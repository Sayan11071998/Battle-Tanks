using UnityEngine;

public abstract class BulletView : MonoBehaviour
{
    [SerializeField] protected TrailRenderer trailRenderer;
    [SerializeField] protected ParticleSystem muzzleFlash;
    [SerializeField] protected ParticleSystem impactEffect;
    [SerializeField] protected AudioSource flybySound;
    [SerializeField] protected AudioSource impactSound;

    protected BulletModel model;

    public virtual void Initialize(BulletModel bulletModel)
    {
        model = bulletModel;

        if (muzzleFlash != null)
            muzzleFlash.Play();
    }

    public virtual void PlayImpactEffect(Vector3 position)
    {
        if (impactEffect != null)
        {
            Instantiate(impactEffect, position, Quaternion.identity);
        }

        if (impactSound != null)
        {
            impactSound.Play();
        }
    }
}