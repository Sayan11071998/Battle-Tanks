using System.Collections.Generic;
using UnityEngine;

public class EnemyTankSpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyTank
    {
        [SerializeField] private float health;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private EnemyTankType tankType;
        [SerializeField] private Material color;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float bulletDamage;
        [SerializeField] private float bulletExplosionRadius;
        [SerializeField] private float fireRate;

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

    [SerializeField] private EnemyTankView enemyTankViewPrefab;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private List<EnemyTank> enemyTankList;

    public void SpawnEnemyTank(EnemyTankType tankType)
    {
        int index = (int)tankType;
        EnemyTankModel tankModel = new EnemyTankModel(
            enemyTankList[index].Health,
            enemyTankList[index].MovementSpeed,
            enemyTankList[index].RotationSpeed,
            enemyTankList[index].TankType,
            enemyTankList[index].Color,
            enemyTankList[index].BulletSpeed,
            enemyTankList[index].BulletDamage,
            enemyTankList[index].BulletExplosionRadius,
            enemyTankList[index].FireRate
        );

        EnemyTankController tankController = new EnemyTankController(tankModel, enemyTankViewPrefab, playerTransform);
    }
}