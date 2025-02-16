using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public BulletView bulletPrefab;
    private TankController tankController;

    [SerializeField] private float bulletSpeed = 15f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnBullet();
        }
    }

    private void SpawnBullet()
    {
        if (tankController != null)
        {
            TankModel tankModel = tankController.GetTankModel();
            BulletModel bulletModel = new BulletModel(bulletSpeed, tankModel.color);
            BulletController bulletController = new BulletController(bulletModel, bulletPrefab);

            Transform spawnPoint = tankController.GetTankView().GetBulletSpawnPoint();
            Vector3 spawnPosition = spawnPoint.position;
            Vector3 spawnDirection = spawnPoint.forward;

            bulletController.Move(spawnPosition, spawnDirection);
        }
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}