using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    private BulletController bulletController;

    private float speed;
    private float damage;
    private BulletType bulletType;
    private Material material;
    private float explosionRadius;
    private Transform target;
    private float lifetime;

    public BulletModel
    (
        float _speed,
        float _damage,
        BulletType _bulletType,
        Material _material,
        float _explosionRadius = 0f,
        float _lifetime = 2f,
        Transform _target = null
    )
    {
        speed = _speed;
        damage = _damage;
        bulletType = _bulletType;
        material = _material;
        explosionRadius = _explosionRadius;
        lifetime = _lifetime;
        target = _target;
    }

    public void SetBulletController(BulletController _bulletController) => bulletController = _bulletController;
    public BulletController GetBulletController() => bulletController;
    public float Speed => speed;
    public float Damage => damage;
    public BulletType BulletType => bulletType;
    public Material Material => material;
    public float ExplosionRadius => explosionRadius;
    public Transform Target => target;
    public float Lifetime => lifetime;
}