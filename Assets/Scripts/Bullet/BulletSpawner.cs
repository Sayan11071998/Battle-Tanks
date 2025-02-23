using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Bullet
    {
        public float speed;
        public float damage;
        public BulletType bulletType;
        public Material material;
        public float explosionRadius;
    }

    public BulletView bulletViewPrefab;
    public Transform firePoint;
    public TankController tankController;

    public Bullet[] bulletList;

    public void SpawnBullet(BulletType bulletType, Transform target = null)
    {
        int index = (int)bulletType;
        BulletModel bulletModel = new BulletModel
        (
            bulletList[index].speed,
            bulletList[index].damage,
            bulletList[index].bulletType,
            bulletList[index].material,
            bulletList[index].explosionRadius,
            target
        );

        BulletController bulletController = new BulletController(bulletModel, bulletViewPrefab);
        Quaternion adjustedRotation = firePoint.rotation * Quaternion.Euler(0f, 0f, 0f);
        bulletController.SetPositionAndRotation(firePoint.position, adjustedRotation);
    }
}