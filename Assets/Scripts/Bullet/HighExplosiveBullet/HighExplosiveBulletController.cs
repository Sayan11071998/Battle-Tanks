using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighExplosiveBulletController : BulletController
{
    private HighExplosiveBulletModel heModel;

    public override void Initialize(BulletModel bulletModel, BulletView bulletView)
    {
        base.Initialize(bulletModel, bulletView);
        heModel = bulletModel as HighExplosiveBulletModel;
    }

    protected override void MoveBullet()
    {
        // Simple linear movement
        transform.position += transform.forward * model.speed * Time.deltaTime;
    }

    protected override void HandleCollision(RaycastHit hit)
    {
        view.PlayImpactEffect(hit.point);

        // Area of effect damage
        if (heModel != null)
        {
            Collider[] colliders = Physics.OverlapSphere(hit.point, heModel.explosionRadius);
            foreach (Collider collider in colliders)
            {
                TankController tankController = collider.GetComponent<TankController>();
                if (tankController != null)
                {
                    // Calculate damage based on distance from explosion center
                    float distance = Vector3.Distance(hit.point, collider.transform.position);
                    float damagePercent = 1 - (distance / heModel.explosionRadius);
                    float damage = model.damage * Mathf.Max(0.2f, damagePercent);

                    tankController.TakeDamage(damage);

                    // Apply explosion force
                    Rigidbody rb = collider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(heModel.explosionForce, hit.point, heModel.explosionRadius);
                    }
                }
            }
        }

        Destroy(gameObject);
    }
}