using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPiercingBulletView : BulletView
{
    [SerializeField] private TrailRenderer penetrationTrail;

    public override void PlayImpactEffect(Vector3 position)
    {
        base.PlayImpactEffect(position);

        if (penetrationTrail != null)
            penetrationTrail.emitting = true;
    }
}