using UnityEngine;

public abstract class TankController : MonoBehaviour
{
    protected TankModel model;
    protected TankView view;

    public virtual void Initialize(TankModel tankModel, TankView tankView)
    {
        model = tankModel;
        view = tankView;

        model.Initialize();
        view.Initialize(model);
    }

    public virtual void Fire()
    {
        if (model.CanFire)
        {
            BulletModel bulletPrefab = GetBulletPrefab();
            if (bulletPrefab != null)
            {
                BulletModel bullet = Instantiate(bulletPrefab, model.firePoint.position, model.firePoint.rotation);
                bullet.Initialize(model.bulletDamage);

                BulletController bulletController = bullet.GetComponent<BulletController>();
                if (bulletController != null)
                {
                    bulletController.Initialize(bullet, bullet.GetComponent<BulletView>());
                }

                view.PlayFireEffect();
                model.ResetFireCooldown();
            }
        }
    }

    protected abstract BulletModel GetBulletPrefab();

    public void TakeDamage(float damage)
    {
        model.TakeDamage(damage);
        view.PlayHitEffect();
    }
}