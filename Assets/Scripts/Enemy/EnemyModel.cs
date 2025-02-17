using UnityEngine;

public class EnemyModel
{
    private EnemyController enemyController;

    public float health;
    public float firePower;
    public float speed;
    public float fireRate;
    public Material color;

    public EnemyModel(EnemyTankData data)
    {
        health = data.health;
        firePower = data.firePower;
        speed = data.speed;
        fireRate = data.fireRate;
        color = data.color;
    }

    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
}