using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    private BulletModel bulletModel;
    private BulletView bulletView;
    private Rigidbody rb;

    public BulletController(BulletModel _bulletModel, BulletView _bulletView)
    {
        bulletModel = _bulletModel;
        bulletView = GameObject.Instantiate<BulletView>(_bulletView);

        rb = bulletView.GetRigidbody();

        bulletModel.SetBulletController(this);
        bulletView.SetBulletController(this);

        bulletView.ChangeAppearance(bulletModel.Material);
    }

    public void Move()
    {
        switch (bulletModel.BulletType)
        {
            case BulletType.HighExplosive:
                rb.velocity = bulletView.transform.forward * bulletModel.Speed;
                break;
            case BulletType.GuidedMissile:
                if (bulletModel.Target != null)
                {
                    Vector3 direction = (bulletModel.Target.position - bulletView.transform.position).normalized;
                    rb.velocity = direction * bulletModel.Speed;
                    bulletView.transform.rotation = Quaternion.LookRotation(direction);
                }
                else
                {
                    rb.velocity = bulletView.transform.forward * bulletModel.Speed;
                }
                break;
            case BulletType.ArmorPiercing:
                rb.velocity = bulletView.transform.forward * bulletModel.Speed;
                break;
        }
    }

    public void OnCollision(Collider other)
    {
        switch (bulletModel.BulletType)
        {
            case BulletType.HighExplosive:
                Collider[] hitColliders = Physics.OverlapSphere(bulletView.transform.position, bulletModel.ExplosionRadius);
                foreach (var hit in hitColliders)
                {
                    if (hit.CompareTag("Enemy"))
                    {
                        Debug.Log("High-Explosive hit: " + hit.name);
                    }
                }
                break;
            case BulletType.GuidedMissile:
                if (other.CompareTag("Enemy"))
                {
                    Debug.Log("Guided-Missile hit: " + other.name);
                }
                break;
            case BulletType.ArmorPiercing:
                if (other.CompareTag("Enemy"))
                {
                    Debug.Log("Armor-Piercing hit: " + other.name);
                }
                break;
        }
        GameObject.Destroy(bulletView.gameObject);
    }

    public BulletModel GetBulletModel() => bulletModel;
    public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
    {
        bulletView.transform.position = position;
        bulletView.transform.rotation = rotation;
    }
}