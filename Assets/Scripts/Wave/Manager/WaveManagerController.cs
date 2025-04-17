// WaveManagerController.cs
using System.Collections;
using UnityEngine;

public class WaveManagerController : MonoBehaviour
{
    [SerializeField] private WaveManagerModel model;
    [SerializeField] private WaveView view;
    [SerializeField] private Transform[] spawnPoints;

    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject heavyTankPrefab;
    [SerializeField] private GameObject scoutTankPrefab;
    [SerializeField] private GameObject artilleryTankPrefab;

    [Header("Settings")]
    [SerializeField] private float delayBetweenWaves = 5f;
    [SerializeField] private float initialDelay = 3f;

    private bool isSpawning = false;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerTankController>().transform;

        if (model != null)
        {
            model.OnWaveStart += HandleWaveStart;
            model.OnWaveComplete += HandleWaveComplete;
            model.OnAllWavesComplete += HandleAllWavesComplete;

            StartCoroutine(StartFirstWaveAfterDelay());
        }
    }

    private IEnumerator StartFirstWaveAfterDelay()
    {
        yield return new WaitForSeconds(initialDelay);
        StartNextWave();
    }

    private void StartNextWave()
    {
        model.ProgressToNextWave();
    }

    private void HandleWaveStart(WaveModel wave)
    {
        view.UpdateWaveText(wave.waveNumber);
        view.UpdateEnemyCount(model.remainingEnemiesInWave, model.totalEnemiesInWave);
        view.ShowWaveStartMessage(wave.waveStartMessage, wave.waveStartSound);

        StartCoroutine(SpawnEnemiesForWave(wave));
    }

    private void HandleWaveComplete()
    {
        view.PlayWaveCompleteSound();
        isSpawning = false;

        StartCoroutine(StartNextWaveAfterDelay());
    }

    private IEnumerator StartNextWaveAfterDelay()
    {
        yield return new WaitForSeconds(delayBetweenWaves);
        StartNextWave();
    }

    private void HandleAllWavesComplete()
    {
        view.PlayAllWavesCompleteSound();
        Debug.Log("All waves completed!");
        // Show game complete screen, etc.
    }

    private IEnumerator SpawnEnemiesForWave(WaveModel wave)
    {
        isSpawning = true;

        foreach (var enemyData in wave.enemiesToSpawn)
        {
            for (int i = 0; i < enemyData.count; i++)
            {
                SpawnEnemy(enemyData.tankType);
                yield return new WaitForSeconds(wave.timeBetweenSpawns);

                if (!isSpawning)
                    yield break;
            }
        }
    }

    private void SpawnEnemy(EnemyTankModel.TankType tankType)
    {
        // Choose a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Create the enemy prefab based on type
        GameObject enemyPrefab = GetEnemyPrefabByType(tankType);
        if (enemyPrefab != null)
        {
            GameObject enemyObj = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // Get components
            EnemyTankModel enemyModel = enemyObj.GetComponent<EnemyTankModel>();
            EnemyTankView enemyView = enemyObj.GetComponent<EnemyTankView>();
            EnemyTankController enemyController = enemyObj.GetComponent<EnemyTankController>();

            // Setup based on type
            if (enemyModel != null)
            {
                enemyModel.tankType = tankType;
                ConfigureEnemyByType(enemyModel, tankType);

                // Set player as target
                BulletModel bulletModel = enemyModel.GetComponent<BulletModel>();
                if (bulletModel != null && playerTransform != null)
                {
                    bulletModel.target = playerTransform;
                }
            }

            // Initialize controller
            if (enemyController != null && enemyModel != null && enemyView != null)
            {
                enemyController.Initialize(enemyModel, enemyView);
            }
        }
    }

    private GameObject GetEnemyPrefabByType(EnemyTankModel.TankType tankType)
    {
        switch (tankType)
        {
            case EnemyTankModel.TankType.HeavyAssault:
                return heavyTankPrefab;
            case EnemyTankModel.TankType.Scout:
                return scoutTankPrefab;
            case EnemyTankModel.TankType.Artillery:
                return artilleryTankPrefab;
            default:
                return heavyTankPrefab;
        }
    }

    private void ConfigureEnemyByType(EnemyTankModel enemyModel, EnemyTankModel.TankType tankType)
    {
        switch (tankType)
        {
            case EnemyTankModel.TankType.HeavyAssault:
                enemyModel.maxHealth = 200f;
                enemyModel.moveSpeed = 3f;
                enemyModel.rotationSpeed = 1f;
                enemyModel.detectionRange = 20f;
                enemyModel.attackRange = 15f;
                enemyModel.fireRate = 0.5f;
                enemyModel.bulletDamage = 30f;
                enemyModel.bulletType = BulletType.ArmorPiercing;
                enemyModel.scoreValue = 150;
                break;

            case EnemyTankModel.TankType.Scout:
                enemyModel.maxHealth = 100f;
                enemyModel.moveSpeed = 7f;
                enemyModel.rotationSpeed = 3f;
                enemyModel.detectionRange = 25f;
                enemyModel.attackRange = 12f;
                enemyModel.fireRate = 2f;
                enemyModel.bulletDamage = 15f;
                enemyModel.bulletType = BulletType.GuidedMissile;
                enemyModel.scoreValue = 100;
                break;

            case EnemyTankModel.TankType.Artillery:
                enemyModel.maxHealth = 150f;
                enemyModel.moveSpeed = 4f;
                enemyModel.rotationSpeed = 1.5f;
                enemyModel.detectionRange = 30f;
                enemyModel.attackRange = 25f;
                enemyModel.fireRate = 0.3f;
                enemyModel.bulletDamage = 25f;
                enemyModel.bulletType = BulletType.HighExplosive;
                enemyModel.scoreValue = 125;
                break;
        }
    }

    public void EnemyDestroyed()
    {
        model.EnemyDestroyed();
        view.UpdateEnemyCount(model.remainingEnemiesInWave, model.totalEnemiesInWave);
    }
}