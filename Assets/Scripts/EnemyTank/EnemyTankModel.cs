using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankModel
{
    private EnemyTankController tankController;

    [SerializeField] private float health;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private EnemyTankType tankType;
    [SerializeField] private Material color;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDamage;
    [SerializeField] private float bulletExplosionRadius;
    [SerializeField] private float fireRate;

    public EnemyTankModel
    (
        float _health,
        float _movementSpeed,
        float _rotationSpeed,
        EnemyTankType _tankType,
        Material _color,
        float _bulletSpeed,
        float _bulletDamage,
        float _bulletExplosionRadius = 0f,
        float _fireRate = 1f
    )
    {
        health = _health;
        movementSpeed = _movementSpeed;
        rotationSpeed = _rotationSpeed;
        tankType = _tankType;
        color = _color;
        bulletSpeed = _bulletSpeed;
        bulletDamage = _bulletDamage;
        bulletExplosionRadius = _bulletExplosionRadius;
        fireRate = _fireRate;
    }

    public void SetTankController(EnemyTankController _tankController) => tankController = _tankController;
    public float Health => health;
    public float MovementSpeed => movementSpeed;
    public float RotationSpeed => rotationSpeed;
    public EnemyTankType TankType => tankType;
    public Material Color => color;
    public float BulletSpeed => bulletSpeed;
    public float BulletDamage => bulletDamage;
    public float BulletExplosionRadius => bulletExplosionRadius;
    public float FireRate => fireRate;
}