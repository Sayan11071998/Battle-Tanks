using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagerModel : MonoBehaviour
{
    public List<WaveModel> waves = new List<WaveModel>();
    public int currentWaveIndex = -1;
    public int totalEnemiesInWave;
    public int remainingEnemiesInWave;

    public event Action<WaveModel> OnWaveStart;
    public event Action OnWaveComplete;
    public event Action OnAllWavesComplete;

    public WaveModel GetCurrentWave()
    {
        if (currentWaveIndex >= 0 && currentWaveIndex < waves.Count)
            return waves[currentWaveIndex];
        return null;
    }

    public WaveModel GetNextWave()
    {
        int nextIndex = currentWaveIndex + 1;
        if (nextIndex < waves.Count)
            return waves[nextIndex];
        return null;
    }

    public void ProgressToNextWave()
    {
        currentWaveIndex++;

        if (currentWaveIndex < waves.Count)
        {
            SetupWave();
            OnWaveStart?.Invoke(GetCurrentWave());
        }
        else
        {
            OnAllWavesComplete?.Invoke();
        }
    }

    private void SetupWave()
    {
        WaveModel wave = GetCurrentWave();
        totalEnemiesInWave = 0;

        foreach (var enemyData in wave.enemiesToSpawn)
        {
            totalEnemiesInWave += enemyData.count;
        }

        remainingEnemiesInWave = totalEnemiesInWave;
    }

    public void EnemyDestroyed()
    {
        remainingEnemiesInWave--;

        if (remainingEnemiesInWave <= 0)
        {
            OnWaveComplete?.Invoke();
        }
    }
}