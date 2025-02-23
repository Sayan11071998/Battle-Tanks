using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    private BulletController bulletController;

    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private BulletType bulletType;
    [SerializeField] private Material material;
    [SerializeField] private float explosionRadius;
    [SerializeField] private Transform target;

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
    public float Speed => speed;
    public float Damage => damage;
    public BulletType BulletType => bulletType;
    public Material Material => material;
    public float ExplosionRadius => explosionRadius;
    public Transform Target => target;
}