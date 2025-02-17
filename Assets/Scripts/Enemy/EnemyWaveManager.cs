using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    public EnemyWaveData[] waves;
    public EnemyView enemyPrefab;
    public Transform[] spawnPoints;
    public float waveDelay = 10f;
    public TankController playerController;
    public TMPro.TMP_Text waveCountdownText;

    private List<EnemyController> activeEnemies = new List<EnemyController>();
    private int currentWaveIndex = 0;
    private bool isWaitingForNextWave = false;
    private float countdownTimer;

    public void SetPlayerController(TankController _playerController)
    {
        playerController = _playerController;
        SpawnFirstWaveImmediately();
    }

    private void SpawnFirstWaveImmediately()
    {
        StartCoroutine(SpawnWave(waves[currentWaveIndex]));
        currentWaveIndex++;
    }

    void Update()
    {
        if (playerController == null) return;

        foreach (var enemyController in activeEnemies)
        {
            enemyController.SetPlayerTransform(playerController.GetTankView().transform);
            enemyController.Update();
        }

        if (!isWaitingForNextWave && activeEnemies.Count == 0 && currentWaveIndex < waves.Length)
        {
            StartCoroutine(StartNextWaveCountdown());
        }

        UpdateCountdownUI();
    }

    private IEnumerator StartNextWaveCountdown()
    {
        isWaitingForNextWave = true;
        countdownTimer = waveDelay;

        while (countdownTimer > 0)
        {
            countdownTimer -= Time.deltaTime;
            yield return null;
        }

        StartCoroutine(SpawnWave(waves[currentWaveIndex]));
        currentWaveIndex++;
        isWaitingForNextWave = false;
    }

    private IEnumerator SpawnWave(EnemyWaveData wave)
    {
        List<EnemyController> waveEnemies = new List<EnemyController>();

        foreach (EnemyTankData data in wave.enemyTanks)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            EnemyModel enemyModel = new EnemyModel(data);
            EnemyController enemyController = new EnemyController(enemyModel, enemyPrefab, playerController.GetTankView().transform);
            enemyController.OnEnemyDestroyed += HandleEnemyDestroyed;
            
            enemyController.GetEnemyView().transform.position = spawnPoint.position;
            waveEnemies.Add(enemyController);
            activeEnemies.Add(enemyController);
            
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void HandleEnemyDestroyed(EnemyController destroyedEnemy)
    {
        activeEnemies.Remove(destroyedEnemy);
        destroyedEnemy.OnEnemyDestroyed -= HandleEnemyDestroyed;
    }

    private void UpdateCountdownUI()
    {
        if (isWaitingForNextWave)
        {
            waveCountdownText.text = $"Next Wave In: {Mathf.CeilToInt(countdownTimer)}";
        }
        else
        {
            waveCountdownText.text = currentWaveIndex >= waves.Length ? 
                "All Waves Cleared!" : 
                $"Wave {currentWaveIndex + 1}/{waves.Length}";
        }
    }
}