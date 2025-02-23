using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Bullet
    {
        [SerializeField] private float speed;
        [SerializeField] private float damage;
        [SerializeField] private BulletType bulletType;
        [SerializeField] private Material material;
        [SerializeField] private float explosionRadius;
        [SerializeField] private float lifetime;

        public float Speed => speed;
        public float Damage => damage;
        public BulletType BulletType => bulletType;
        public Material Material => material;
        public float ExplosionRadius => explosionRadius;
        public float Lifetime => lifetime;
    }

    [SerializeField] private BulletView bulletViewPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private TankController tankController; // Player Tank
    [SerializeField] private EnemyTankController enemyTankController;

    [SerializeField] private Bullet[] bulletList;

    public void SpawnBullet(BulletType bulletType, Transform target = null)
    {
        int index = (int)bulletType;
        BulletModel bulletModel = new BulletModel
        (
            bulletList[index].Speed,
            bulletList[index].Damage,
            bulletList[index].BulletType,
            bulletList[index].Material,
            bulletList[index].ExplosionRadius,
            bulletList[index].Lifetime,
            target
        );

        BulletController bulletController = new BulletController(bulletModel, bulletViewPrefab);
        Quaternion adjustedRotation = firePoint.rotation * Quaternion.Euler(0f, 0f, 0f);
        bulletController.SetPositionAndRotation(firePoint.position, adjustedRotation);
    }

    public void SpawnEnemyBullet(BulletType bulletType, Transform firePoint, Transform target = null)
    {
        this.firePoint = firePoint;
        SpawnBullet(bulletType, target);
        this.firePoint = null;
    }
}