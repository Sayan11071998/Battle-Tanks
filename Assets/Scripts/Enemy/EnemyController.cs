using UnityEngine;

public class EnemyController
{
    private EnemyModel enemyModel;
    private EnemyView enemyView;
    private Transform playerTransform;
    private float lastFireTime = 0f;

    public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView, Transform _playerTransform)
    {
        enemyModel = _enemyModel;
        enemyView = GameObject.Instantiate<EnemyView>(_enemyView);
        playerTransform = _playerTransform;

        enemyModel.SetEnemyController(this);
        enemyView.SetEnemyController(this);

        enemyView.ChangeColor(enemyModel.color);
    }

    public void Update()
    {
        MoveTowardPlayer();
        TryFireAtPlayer();
    }

    private void MoveTowardPlayer()
    {
        if (playerTransform == null) return;

        Vector3 direction = (playerTransform.position - enemyView.transform.position).normalized;
        direction.y = 0;

        enemyView.GetRigidbody().velocity = direction * enemyModel.speed;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        enemyView.transform.rotation = Quaternion.Slerp(enemyView.transform.rotation, targetRotation, Time.deltaTime * 5f);
    }

    private void TryFireAtPlayer()
    {
        if (playerTransform == null) return;

        float distanceToPlayer = Vector3.Distance(enemyView.transform.position, playerTransform.position);

        if (distanceToPlayer < 10f)
        {
            if (Time.time - lastFireTime >= enemyModel.fireRate)
            {
                FireBullet();
                lastFireTime = Time.time;
            }
        }
    }

    private void FireBullet()
    {
        Transform spawnPoint = enemyView.GetBulletSpawnPoint();
        Vector3 spawnPosition = spawnPoint.position;
        Vector3 spawnDirection = spawnPoint.forward;

        float bulletLifeTime = 3f;

        BulletModel bulletModel = new BulletModel(enemyModel.firePower, enemyModel.color, bulletLifeTime);
        BulletController bulletController = new BulletController(bulletModel, enemyView.GetBulletPrefab());

        bulletController.Move(spawnPosition, spawnDirection);
    }

    public EnemyModel GetEnemyModel()
    {
        return enemyModel;
    }

    public EnemyView GetEnemyView()
    {
        return enemyView;
    }
}
