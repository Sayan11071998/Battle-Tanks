using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighExplosiveBulletView : BulletView
{
    [SerializeField] private ParticleSystem explosionEffect;

    public override void PlayImpactEffect(Vector3 position)
    {
        base.PlayImpactEffect(position);

        if (explosionEffect != null)
            Instantiate(explosionEffect, position, Quaternion.identity);
    }
}