using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankView : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private MeshRenderer[] childs;
    [SerializeField] private BulletSpawner bulletSpawner;
    [SerializeField] private float shootCooldown = 0f;

    private EnemyTankController tankController;

    private void Update()
    {
        tankController.MoveTowardsPlayer();
        tankController.RotateTowardsPlayer();
        HandleShooting();
    }

    private void HandleShooting()
    {
        shootCooldown -= Time.deltaTime;
        if (shootCooldown <= 0)
        {
            tankController.Shoot();
            switch (tankController.GetTankModel().TankType)
            {
                case EnemyTankType.HeavyAssault:
                    shootCooldown = 1f / tankController.GetTankModel().FireRate;
                    break;
                case EnemyTankType.Scout:
                    shootCooldown = 1f / tankController.GetTankModel().FireRate;
                    break;
                case EnemyTankType.Artillery:
                    shootCooldown = 1f / tankController.GetTankModel().FireRate;
                    break;
            }
        }
    }

    public void ChangeColor(Material color)
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].material = color;
        }
    }

    public void ShootArmorPiercing() => bulletSpawner.SpawnBullet(BulletType.ArmorPiercing);
    public void ShootRapidFire() => bulletSpawner.SpawnBullet(BulletType.ArmorPiercing);
    public void ShootHighExplosive() => bulletSpawner.SpawnBullet(BulletType.HighExplosive);
    public void SetTankController(EnemyTankController _tankController) => tankController = _tankController;
    public Rigidbody GetRigidbody() => rb;
}