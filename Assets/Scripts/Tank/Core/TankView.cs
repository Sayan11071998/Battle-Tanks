using UnityEngine;

public abstract class TankView : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected ParticleSystem explosionEffect;
    [SerializeField] protected ParticleSystem damageEffect;
    [SerializeField] protected AudioSource engineAudio;
    [SerializeField] protected AudioSource fireAudio;
    [SerializeField] protected AudioSource hitAudio;
    [SerializeField] protected AudioSource explosionAudio;

    protected TankModel model;

    public virtual void Initialize(TankModel tankModel)
    {
        model = tankModel;

        model.OnHealthChanged += UpdateHealthVisuals;
        model.OnDestroyed += PlayDestroyEffects;
    }

    protected virtual void UpdateHealthVisuals(float current, float max)
    {
        if (current < max * 0.5f && !damageEffect.isPlaying)
        {
            damageEffect.Play();
        }
    }

    protected virtual void PlayDestroyEffects()
    {
        if (explosionEffect != null)
            explosionEffect.Play();

        if (explosionAudio != null)
            explosionAudio.Play();
    }

    public virtual void PlayFireEffect()
    {
        if (fireAudio != null)
            fireAudio.Play();
    }

    public virtual void PlayHitEffect()
    {
        if (hitAudio != null)
            hitAudio.Play();
    }

    protected virtual void OnDestroy()
    {
        if (model != null)
        {
            model.OnHealthChanged -= UpdateHealthVisuals;
            model.OnDestroyed -= PlayDestroyEffects;
        }
    }
}