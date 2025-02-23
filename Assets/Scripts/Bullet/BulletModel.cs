using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    private BulletController bulletController;

    public float speed;
    public float damage;
    public BulletType bulletType;
    public Material material;
    public float explosionRadius;
    public Transform target;

    public BulletModel
    (
        float _speed,
        float _damage,
        BulletType _bulletType,
        Material _material,
        float _explosionRadius = 0f,
        Transform _target = null
    )
    {
        speed = _speed;
        damage = _damage;
        bulletType = _bulletType;
        material = _material;
        explosionRadius = _explosionRadius;
        target = _target;
    }

    public void SetBulletController(BulletController _bulletController) => bulletController = _bulletController;
    public BulletController GetBulletController() => bulletController;
}