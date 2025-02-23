using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController
{
    private EnemyTankModel tankModel;
    private EnemyTankView tankView;

    private Rigidbody rb;
    private Transform playerTarget;

    public EnemyTankController(EnemyTankModel _tankModel, EnemyTankView _tankView, Transform _playerTarget)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<EnemyTankView>(_tankView);

        rb = tankView.GetRigidbody();
        playerTarget = _playerTarget;

        tankModel.SetTankController(this);
        tankView.SetTankController(this);

        tankView.ChangeColor(tankModel.Color);
    }

    public void MoveTowardsPlayer()
    {
        if (playerTarget != null)
        {
            Vector3 direction = (playerTarget.position - tankView.transform.position).normalized;
            rb.velocity = direction * tankModel.MovementSpeed * Time.deltaTime;
        }
    }

    public void RotateTowardsPlayer()
    {
        if (playerTarget != null)
        {
            Vector3 direction = (playerTarget.position - tankView.transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, tankModel.RotationSpeed * Time.deltaTime));
        }
    }

    public void Shoot()
    {
        switch (tankModel.TankType)
        {
            case EnemyTankType.HeavyAssault:
                tankView.ShootArmorPiercing();
                break;
            case EnemyTankType.Scout:
                tankView.ShootRapidFire();
                break;
            case EnemyTankType.Artillery:
                tankView.ShootHighExplosive();
                break;
        }
    }

    public EnemyTankModel GetTankModel() => tankModel;
}