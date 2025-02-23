using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private EnemyTankSpawner enemySpawner;

    private void Start() => SpawnEnemies();

    public void SpawnEnemies()
    {
        enemySpawner.SpawnEnemyTank(EnemyTankType.HeavyAssault);
        enemySpawner.SpawnEnemyTank(EnemyTankType.Scout);
        enemySpawner.SpawnEnemyTank(EnemyTankType.Artillery);
    }
}