using System;
using UnityEngine;

public abstract class TankModel : MonoBehaviour
{
    [Header("Base Stats")]
    public float maxHealth;
    public float currentHealth;
    public float moveSpeed;
    public float rotationSpeed;
    public float detectionRange;
    public float attackRange;
    public float fireRate;
    public int scoreValue;

    [Header("Weapon")]
    public BulletType bulletType;
    public Transform firePoint;
    public float bulletDamage;

    private float nextFireTime;

    public bool CanFire => Time.time >= nextFireTime;

    public event Action<float, float> OnHealthChanged;
    public event Action OnDestroyed;

    public virtual void Initialize()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            OnDestroyed?.Invoke();
        }
    }

    public virtual void ResetFireCooldown()
    {
        nextFireTime = Time.time + 1f / fireRate;
    }
}