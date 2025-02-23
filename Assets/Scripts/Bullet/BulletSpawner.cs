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

        public float Speed => speed;
        public float Damage => damage;
        public BulletType BulletType => bulletType;
        public Material Material => material;
        public float ExplosionRadius => explosionRadius;
    }

    [SerializeField] private BulletView bulletViewPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private TankController tankController;

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
            target
        );

        BulletController bulletController = new BulletController(bulletModel, bulletViewPrefab);
        Quaternion adjustedRotation = firePoint.rotation * Quaternion.Euler(0f, 0f, 0f);
        bulletController.SetPositionAndRotation(firePoint.position, adjustedRotation);
    }
}