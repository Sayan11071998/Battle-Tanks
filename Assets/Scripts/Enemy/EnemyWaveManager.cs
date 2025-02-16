using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    public EnemyWaveData[] waves;
    public EnemyView enemyPrefab;
    public Transform[] spawnPoints;
    public float waveDelay = 5f;
    public Transform playerTransform;
    private List<EnemyController> activeEnemies = new List<EnemyController>();

    private int currentWaveIndex = 0;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (currentWaveIndex < waves.Length)
        {
            yield return new WaitForSeconds(waveDelay);
            SpawnWave(waves[currentWaveIndex]);
            currentWaveIndex++;
        }
    }

    private void SpawnWave(EnemyWaveData wave)
    {
        for (int i = 0; i < wave.enemyTanks.Length; i++)
        {
            Transform spawnPoint = spawnPoints[i % spawnPoints.Length];
            SpawnEnemy(wave.enemyTanks[i], spawnPoint);
        }
    }

    private void SpawnEnemy(EnemyTankData data, Transform spawnPoint)
    {
        EnemyModel enemyModel = new EnemyModel(data);
        EnemyController enemyController = new EnemyController(enemyModel, enemyPrefab, playerTransform);

        enemyController.GetEnemyView().transform.position = spawnPoint.position;

        activeEnemies.Add(enemyController);
    }

    void Update()
    {
        foreach (var enemyController in activeEnemies)
        {
            enemyController.Update();
        }
    }
}