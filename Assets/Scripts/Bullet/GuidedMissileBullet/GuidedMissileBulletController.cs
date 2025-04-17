using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedMissileBulletController : BulletController
{
    private GuidedMissileBulletModel gmModel;
    private bool guidanceActivated = false;
    private float activationTime;

    public override void Initialize(BulletModel bulletModel, BulletView bulletView)
    {
        base.Initialize(bulletModel, bulletView);
        gmModel = bulletModel as GuidedMissileBulletModel;

        if (gmModel != null)
        {
            activationTime = Time.time + gmModel.activationDelay;
        }
    }

    protected override void MoveBullet()
    {
        if (gmModel != null && model.target != null)
        {
            if (!guidanceActivated && Time.time >= activationTime)
            {
                guidanceActivated = true;
                GuidedMissileBulletView gmView = view as GuidedMissileBulletView;
                if (gmView != null)
                {
                    gmView.ShowGuidanceActivated();
                }
            }

            if (guidanceActivated)
            {
                // Guided movement
                Vector3 direction = model.target.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, gmModel.turnSpeed * Time.deltaTime);
            }
        }

        // Move forward
        transform.position += transform.forward * model.speed * Time.deltaTime;
    }
}