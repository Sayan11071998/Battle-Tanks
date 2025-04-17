using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedMissileBulletView : BulletView
{
    [SerializeField] private ParticleSystem engineEffect;
    [SerializeField] private ParticleSystem guidanceActivatedEffect;

    public void ShowGuidanceActivated()
    {
        if (guidanceActivatedEffect != null)
            guidanceActivatedEffect.Play();
    }

    private void Start()
    {
        if (engineEffect != null)
            engineEffect.Play();
    }
}