using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPiercingBulletController : BulletController
{
    private ArmorPiercingBulletModel apModel;

    public override void Initialize(BulletModel bulletModel, BulletView bulletView)
    {
        base.Initialize(bulletModel, bulletView);
        apModel = bulletModel as ArmorPiercingBulletModel;
    }

    protected override void MoveBullet()
    {
        // Simple linear movement
        transform.position += transform.forward * model.speed * Time.deltaTime;
    }

    protected override void HandleCollision(RaycastHit hit)
    {
        // Apply penetration factor to damage
        TankController tankController = hit.collider.GetComponent<TankController>();
        if (tankController != null && apModel != null)
        {
            tankController.TakeDamage(model.damage * apModel.penetrationFactor);
        }

        view.PlayImpactEffect(hit.point);
        Destroy(gameObject);
    }
}