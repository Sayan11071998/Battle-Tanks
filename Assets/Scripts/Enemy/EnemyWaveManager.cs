using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    public EnemyWaveData[] waves;
    public EnemyView enemyPrefab;
    public Transform[] spawnPoints;
    public float waveDelay = 5f;
    public TankController playerController;
    private List<EnemyController> activeEnemies = new List<EnemyController>();

    private int currentWaveIndex = 0;

    // void Start()
    // {
    //     if (playerController != null)
    //     {
    //         StartCoroutine(SpawnWaves());
    //     }
    //     else
    //     {
    //         Debug.LogError("PlayerController is not assigned to EnemyWaveManager!");
    //     }

    //     // StartCoroutine(SpawnWaves());
    // }

    public void SetPlayerController(TankController _playerController)
    {
        playerController = _playerController;
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
        if (playerController == null)
        {
            Debug.LogError("PlayerController is not assigned!");
            return;
        }

        EnemyModel enemyModel = new EnemyModel(data);
        EnemyController enemyController = new EnemyController(enemyModel, enemyPrefab, playerController.GetTankView().transform);

        enemyController.GetEnemyView().transform.position = spawnPoint.position;

        activeEnemies.Add(enemyController);
    }

    void Update()
    {
        if (playerController == null) return;

        foreach (var enemyController in activeEnemies)
        {
            enemyController.SetPlayerTransform(playerController.GetTankView().transform);
            enemyController.Update();
        }
    }
}